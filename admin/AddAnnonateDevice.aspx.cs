using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App_Code.AnnonationCategories;

public partial class admin_AddAnnonateDevice : System.Web.UI.Page
{
    protected void CheckLogin()
    {
        if (Session["AdminUserName"] == null || Session["AdminUserName"] == "")
        {
            Response.Redirect("adminLogin.aspx");
        }
        else
        {

        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckLogin();
    }
    protected void addingDevice_Click(object sender, EventArgs e)
    {
        DeviceCategories obj = new DeviceCategories();
        obj.DeviceName = deviceName.Text;
        obj.Description = deviceDesc.Text;
        obj.CreatedBy = "Admin";
        bool sts = Device_Categories.InsertAnnonations(obj);
        if (sts == true)
        {
            msg.Text = "Added Succesfully!";
        }
        else
        {
            msg.Text = "Something went wrong!";
        }
    }
}