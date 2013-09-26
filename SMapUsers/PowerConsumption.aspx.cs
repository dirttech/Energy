using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App_Code.FetchingEnergySmap;
using App_Code.Utility;
using System.Web.Script.Serialization;

public partial class Users_PowerConsumption : System.Web.UI.Page
{
    public JavaScriptSerializer javaSerial = new JavaScriptSerializer();
    public double[] energyArray;
    public int[] timeArray;
    public static Int32[] timeSt;
    public static int interval;

    public static string apartment = "";
    public static string building = "";

    public static int startDate;


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
        Plot_Line_Graph();
    }

    protected void Plot_Line_Graph()
    {
        try
        {
            string meter_type = meterTypeList.SelectedValue;
            meterTypeList.SelectedValue = meter_type;

            string frTime="now -1440minutes";
            string tTime="now";
            string path="/FH-RPi02/Meter32/Power";

            FetchEnergyDataS_Map.FetchPowerConsumption(frTime, tTime, apartment, meter_type, out timeSt, out energyArray);

            for (int i = 0; i < energyArray.Length; i++)
            {
                energyArray[i] = Math.Round(energyArray[i], 2);
            }

            interval = timeSt[timeSt.Length - 1] - timeSt[0];
            startDate = timeSt[0];

        }
        catch (Exception e)
        {

        }

    }

    protected void meterTypeList_SelectedIndexChanged(object sender, EventArgs e)
    {
        Plot_Line_Graph();

    }
    protected void logOut_Click(object sender, EventArgs e)
    {
        Session["UserName"] = null;
        Response.Redirect("~/Loggin.aspx");
    }
}