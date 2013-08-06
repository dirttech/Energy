﻿using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App_Code.Login;
using App_Code.UserRegisterationProcess;
using App_Code.User_Mapping;
using App_Code.SendMail;

public partial class admin_AprooveRegistrationRequests : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

   
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        UserLogin confirmObj = new UserLogin();

        confirmObj.Building = GridView1.SelectedRow.Cells[0].Text;
        confirmObj.Apartment = GridView1.SelectedRow.Cells[1].Text;
        confirmObj.EMail = GridView1.SelectedRow.Cells[2].Text;
        if (GridView1.SelectedRow.Cells[3].Text != "&nbsp;")
        {
            confirmObj.Mobile = GridView1.SelectedRow.Cells[3].Text;
        }
        confirmObj.UserName = confirmObj.Apartment + "-" + confirmObj.Building;
        confirmObj.Password = DateTime.Now.ToString("ddmmyyyyHHmm");


      bool stc =  UserLogin_S.InsertUser(confirmObj);
      if (stc == true)
      {
          UserLogin ul = UserLogin_S.Loging(confirmObj.UserName);

          if (ul != null)
          {
              UserMapping map = new UserMapping();

              map.Apartment = confirmObj.Apartment;
              map.Building = confirmObj.Building;
              map.UserId = ul.UserId;
 
              bool stst = UserMapping_S.UpdateUserIdinMap(map);

              if (stst == true)
              {
                  SendingMails.SendRegistrationMail(confirmObj);

                  UserRegisteration regObj = new UserRegisteration();

                  regObj.Building = GridView1.SelectedRow.Cells[0].Text;
                  regObj.Apartment = GridView1.SelectedRow.Cells[1].Text;
                  regObj.Status = "aprooved";

                  bool stc2 = User_Registration.UpdateRequest(regObj);
                  if (stc2 == true)
                  {
                      msg.Text = "Registered + Mail sent";
                  }
              }
              else
              {
                  msg.Text = "Cannot update mapping table";
              }
          }
         else
         {
             msg.Text = "Something went wrong in-between";
         }
       
         GridView1.DataBind();
      }
      else
      {
          msg.Text = "Cannot register";
      }

    }
}