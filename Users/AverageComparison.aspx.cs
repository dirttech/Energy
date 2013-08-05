using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;
using App_Code.FetchingEnergyss;
using App_Code.Utility;
using App_Code.User_Mapping;
using System.Web.Script.Serialization;

public partial class AverageComparison : System.Web.UI.Page
{
    public JavaScriptSerializer javaSerial = new JavaScriptSerializer();
    public float[,] energyArray;
    public double[,] realEnergyArray;
    public double[,] totalEnergyArray;
    public int[] timeArray;
    public static int meterId;
    public static string deviceId;
    public static string[] timeSeries;
    public double[,] realAvgEnergyArr;

    public static string apartment = "";
    public static string meterType="";
    public static string building = "";

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
        if (Session["MeterID"] != null && Session["DeviceID"] != null)
        {
            apartment = Session["Apartment"].ToString();
            meterType = Session["MeterType"].ToString();

            Heading.InnerText = hiddenHeadingType.Value;
            if (IsPostBack == false)
            {
                DateTime frDate = DateTime.Today.AddDays(-7);
             
                Utilities ut1 = Utilitie_S.DateTimeToEpoch(frDate);
                
                Heading.InnerText = "Last 7 Days";
                List<int> epochs = new List<int>();
                epochs = Utilitie_S.Return_Bar_Time(frDate, "7Days");
                Plot_Line_Graph(epochs);
            }
        }
        else
        {
            Response.Write("<script>alert('Sorry! Your Meter is not registered yet.');</script>");
            //Session["UserName"] = null;
            //Response.Redirect("LoginPage.aspx");
        }
    }

    protected void Plot_Line_Graph(List<int> epochs)
    {
        try
        {
            List<FetchingEnergy> energyObj = FetchingEnergy_s.fetchEnergyBar(epochs, meterId, deviceId);

           
            int count = energyObj.Count;
            energyArray = new float[count,2];
            timeArray = new int[count];
            realEnergyArray = new double[count, 2];
            for (int i = 0; i < count - 1; i++)
            {
                energyArray[i,1] = energyObj[i+1].FwdHr - energyObj[i].FwdHr;
                realEnergyArray[i, 1] = energyArray[i,1];
                energyArray[i, 0] = energyObj[i].TimeStamp;
                timeArray[i] = energyObj[i].TimeStamp;
                realEnergyArray[i, 0] = energyObj[i].TimeStamp;
                      

            }
            timeSeries = Utilitie_S.TimeFormatter(timeArray);

            List<UserMapping> allMeters = UserMapping_S.ListAllMeters(building, meterType);
            if (allMeters != null)
            {
                int meterTotal = allMeters.Count;
                int [] meterArr = new int[meterTotal];
                for(int p=0;p<meterTotal;p++)
                {
                    meterArr[p]=allMeters[p].MeterId;
                }
                List<FetchingEnergy> avgEnergyObj1 = FetchingEnergy_s.fetchAVGBar(epochs, deviceId);
                if (avgEnergyObj1 != null)
                {
                     List<FetchingEnergy> avgEnergyObj = avgEnergyObj1.OrderBy(o => o.TimeStamp).ToList();
                     int cont = avgEnergyObj.Count;
                     int prevTime = 0;
                         
                        totalEnergyArray = new double[cont, 3];
                        prevTime = avgEnergyObj[0].TimeStamp;
                        int counter = 0, higherCounter = 0;
                        foreach (int mId in meterArr)
                        {  
                            
                            for (int j = 0; j < cont; j++)
                            {
                                                         
                                prevTime = avgEnergyObj[j].TimeStamp;
                                if (avgEnergyObj[j].MeterId==mId)
                                {
                                    if (totalEnergyArray[j, 1] < 1 && higherCounter==0)
                                    {   
                                        double diff = avgEnergyObj[j].FwdHr;
                                        totalEnergyArray[counter, 0] = totalEnergyArray[counter, 0] + diff;
                                        totalEnergyArray[counter, 1] = 1;
                                        totalEnergyArray[counter, 2] = avgEnergyObj[j].TimeStamp;

                                        counter++;
                                    }

                                    else
                                    {
                                        for (int kt = 0; kt < cont; kt++)
                                        {
                                            double match=totalEnergyArray[kt, 2];
                                            
                                            if (avgEnergyObj[j].TimeStamp == match)
                                            {
                                                totalEnergyArray[kt, 0] = totalEnergyArray[kt,0]+ avgEnergyObj[j].FwdHr;
                                                totalEnergyArray[kt, 1] = totalEnergyArray[kt, 1] + 1;
                                            }
                                        
                                        }
                                    }
                                }   
                            }
                            higherCounter = 1;
                       }
                        int checkLength = 0;
                        for (int check = 0; check < (totalEnergyArray.Length/3); check++)
                        {
                            if (totalEnergyArray[check, 2] > 0)
                            {
                                checkLength++;
                            }
                        }
                        realAvgEnergyArr = new double[checkLength-1,2];
                        for (int m = 0; m < checkLength-1; m++)
                        {
                            realAvgEnergyArr[m, 1] = (totalEnergyArray[m + 1, 0] / totalEnergyArray[m+1, 1]) - (totalEnergyArray[m, 0] / totalEnergyArray[m, 1]);

                            realAvgEnergyArr[m, 0] = totalEnergyArray[m, 2];
                        }
                }
            }


        }
        catch (Exception e)
        {

        }

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

        Plot_Line_Graph(epochs);
    }

    protected void logOut_Click(object sender, EventArgs e)
    {
        Session["UserName"] = null;
        Response.Redirect("~/Loggin.aspx");
    }

    protected void Stack_Click(object sender, EventArgs e)
    {
        hiddenPlotType.Value = "normal";
        Plotting_Click();
    }

    protected void Normal_Click(object sender, EventArgs e)
    {
        hiddenPlotType.Value = null;
        Plotting_Click();
    }
}