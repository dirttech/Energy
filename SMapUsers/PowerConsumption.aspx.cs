using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App_Code.FetchingEnergySmap;
using App_Code.Utility;
using System.Web.Script.Serialization;
using WebAnalytics;
using App_Code.AnnonationCategories;
using App_Code.AnnotateDevice;

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
    protected void addCustom_Click(object sender, EventArgs e)
    {
        newDeviceTable.Visible = true;
        draggable.Style.Add("display", "block");
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckLogin();
        if (IsPostBack == false)
        {
            try
            {
                Populate_DeviceList();

                WebAnalytics.LoggerService LG = new LoggerService();

                LoggingEvent logObj = new LoggingEvent();
                logObj.EventID = "Power Consumption Page";
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
        try
        {
            WebAnalytics.LoggerService LG = new LoggerService();

            LoggingEvent logObj = new LoggingEvent();
            logObj.EventID = "Power Consumption meter change to : "+meterTypeList.SelectedItem.Text;
            logObj.UserID = Session["UserID"].ToString();
            bool sts = LG.LogEvent(logObj);

        }
        catch (Exception exp)
        {

        }

        Plot_Line_Graph();


    }
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
    protected void annotateButton_Click(object sender, EventArgs e)
    {

        if (newDeviceTable.Visible == false)
        {
            DeviceAnnotations annonateObj = new DeviceAnnotations();
            annonateObj.FromTime = Convert.ToInt32(frmTime.Text);
            annonateObj.ToTime = Convert.ToInt32(tTime.Text);
            annonateObj.MeterId = 1;
            annonateObj.building = Session["Building"].ToString();
            annonateObj.Device = deviceList.SelectedItem.Text;
            bool stat = Device_Annotations.InsertAnnotations(annonateObj);
            if (stat == true)
            {
                msg.Text = "Annotation Completed!";
                frmTime.Text = ""; tTime.Text = "";
            }
            else
            {
                msg.Text = "Something went wrong!";
            }
        }
        else
        {
            DeviceCategories deviceObj = new DeviceCategories();
            deviceObj.CreatedBy = Session["UserID"].ToString();
            deviceObj.DeviceName = newDeviceText.Text;
            deviceObj.Description = newDeviceDesc.Text;
            bool sts = Device_Categories.InsertAnnonations(deviceObj);
            if (sts == true)
            {
                msg.Text = "Something went wrong with annotation! Device Added.";
                DeviceAnnotations annonateObj = new DeviceAnnotations();
                annonateObj.FromTime = Convert.ToInt32(frmTime.Text);
                annonateObj.ToTime = Convert.ToInt32(tTime.Text);
                annonateObj.MeterId = 1;
                annonateObj.building = Session["Building"].ToString();
                annonateObj.Device = newDeviceText.Text;
                bool stc = Device_Annotations.InsertAnnotations(annonateObj);
                if (stc == true)
                {
                    msg.Text = "Annotation Completed!";
                    newDeviceTable.Visible = false;
                    frmTime.Text = ""; tTime.Text = "";
                }
                Populate_DeviceList();
                
            }
            else
            {
                msg.Text = "Something went wrong!";
            }
        }
    }
    protected void Populate_DeviceList()
    {
        deviceList.Items.Clear();
        List<DeviceCategories> deviceListing = Device_Categories.GetAnnonationCategories(Session["UserID"].ToString());
        if (deviceListing != null)
        {
            for (int i = 0; i < deviceListing.Count; i++)
            {
                deviceList.Items.Add(deviceListing[i].DeviceName);
            }
        }
    }
}