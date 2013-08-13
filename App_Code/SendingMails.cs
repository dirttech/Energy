using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using App_Code.Login;

namespace App_Code.SendMail
{
public static class SendingMails
{
    public static void SendRegistrationMail(UserLogin confirmObj, string pass)
    {
        var fromaddr = "energy.iiitd@gmail.com";
        var toaddr = confirmObj.EMail;
        const string fromPassword = "iamback@IIITD";
        string  subject = "Confirmation of your apartment registration for energy dashboard";
        string  body = "Congratulations! We have confirmed your apartment registration for our energy dashboard." + "\n";
        body += "Username: " + confirmObj.UserName + "\n";
        body += "Password: " + pass + "\n";
        body += "Login @ http://energy.iiitd.edu.in";

        //body += "Email: " + "Inderpals@iiitd.ac.in" + "\n";
        //body += "Subject: " + "Confirmation of your apartment registration for energy dashboard";

        var smtp = new System.Net.Mail.SmtpClient();
        {
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(fromaddr, fromPassword);
            smtp.Timeout = 20000;
        }
        smtp.Send(fromaddr, toaddr, subject, body);


        }
    public static void SendMail(string to, string subject, string body)
    {
        var fromaddr = "energy.iiitd@gmail.com";
        var toaddr = to;
        const string fromPassword = "iamback@IIITD";
      
        var smtp = new System.Net.Mail.SmtpClient();
        {
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(fromaddr, fromPassword);
            smtp.Timeout = 20000;
        }

        smtp.Send(fromaddr, toaddr, subject, body);
       


    }
    }
}
