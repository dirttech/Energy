using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App_Code.AdminLoginss;

public partial class admin_adminLogin : System.Web.UI.Page
{
    protected void CheckLogin()
    {
        if (Session["AdminUserName"] == null || Session["AdminUserName"] == "")
        {
           
        }
        else
        {
            Response.Redirect("adminPanel.aspx");
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        CheckLogin();
    }
    protected void loginUser_Click(object sender, EventArgs e)
    {
        AdminLogin adminObject = AdminLogin_S.NewLoging(usrName.Value, pwd.Value);
        if (adminObject != null)
        {
            Session["AdminUserName"] = usrName.Value;

            Response.Redirect("adminPanel.aspx");
        }
        else
        {
            msg.Text = "Wrong Username/Password";
        }
    }


}