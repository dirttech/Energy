using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App_Code.SendMail;

public partial class ContactUs : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            SendingMails.SendMail("energy@iiitd.gmail.com", "Contact us form filled by " + names.Text + " (" + contact.Text + ") ", message.Text);

            SqlDataSource1.InsertCommand = "Insert into suggestions (Name, Contact, Message) values ('" + names.Text + "','" + contact.Text + "','" + message.Text + "')";
            SqlDataSource1.Insert();
            msg.Text = "Thanks for contacting us!";
            names.Text = "";
            contact.Text = "";
            message.Text = "";
        }
        catch (Exception exp)
        {
            msg.Text = "Something went wrong!";
        }
    }
}