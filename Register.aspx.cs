using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App_Code.Login;
using App_Code.User_Mapping;
using App_Code.Utility;
using App_Code.UserRegisterationProcess;


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

    protected void registerUser_Click(object sender, EventArgs e)
    {
        UserLogin usr = UserLogin_S.CheckUserByApartmentBuilding(apartmentList.SelectedValue, "Faculty Housing");
        if (usr == null)
        {
            UserRegisteration regObj = new UserRegisteration();

            regObj.Apartment = apartmentList.SelectedValue;
            regObj.Building = "Faculty Housing";
            regObj.ContactNo = contactNo.Value;
            regObj.Email = email.Text;

           bool stc = User_Registration.InsertRequest(regObj);
           if (stc == true)
           {
               msg.Text = "Registered! We will send you an email.";
           }
           else
           {
               msg.Text = "Your request is being processed.";
           }
            
        }
        else
        {
            msg.Text = "Already Registered!";
        }

        email.Text = "";
        contactNo.Value = "";
    }
}