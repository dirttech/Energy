using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App_Code.Login;
using App_Code.User_Mapping;
using App_Code.Utility;


public partial class LoginPage : System.Web.UI.Page
{
    protected void CheckLogin()
    {
        if (Session["UserName"] == null || Session["UserName"] == "")
        {

        }
        else
        {
            Response.Redirect("~/SMapUsers/front.aspx");
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckLogin();
    }

    protected void loginUser_Click(object sender, EventArgs e)
    {
        UserLogin usr = UserLogin_S.NewLoging(usrName.Value, pwd.Value);
        if (usr != null)
        {
            Session["UserName"] = usrName.Value;

            UserMapping map = UserMapping_S.MapUser(usr.UserId);
            
            if (map != null)
            {
                Session["Apartment"] = map.Apartment;
                Session["MeterType"] = map.MeterType;
                Session["Building"] = map.Building;
                Session["UserID"] = map.UserId;
                
            }

          
            if (usr.PasswordStatus=="pending")
            {
                
               Response.Redirect("~/UserSettings/ResetUserPassword.aspx");
            }
            else
            {
              Response.Redirect("~/SMapUsers/front.aspx");
            }
        }
        else
        {
            msg.Text = "Wrong Username/Password";
        }
    }
}