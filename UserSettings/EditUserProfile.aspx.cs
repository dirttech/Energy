using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App_Code.Login;

public partial class UserSettings_EditUserProfile : System.Web.UI.Page
{

    protected void CheckLogin()
    {
        if (Session["UserName"] == null || Session["UserName"] == "")
        {
            Response.Redirect("~/Loggin.aspx");
        }
        else
        {
            usrname.Text = Session["UserName"].ToString();
        }

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckLogin();
        if (IsPostBack == false)
        {
            UserLogin mapLogin = UserLogin_S.Loging(Session["UserName"].ToString());

            if (mapLogin != null)
            {
                apartment.Text = mapLogin.Apartment;
                building.Text = mapLogin.Building;
                fullname.Text = mapLogin.FullName;
                contact.Text = mapLogin.Mobile;
                email.Text = mapLogin.EMail;
                fullname.Focus();
            }
        }


    }
    protected void skipping_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Loggin.aspx");

    }
    protected void saving_Click(object sender, EventArgs e)
    {
        UserLogin updateProfile = new UserLogin();

        updateProfile.EMail = email.Text;
        updateProfile.FullName = fullname.Text;
        updateProfile.Mobile = contact.Text;
        updateProfile.UserId =new Guid( Session["UserID"].ToString());

        bool stc = UserLogin_S.UpdateProfile(updateProfile);
        if (stc == true)
        {
           Response.Redirect("~/Loggin.aspx");
           
        }
        else
        {
            green0.Text = "Something went wrong!";
        }
    }
}