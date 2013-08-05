using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using App_Code.FetchingEnergyss;
using App_Code.FetchingEnergySmap;
using App_Code.Utility;

public partial class Users_front : System.Web.UI.Page
{
    public float[] energyArray = new float [14];

    public int[] timeSample;
    public string[] fromTimeArray;
    public string[] toTimeArray;

    public static string apartment = "";
    public static string meter_type = "Power";
    public static string meter_type2 = "Light Backup";
    public static string building = "";
    public double[] valueSample;

    protected void logOut_Click(object sender, EventArgs e)
    {
        Session["UserName"] = null;
        Response.Redirect("~/Loggin.aspx");
    }
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
        }
        else
        {
            Response.Write("<script>alert('Sorry! Your Meter is not registered yet.');</script>");
        }

        DateTime fromTime = DateTime.Now.AddDays(-7);
        List<int> epochs = Utilitie_S.Return_Bar_Time(fromTime, "7Days");
        
       
        if (epochs != null)
        {
            fromTimeArray = new string[epochs.Count];
            toTimeArray = new string[epochs.Count];
            List<int> toEpochs = new List<int>();
            for(int j=0;j<epochs.Count-1;j++)
            {
                toEpochs.Add(epochs[j] + (epochs[1] - epochs[0]));
            }

            fromTimeArray = Utilitie_S.SMapValidDateFormatter(epochs);
            toTimeArray = Utilitie_S.SMapValidDateFormatter(toEpochs);

            int[] timeSample2;
            double[] valueSample2;

            FetchEnergyDataS_Map.FetchBarConsumption(fromTimeArray, toTimeArray, apartment, meter_type, out timeSample, out valueSample);
            FetchEnergyDataS_Map.FetchBarConsumption(fromTimeArray, toTimeArray, apartment, meter_type2, out timeSample2, out valueSample2);
            Utilitie_S.MeterReadingsMerger(timeSample, timeSample2, valueSample, valueSample2, out timeSample, out valueSample);

            
            if (valueSample.Length>0)
            {
                generateDashs(timeSample, valueSample);

            }
        }

        double[] energyValues;
        int[] timeStmp;
        double[] energyValues2;
        int[] timeSt2;

        string[] frmArr = new string[2];
        frmArr[0]=DateTime.Today.AddDays(-1).ToString("MM/dd/yyyy HH:mm");
        frmArr[1] = DateTime.Today.ToString("MM/dd/yyyy HH:mm");

            
        string[] toArr=new string[2];
        toArr[0]=DateTime.Today.AddDays(-1).AddHours(1).ToString("MM/dd/yyyy HH:mm");
        toArr[1]=DateTime.Today.AddHours(1).ToString("MM/dd/yyyy HH:mm");

        FetchEnergyDataS_Map.FetchBarConsumption(frmArr, toArr , apartment, meter_type, out timeStmp, out energyValues);
        FetchEnergyDataS_Map.FetchBarConsumption(frmArr, toArr, apartment, meter_type2, out timeSt2, out energyValues2);
        Utilitie_S.MeterReadingsMerger(timeStmp, timeSt2, energyValues, energyValues2, out timeStmp, out energyValues);
 
        string str1 = "", str2 = "";
        if (energyValues.Length==2)
        {
            str1 = "Previous day (" + DateTime.Now.AddDays(-1).ToString("dd MMM yyyy") + "), You! have consumed <font color='#f18221'>" + (energyValues[1] - energyValues[0]).ToString() + " Whrs </font>";
        }

        double[] avgEnergyValues;
        int[] avgTimeStmp;
        double[] avgEnergyValues2;
        int[] avgTimeStmp2;

        FetchEnergyDataS_Map.FetchAvgConsumption(frmArr, toArr, building, meter_type, out avgTimeStmp, out avgEnergyValues);
        FetchEnergyDataS_Map.FetchAvgConsumption(frmArr, toArr, building, meter_type2, out avgTimeStmp2, out avgEnergyValues2);
        Utilitie_S.MeterReadingsMerger(avgTimeStmp, avgTimeStmp2, avgEnergyValues, avgEnergyValues2, out avgTimeStmp, out avgEnergyValues);

        if (avgEnergyValues.Length==2 && energyValues.Length==2)
        {
            double avg = avgEnergyValues[1] - avgEnergyValues[0];
            
            double percent = 0;
         
            percent = ((avg - (energyValues[1] - energyValues[0]))/avg)*100;

            percent = Math.Round(percent, 2, MidpointRounding.ToEven);

            if (percent > 0)
            {
                str2 = "which is <font color='#f18221'>" +Convert.ToDouble( percent).ToString() + "% </font> " + " less " + "than " + "your fellow neighbours.";
            }
            else
            {
                str2 = "which is <font color='#f18221'>" +Convert.ToDouble( Math.Abs(percent)).ToString() + "% </font> " + " more " + "than " + "your fellow neighbours.";
            }
           
        }
        topLine.InnerHtml = str1 + str2;
    }
    protected void generateDashs(int[] timeSample, double[] valueSample)
    {
        try
        {
            for (int i = valueSample.Length-1; i >=0; i = i - 1)
            {
                if (timeSample[i - 1] > 0)
                {
                    Utilities ut1 = Utilitie_S.EpochToDateTime(timeSample[i - 1]);
                    Utilities ut2 = Utilitie_S.EpochToDateTime(timeSample[i]);

                    HtmlGenericControl billDiv = new HtmlGenericControl("div");
                    billDiv.ID = "billDiv" + i;
                    billDiv.Attributes.Add("class", "bill-wrapper");

                    HtmlGenericControl hday = new HtmlGenericControl("h3");
                    hday.ID = "hday" + i;
                    hday.InnerText = ut1.Date.ToString("dd MMM");

                    HtmlGenericControl pUnits = new HtmlGenericControl("h2");
                    pUnits.ID = "pUnits" + i;
                    pUnits.InnerText = (valueSample[i] - valueSample[i - 1]).ToString();


                    billDiv.Controls.Add(hday);
                    billDiv.Controls.Add(pUnits);
                    dashes.Controls.Add(billDiv);
                }

            }
        }
        catch (Exception e)
        {

        }
    }
}