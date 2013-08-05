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

public partial class TrackBill : System.Web.UI.Page
{
    public static int meterId;
    public static string deviceId;

    protected void CheckLogin()
    {
        if (Session["UserName"] == null || Session["UserName"] == "")
        {
            Response.Redirect("~/Loggin.aspx");
        }
        else
        {
            nameTitle.InnerText = "Welcome " + Session["UserName"].ToString();

        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Heading.InnerText = "Monthly Consumption";
        
        CheckLogin();
        if (Session["MeterID"] != null && Session["DeviceID"] != null)
        {
            meterId = Convert.ToInt32(Session["MeterID"]);
            deviceId = Session["DeviceID"].ToString();
          
            GenerateBillingDiv();
        }
        else
        {
            Response.Write("<script>alert('Sorry! Your Meter is not registered yet.');</script>");
            //Session["UserName"] = null;
            //Response.Redirect("LoginPage.aspx");
        }
    }
    protected void GenerateBillingDiv()
    {
        List<int> epochs = Utilitie_S.LastDashMonths(6);
        for (int i = 0; i < epochs.Count; i=i+2)
        {
            List<FetchingEnergy> ft = FetchingEnergy_s.fetchBillingData(epochs[i], epochs[i + 1], meterId, deviceId);
            if (ft != null)
            {
                
                try
                {
                    Utilities ut1 = Utilitie_S.EpochToDateTime(ft[i].TimeStamp);
                    Utilities ut2 = Utilitie_S.EpochToDateTime(ft[i+1].TimeStamp);

                    HtmlGenericControl billDiv = new HtmlGenericControl("div");
                    billDiv.ID = "billDiv" + i;
                    billDiv.Attributes.Add("class", "bill-wrapper");

                    HtmlGenericControl hmonth = new HtmlGenericControl("h2");
                    hmonth.ID = "hmonth" + i;
                    hmonth.InnerText= ut1.Date.ToString("MMM");

                    HtmlGenericControl pUnits = new HtmlGenericControl("p");
                    pUnits.ID = "pUnits" + i;
                    pUnits.InnerText = "Units Consumed: " + (ft[i+1].FwdHr - ft[i].FwdHr).ToString() + " Units";

                    HtmlGenericControl pPrice = new HtmlGenericControl("p");
                    pPrice.ID = "pPrice" + i;
                    pPrice.InnerText = "Unit Price: 5Rs/unit";

                    HtmlGenericControl br = new HtmlGenericControl("hr");
                    br.ID = "br" + i;

                    HtmlGenericControl hTotal = new HtmlGenericControl("h3");
                    hTotal.ID = "hTotal" + i;
                    hTotal.InnerText = "Total: " + ( Math.Round( 5 * (ft[i+1].FwdHr - ft[i].FwdHr),2)).ToString() + " Rs";


                    billDiv.Controls.Add(hmonth);
                    billDiv.Controls.Add(pUnits);
                    billDiv.Controls.Add(pPrice);
                    billDiv.Controls.Add(br);
                    billDiv.Controls.Add(hTotal);
                    billingContainer.Controls.Add(billDiv);

                    subHeading.InnerText = "";
                }
                catch (Exception e)
                {

                }
            }
            else
            {
                subHeading.InnerText = "";
            }
           
        }

    }

    protected void logOut_Click(object sender, EventArgs e)
    {
        Session["UserName"] = null;
        Response.Redirect("~/Loggin.aspx");
    }
}