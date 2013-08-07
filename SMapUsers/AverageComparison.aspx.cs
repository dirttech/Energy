using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;
using App_Code.FetchingEnergyss;
using App_Code.FetchingEnergySmap;
using App_Code.Utility;
using App_Code.User_Mapping;
using System.Web.Script.Serialization;

public partial class AverageComparison : System.Web.UI.Page
{
    public JavaScriptSerializer javaSerial = new JavaScriptSerializer();

    public int[] avgTimeStamps;
    public int[] timeStamps;

    public static string apartment = "";
    public static string building = "";


    public double[] values;
    public string[] timeSeries;

    public double[] avgValues;
    public string[] avgTimeSeries;

  
    protected void CheckLogin()
    {
        if (Session["UserName"] == null || Session["UserName"] == "")
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
       
        if (Session["MeterType"] != null && Session["Apartment"] != null && Session["Building"]!=null)
        {

            building = Session["Building"].ToString();
            apartment= Session["Apartment"].ToString();
        
            Heading.InnerText = hiddenHeadingType.Value;
            if (IsPostBack == false)
            {
                
                DateTime frDate = DateTime.Today.AddDays(-7);
             
                Utilities ut1 = Utilitie_S.DateTimeToEpoch(frDate);
                
                Heading.InnerText = "Last 7 Days";
                List<int> epochs = new List<int>();
                epochs = Utilitie_S.Return_Bar_Time(frDate, "7Days");
                //Plot_Line_Graph(epochs);
                Plot_Avg_Graph(epochs);
            }
        }
        else
        {
            //meterTypeList.SelectedValue = meter_type;
            Response.Write("<script>alert('Sorry! Your Meter is not registered yet.');</script>");
            //Session["UserName"] = null;
            //Response.Redirect("LoginPage.aspx");
        }
    }

    protected void Plot_Avg_Graph(List<int> epochs)
    {
        try
        {

            string meter_type = meterTypeList.SelectedValue;
            meterTypeList.SelectedValue = meter_type;

            string[] fromTimeArray = Utilitie_S.SMapValidDateFormatter(epochs);

            List<int> toEpochs = new List<int>();
            for (int i = 0; i < epochs.Count; i++)
            {
                toEpochs.Add(epochs[i] + (epochs[1] - epochs[0]));
            }
            string[] toTimeArray = Utilitie_S.SMapValidDateFormatter(toEpochs);

            FetchEnergyDataS_Map.FetchBarConsumption(fromTimeArray, toTimeArray, apartment, meter_type, out timeStamps, out values);
            Utilitie_S.ZeroArrayRefiner(timeStamps, values, out timeStamps, out values);

            timeSeries = Utilitie_S.TimeFormatter(timeStamps);

            FetchEnergyDataS_Map.FetchAvgConsumption(fromTimeArray, toTimeArray, building, meter_type, out avgTimeStamps, out avgValues);
            Utilitie_S.ZeroAverageArrayRefiner(avgTimeStamps, avgValues, out avgTimeStamps, out avgValues);

            avgTimeSeries = Utilitie_S.TimeFormatter(avgTimeStamps);

            for (int i = 0; i < values.Length - 1; i++)
            {
                if (values[i] > 0)
                {
                    values[i] = values[i + 1] - values[i];
                }
                else
                {
                    values[i] = 0;
                }
            }
            values[values.Length - 1] = 0;
            for (int j = 0; j < avgValues.Length - 1; j++)
            {
                if (avgValues[j] > 0)
                {
                    avgValues[j] = avgValues[j + 1] - avgValues[j];
                }
                else
                {
                    avgValues[j] = 0;
                }
            }
            avgValues[avgValues.Length - 1] = 0;
        }
        catch (Exception exp)
        {

        }
        //Response.Write(avgValues);
    }

    protected void plot_Click(object sender, EventArgs e)
    {
        Plotting_Click();
    }

    protected void Plotting_Click()
    {
        

        string compType = "LWK";
        DateTime fromTime = DateTime.Now.AddDays(-7);
        List<int> epochs = new List<int>();
        epochs = Utilitie_S.Return_Bar_Time(fromTime, compType);

        if (hidCompType.Value == "LWK")
        {
            compType = "7Days";
            fromTime = DateTime.Today.AddDays(-7);

            epochs = Utilitie_S.Return_Bar_Time(fromTime, compType);
        }
        else if (hidCompType.Value == "THMNT")
        {
            compType = "DTD";
            fromTime = DateTime.Today;
            epochs = Utilitie_S.Return_Bar_Time(fromTime, compType);
        }
        else if (hidCompType.Value == "LMNTH")
        {
            compType = "DTD";
            fromTime = DateTime.Today.AddMonths(-1);
            epochs = Utilitie_S.Return_Bar_Time(fromTime, compType);
        }
        else
        {
            compType = "YEAR";
            fromTime = DateTime.Today;
            epochs = Utilitie_S.LastDashMonths(DateTime.Today.Month);
        }

        Plot_Avg_Graph(epochs);
    }

    protected void meterTypeList_SelectedIndexChanged(object sender, EventArgs e)
    {
        Plotting_Click();

    }

    protected void viewTypeList_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (viewTypeList.SelectedValue == "normal")
        {
            hiddenPlotType.Value = "normal";
        }
        else
        {
            hiddenPlotType.Value = null;
        }
        Plotting_Click();

    }

    protected void logOut_Click(object sender, EventArgs e)
    {
        Session["UserName"] = null;
        Response.Redirect("~/Loggin.aspx");
    }

 
}