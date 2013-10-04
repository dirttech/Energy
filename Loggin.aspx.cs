using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App_Code.Login;
using App_Code.User_Mapping;
using App_Code.Utility;
using WebAnalytics;


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
        UserLogin();
    }

    protected void UserLogin()
    {
        if (usrName.Value == "testuser")
        {
            if (pwd.Value == "testuser")
            {
                List<UserMapping> allApartments = UserMapping_S.ListAll2to9FloorApartments("Faculty Housing");
                Random rnd=new Random();
                int r=rnd.Next(allApartments.Count);
                UserMapping map = UserMapping_S.UserMapWithApartmentBuilding(allApartments[r].Building, allApartments[r].Apartment);
                if (map != null)
                {
                    Session["UserName"] = "testuser";
                    Session["Apartment"] = map.Apartment;
                    Session["MeterType"] = map.MeterType;
                    Session["Building"] = map.Building;
                    Session["UserID"] = map.UserId;
                    Response.Redirect("~/SMapUsers/front.aspx");
                }
            }
        }
        else
        {
            UserLogin usr = UserLogin_S.NewLoging(usrName.Value, psHid.Value);
            if (usr != null)
            {
                try
                {
                    WebAnalytics.LoggerService LG = new LoggerService();

                    LoggingEvent logObj = new LoggingEvent();
                    logObj.EventID = "Faculty Login";
                    logObj.UserID = usr.UserId.ToString();
                    bool sts = LG.LogEvent(logObj);
                    
                }
                catch (Exception exp)
                {

                }
                Session["UserName"] = usrName.Value;
                UserMapping map = UserMapping_S.MapUser(usr.UserId);
                if (map != null)
                {
                    Session["Apartment"] = map.Apartment;
                    Session["MeterType"] = map.MeterType;
                    Session["Building"] = map.Building;
                    Session["UserID"] = map.UserId;
                }
                if (usr.PasswordStatus == "pending")
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

}

