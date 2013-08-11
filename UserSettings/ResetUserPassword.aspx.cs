using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App_Code.Login;

public partial class UserSettings_ResetUserPassword : System.Web.UI.Page
{

    protected void CheckLogin()
    {
        if (Session["UserName"] == null || Session["UserName"] == "")
        {
            Response.Redirect("~/Loggin.aspx");
        }
        else
        {
            username.Text = Session["UserName"].ToString();
        }
       
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckLogin();
       
    }
    protected void changeUsername_Click(object sender, EventArgs e)
    {
        Guid uid = new Guid(Session["UserID"].ToString());

        UserLogin checkit = UserLogin_S.Loging(newUsername.Text);
        if (checkit == null)
        {

            UserLogin newUser = new UserLogin();

            newUser.UserName = newUsername.Text;
            newUser.UserId = uid;

            bool upd = UserLogin_S.ResetUsername(newUser);

            if (upd == true)
            {
                green0.Text = "Updated";
                Session["UserName"] = newUsername.Text;
                username.Text = newUsername.Text; 
            }
            else
            {
                green0.Text = "Something went wrong!";
                
            }
            valid.Text = "";
        }
        else
        {
            valid.Text = "Not-Available";
            green0.Text = "";
        }
    }
    protected void resetPassword_Click(object sender, EventArgs e)
    {
        Guid uid = new Guid(Session["UserID"].ToString());

        UserLogin checkit = UserLogin_S.NewLoging(username.Text, psHidOld.Value);

        if (checkit != null)
        {
            UserLogin newPwdUser = new UserLogin();

            newPwdUser.Password = psHid.Value;
            newPwdUser.UserId = uid;
            newPwdUser.PasswordStatus = "done"; 

            bool upd = UserLogin_S.ResetPassword(newPwdUser);

            if (upd == true)
            {
                green1.Text = "Updated";
            }
            else
            {
                green1.Text = "Something went wrong!";
            }
            pwdCheck.Text = "";
        }
        else
        {
            pwdCheck.Text = "Wrong-Password";
            green1.Text = "";
        }
    }
    protected void newUsername_TextChanged(object sender, EventArgs e)
    {

    }
}