using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App_Code.Login;
using App_Code.User_Mapping;

public partial class CreateUser : System.Web.UI.Page
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
    protected void insertUser_Click(object sender, EventArgs e)
    {
        UserLogin usr = UserLogin_S.Loging(usrName.Text);
        if (usr != null)
        {
            if (usr.UserName == usrName.Text)
            {
                Label1.Text = "Not available!";
                usrName.Focus();
            }
            else
            {
                UserLogin newUser = new UserLogin();
                newUser.UserName = usrName.Text;
                newUser.Password = pwd.Text;
                newUser.FullName = fullName.Text;
                UserLogin_S.InsertUser(newUser);
                green.Text = "Registered!";
                Label1.Text = "";
               
            }
        }

        else
        {
                UserLogin newUser = new UserLogin();
                newUser.UserName = usrName.Text;
                newUser.Password = pwd.Text;
                newUser.FullName = fullName.Text;
                newUser.Mobile = mobi.Text;
                newUser.Apartment = addr.Text;
                bool status = UserLogin_S.InsertUser(newUser);
                if (status == true)
                {
                    green.Text = "Registered!";
                    Label1.Text = "";
                   
                }
               
            
        }


        
    }

    

    protected void store_Click(object sender, EventArgs e)
    {
       
    }
}