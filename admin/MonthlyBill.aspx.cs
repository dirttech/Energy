using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using App_Code.FetchingEnergyss;
using App_Code.Login;
using App_Code.User_Mapping;
using App_Code.Utility;

public partial class MonthlyBill : System.Web.UI.Page
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


    protected void classic_Click(object sender, EventArgs e)
    {
        belowFrame.Attributes.Add("src", "SMapClassicBill.aspx");
    }

    protected void modern_Click(object sender, EventArgs e)
    {
        belowFrame.Attributes.Add("src", "SMapModernBill.aspx");
    }

    protected void latest_Click(object sender, EventArgs e)
    {
        belowFrame.Attributes.Add("src", "");
    }

}
