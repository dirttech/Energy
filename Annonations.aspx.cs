using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App_Code.AnnonationCategories;
using App_Code.AnnotateDevice;

public partial class Annonations : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        Session["Building"] = "Fac";
        Session["UserID"] = "Test";
        if (IsPostBack == false)
        {
            Populate_DeviceList();
        }
    }
    protected void addCustom_Click(object sender, EventArgs e)
    {
        newDeviceTable.Visible = true;
    }
    protected void annonateButton_Click(object sender, EventArgs e)
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
                msg.Text = "Annonation Completed!";
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
                msg.Text = "Something went wrong with annonation! Device Added.";
                DeviceAnnotations annonateObj = new DeviceAnnotations();
                annonateObj.FromTime =Convert.ToInt32( frmTime.Text);
                annonateObj.ToTime = Convert.ToInt32(tTime.Text);
                annonateObj.MeterId = 1;
                annonateObj.building = Session["Building"].ToString();
                annonateObj.Device = newDeviceText.Text;
                bool stc = Device_Annotations.InsertAnnotations(annonateObj);
                if (stc == true)
                {
                    msg.Text = "Annonation Completed!";
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