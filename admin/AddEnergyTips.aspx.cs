using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App_Code.ImportCSV;

public partial class admin_AddEnergyTips : System.Web.UI.Page
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

    protected void importData_Click(object sender, EventArgs e)
    {
        try
        {
            string path = Server.MapPath("~") + "/App_Data/" + DateTime.Now.ToString("dd_MMM_yyyy_HH_mm_") + FileUpload1.FileName;
            if (FileUpload1.HasFile)
            {
                FileUpload1.SaveAs(path);
            }
            string sts = Import_CSVs.ImportEnergyTips(path);
            if (sts == true.ToString())
            {
                green.Text = "Uploaded Successfully";
            }
            else
            {
                green.Text = sts;
            }
        }
        catch (Exception exp)
        {
            green.Text = "Something went wrong! Check your file extension.";
        }
    }

}