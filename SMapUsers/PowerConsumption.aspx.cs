using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
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
    public string[] meterIDs;
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
        if (Session["MeterType"] != null && Session["Apartment"] != null && Session["Building"] != null)
        {
            building = Session["Building"].ToString();
            apartment = Session["Apartment"].ToString();
        }
        else
        {
            Response.Write("<script>alert('Sorry! Your Meter is not registered yet.');</script>");
        }
        if (IsPostBack == false)
        {
            try
            {
                Populate_DeviceList();
                Populate_Meters();
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
        
        Plot_Line_Graph();
    }

    protected void Plot_Line_Graph()
    {
        try
        {
            string meter_id = meterTypeList.SelectedValue;

            DateTime frDate = DateTime.Now.AddMinutes(-1440);
            DateTime tDate = DateTime.Now;

            string frTime = frDate.ToString("MM/dd/yyyy HH:mm");
            string tTime = tDate.ToString("MM/dd/yyyy HH:mm");

            Utilities utFr = Utilitie_S.DateTimeToEpoch(frDate);
            Utilities utTo = Utilitie_S.DateTimeToEpoch(tDate);

           
            FetchEnergyDataS_Map.FetchPowerConsumption(frTime, tTime, apartment, meter_id, out timeSt, out energyArray);

            for (int i = 0; i < energyArray.Length; i++)
            {
                energyArray[i] = Math.Round(energyArray[i], 2);
            }

            interval = timeSt[timeSt.Length - 1] - timeSt[0];
            startDate = timeSt[0];

            List<DeviceAnnotations> annonations = Device_Annotations.GettingAnnotations(utFr.Epoch, utTo.Epoch, Convert.ToInt32(meterTypeList.SelectedValue), building);
           
                Table annonateTable = new Table();
                annonateTable.ID = "datatable";
                annonateTable.Style.Add("display", "none");

                TableHeaderRow tableHead = new TableHeaderRow();
                tableHead.TableSection = TableRowSection.TableHeader;
                annonateTable.Rows.Add(tableHead);

                TableHeaderCell thcell1 = new TableHeaderCell();
                tableHead.Cells.Add(thcell1);

                TableHeaderCell thcell2 = new TableHeaderCell();
                thcell2.Text = "Power Consumption";
                tableHead.Cells.Add(thcell2);
                annonateTable.Rows.Add(tableHead);

                if (annonations != null)
                {
                    foreach (DeviceAnnotations annonator in annonations)
                    {
                        TableHeaderCell thcell = new TableHeaderCell();
                        thcell.Text = annonator.Device;
                        tableHead.Cells.Add(thcell);
                    }
                }

                for (int k = 0; k < timeSt.Length; k++)
                {
                    TableRow row = new TableRow();
                    row.TableSection = TableRowSection.TableBody;

                    TableHeaderCell rowHead = new TableHeaderCell();
                    rowHead.Text = (Convert.ToDouble(timeSt[k])*1000).ToString();
                    row.Cells.Add(rowHead);
                    
                    if (annonations != null)
                    {
                        int kt = 100;
                        foreach (DeviceAnnotations annonator in annonations)
                        {
                            kt =  kt+100;
                           
                            TableCell cell = new TableCell();
                            if (annonator.FromTime >= timeSt[k] || annonator.ToTime <= timeSt[k])
                            {
                                cell.Text = (0).ToString();
                            }
                            else
                            {
                                cell.Text = (kt).ToString();
                            }
                            row.Cells.Add(cell);
                        }
                    }
                    TableCell readingCell = new TableCell();
                    readingCell.Text = energyArray[k].ToString();
                    row.Cells.Add(readingCell);
                    annonateTable.Rows.Add(row);
                }

                tableContainer.Controls.Clear();
                tableContainer.Controls.Add(annonateTable);
            
            
            
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
            annonateObj.MeterId =Convert.ToInt32( meterTypeList.SelectedValue);
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
                annonateObj.MeterId = Convert.ToInt32(meterTypeList.SelectedValue);
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

    protected void Populate_Meters()
    {
        meterTypeList.Items.Clear();
        string supplyType = "";
        string demo="";
        FetchEnergyDataS_Map.ListingMeterIDsByApartment(building, apartment, out meterIDs);
        foreach (string id in meterIDs)
        {
            FetchEnergyDataS_Map.GetMeterLocationByID(id, building,out demo,out demo, out demo, out demo, out demo,out supplyType);
            meterTypeList.Items.Add(new ListItem(supplyType+"-"+id, id));
            meterTypeList.SelectedValue = id;
        }
    }
}