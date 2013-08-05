using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App_Code.FetchingEnergyss;
using App_Code.Utility;
using System.Web.Script.Serialization;

public partial class Users_PowerConsumption : System.Web.UI.Page
{
    public JavaScriptSerializer javaSerial = new JavaScriptSerializer();
    public float[] energyArray;
    public int[] timeArray;
    public static int meterId;
    public static string deviceId;
    public static string[] timeSeries;
    public static int startDate;
    public static int timeInterval = 0;


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
            meterId = Convert.ToInt32(Session["MeterID"]);
            deviceId = Session["DeviceID"].ToString();

        }
        else
        {
            Response.Write("<script>alert('Sorry! Your Meter is not registered yet.');</script>");

        }
        Plot_Line_Graph();
    }

    protected void Plot_Line_Graph()
    {
        Utilities ut = Utilitie_S.DateTimeToEpoch(DateTime.Now.AddDays(-3));
        startDate = ut.Epoch;
        timeInterval = 86400;
        try
        {
            List<FetchingEnergy> energyObj = FetchingEnergy_s.fetchEnergyALL(startDate, startDate + timeInterval, meterId, deviceId);

            int count = energyObj.Count;
            energyArray = new float[count - 1];
            timeArray = new int[count];

            for (int i = 0; i < count - 1; i++)
            {
                energyArray[i] = energyObj[i + 1].W;
            }


        }
        catch (Exception e)
        {

        }

    }


    protected void logOut_Click(object sender, EventArgs e)
    {
        Session["UserName"] = null;
        Response.Redirect("~/Loggin.aspx");
    }
}