﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using App_Code.FetchingEnergySmap;
using App_Code.Utility;
using System.Web.Script.Serialization;
using WebAnalytics;

public partial class BarGraph : System.Web.UI.Page
{

    public JavaScriptSerializer javaSerial = new JavaScriptSerializer();
    public double[] energyArray;
    public int[] timeArray;
    public string[] meterIDs;
    public static string[] timeSeries;

    public static string apartment = "";
    public static string building = "";

    public static string path = "/FH-RPi02/Meter22/Energy";

    protected void logOut_Click(object sender, EventArgs e)
    {
        try
        {
            WebAnalytics.LoggerService LG = new LoggerService();

            LoggingEvent logObj = new LoggingEvent();
            logObj.EventID = "Faculty Log Out";
            logObj.UserID = Session["UserID"].ToString();
            bool sts = LG.LogEvent(logObj);

        }
        catch (Exception exp)
        {

        }

        Session["UserName"] = null;
        Response.Redirect("~/Loggin.aspx");
    }

    protected void CheckLogin()
    {
        if (Session["UserName"] == null || Session["UserName"]=="" )
        {
            Response.Redirect("~/Loggin.aspx");
        }
        else
        {
            nameTitle.InnerText = "Welcome " + Session["UserName"].ToString();
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
         CheckLogin();
         if (IsPostBack == false)
         {
             try
             {
                 

                 WebAnalytics.LoggerService LG = new LoggerService();

                 LoggingEvent logObj = new LoggingEvent();
                 logObj.EventID = "Energy Consumption Page";
                 logObj.UserID = Session["UserID"].ToString();
                 bool sts = LG.LogEvent(logObj);

             }
             catch (Exception exp)
             {

             }
         }
        
        if (Session["MeterType"] != null && Session["Apartment"] != null && Session["Building"]!=null)
        {

            building = Session["Building"].ToString();
            apartment= Session["Apartment"].ToString();
            if (IsPostBack == false)
             {
                 Populate_Meters();
                 Plot_Bar_Graph("LOAD");
             }
             else
             {
                 Heading.InnerText = hiddenHeadingType.Value;
             }
         }
         else
         {
             Response.Write("<script>alert('Sorry! Your Meter is not registered yet.');</script>");
             //Session["UserName"] = null;
             //Response.Redirect("LoginPage.aspx");
         }
    }
    protected void submitDate_Click(object sender, EventArgs e)
    {
        Plot_Bar_Graph(null);
    }

    protected void Plot_Bar_Graph(string callBy)
    {

        try
        {
            string meter_id = meterTypeList.SelectedValue;

            DateTime frDate = new DateTime();
            if (callBy == "LOAD")
            {
                frDate = DateTime.Now.AddDays(-7);
            }
            
            else
            {
                frDate = DateTime.ParseExact(fromDate.Value + ",000", "dd/MM/yyyy HH:mm:ss,fff",
                                           System.Globalization.CultureInfo.InvariantCulture);
            }

            string comparisonType = "DTD";
            comparisonType = hidCompType.Value;

            try
            {
                WebAnalytics.LoggerService LG = new LoggerService();

                LoggingEvent logObj = new LoggingEvent();
                logObj.EventID = "Energy Consumption of meter" + meter_id + " compare " + comparisonType;
                logObj.UserID = Session["UserID"].ToString();
                bool sts = LG.LogEvent(logObj);

            }
            catch (Exception exp)
            {

            }

           
            List<int> epochs = Utilitie_S.Return_Bar_Time(frDate, comparisonType);

            if (epochs != null)
            {
                int[] ep = new int[epochs.Count];
                for (int k = 0; k < epochs.Count; k++)
                {
                    ep[k] = epochs[k];
                }
                timeSeries = Utilitie_S.TimeFormatterBar(ep);

               
                for(int v=0;v<timeSeries.Length-1;v++)
                {
                    timeSeries[v] = timeSeries[v] + " - " + timeSeries[v+1];
                }
                timeSeries[timeSeries.Length - 1] = "";

                List<int> toEpochs = new List<int>();
                for (int i = 0; i <epochs.Count; i++)
                {
                    toEpochs.Add(epochs[i] + (epochs[1] - epochs[0]));
                }
                string[] frDateArray = Utilitie_S.SMapValidDateFormatter(epochs);
                
                string[] toDateArray = Utilitie_S.SMapValidDateFormatter(toEpochs);
               
                FetchEnergyDataS_Map.FetchBarConsumptionWithMeterId(frDateArray, toDateArray, apartment, meter_id, out timeArray, out energyArray);
                Utilitie_S.ZeroArrayRefiner(timeArray, energyArray, out timeArray, out energyArray);

                for (int p = 1; p < energyArray.Length; p++)
                {
                    if (comparisonType == "WKDY" || comparisonType=="WKND")
                    {
                        if (timeArray[p]-timeArray[p-1] < 25 * 60*60)
                        {
                            energyArray[p-1] = Math.Round((energyArray[p] - energyArray[p-1])/1000,2);
                        }
                        else
                        {
                            energyArray[p-1] = 0;
                            timeArray[p-1] = 0;
                        }
                    }                   
                    else
                    {
                        energyArray[p - 1] =Math.Round(( energyArray[p] - energyArray[p - 1])/1000,2);
                    }
                }
                Utilitie_S.ZeroArrayRefiner(timeArray, energyArray, out timeArray, out energyArray);

                timeSeries = Utilitie_S.TimeFormatter(timeArray);
                if (comparisonType == "WKDY" || comparisonType=="WKND")
                {
                    timeSeries = Utilitie_S.TimeFormatterBar(timeArray);
                    timeSeries[timeSeries.Length - 1] = "";
                }                

                energyArray[energyArray.Length - 1] = 0;



                if (energyArray.Length < 1)
                {
                    subHeading.InnerText = "Not Enough data to plot";
                }
            } 
        }
        catch (Exception e)
        {

        }
    }
    protected void Populate_Meters()
    {
        meterTypeList.Items.Clear();
        string supplyType = "";
        string demo = "";
        FetchEnergyDataS_Map.ListingMeterIDsByApartment(building, apartment, out meterIDs);
        foreach (string id in meterIDs)
        {
            FetchEnergyDataS_Map.GetMeterLocationByID(id, building, out demo, out demo, out demo, out demo, out demo, out supplyType);
            meterTypeList.Items.Add(new ListItem(supplyType , id));
            meterTypeList.SelectedValue = id;
        }
    }
    protected void meterTypeList_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            WebAnalytics.LoggerService LG = new LoggerService();

            LoggingEvent logObj = new LoggingEvent();
            logObj.EventID = "Energy Consumption meter change to " + meterTypeList.SelectedValue;
            logObj.UserID = Session["UserID"].ToString();
            bool sts = LG.LogEvent(logObj);

        }
        catch (Exception exp)
        {

        }

        if (fromDate.Value == "")
        {
            Plot_Bar_Graph("LOAD");
        }
        else
        {
            Plot_Bar_Graph(null);
        }

    }
}