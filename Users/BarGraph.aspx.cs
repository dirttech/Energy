using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using App_Code.FetchingEnergyss;
using App_Code.Utility;
using System.Web.Script.Serialization;

public partial class BarGraph : System.Web.UI.Page
{

    public JavaScriptSerializer javaSerial = new JavaScriptSerializer();
    public float[] energyArray;
    public int[] timeArray;
    public static string[] timeSeries;
    public static int meterId;
    public static string deviceId;

    protected void logOut_Click(object sender, EventArgs e)
    {
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
         if (Session["MeterID"] != null && Session["DeviceID"] != null)
         {
             meterId = Convert.ToInt32(Session["MeterID"]);
             deviceId = Session["DeviceID"].ToString();
             if (IsPostBack == false)
             {
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


            List<int> epochs = Utilitie_S.Return_Bar_Time(frDate, comparisonType);
            
            if (epochs != null)
            {
                List<FetchingEnergy> energyObj = FetchingEnergy_s.fetchEnergyBar(epochs, meterId, deviceId);
                if (energyObj != null)
                {
                    int count = energyObj.Count;

                    energyArray = new float[count-1];
                    timeArray = new int[count];

                    int fTim = energyObj[0].TimeStamp;
                    int tTim = energyObj[0].TimeStamp;
                   
                    
                    for (int i = 0; i < count-1; i++)
                    {
                        energyArray[i] = energyObj[i+1].FwdHr-energyObj[i].FwdHr;                        

                    }
                    for (int i = 0; i < energyObj.Count; i++)
                    {
                        timeArray[i] = energyObj[i].TimeStamp;
                        tTim = energyObj[i].TimeStamp;
                    }
                    
                    timeSeries = Utilitie_S.TimeFormatterBar(timeArray);
                    Utilities frm = Utilitie_S.EpochToDateTime(fTim);
                    Utilities to = Utilitie_S.EpochToDateTime(tTim);
                    subHeading.InnerText = frm.Date.ToString("d MMM yy HH:mm") + " - " + to.Date.ToString("d MMM yy HH:mm");
                }
                else
                {
                    subHeading.InnerText = "Not Enough data to plot";
                }
            }
        }
        catch (Exception e)
        {

        }
    }
}