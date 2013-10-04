using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using App_Code.FetchingEnergySmap;
using App_Code.Login;
using App_Code.User_Mapping;
using App_Code.Utility;
using App_Code.BillCalculate;
using WebAnalytics;

public partial class TrackBill : System.Web.UI.Page
{

    public static string apartment = "";
    public static string meter_type = "";
    public static string building = "";
    
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
        //Heading.InnerText = "";
        
        CheckLogin();
        if (IsPostBack == false)
        {
            try
            {
                WebAnalytics.LoggerService LG = new LoggerService();

                LoggingEvent logObj = new LoggingEvent();
                logObj.EventID = "Track Bill Page";
                logObj.UserID = Session["UserID"].ToString();
                bool sts = LG.LogEvent(logObj);

            }
            catch (Exception exp)
            {

            }
        }
       if (Session["MeterType"] != null && Session["Apartment"] != null && Session["Building"]!=null)
        {
            meter_type = Session["MeterType"].ToString();
            building = Session["Building"].ToString();
            apartment= Session["Apartment"].ToString();
            UserMapping map = UserMapping_S.UserMapWithApartmentBuilding(building, apartment);
            GenerateBillingDiv(map);
        }
        else
        {
            Response.Write("<script>alert('Sorry! Your Meter is not registered yet.');</script>");
            //Session["UserName"] = null;
            //Response.Redirect("LoginPage.aspx");
        }
    }
    protected void GenerateBillingDiv(UserMapping map)
    {
        List<DateTime> initialListing = new List<DateTime>();
        List<DateTime> finalListing = new List<DateTime>();
        Utilitie_S.LastDashMonthsBillDates(6, out initialListing, out finalListing);

        for (int i = 0; i < initialListing.Count;i++ )
        {
            CalculateBill billObj = Calculate_Bill.BillCalculator(initialListing[i], finalListing[i], map.Apartment, "Power", "Light Backup","auto",null,null);
            if (billObj!=null )
            {
                try
                {
                    HtmlGenericControl billDiv = new HtmlGenericControl("div");
                    billDiv.ID = "billDiv" + i;
                    billDiv.Attributes.Add("class", "bill-wrapper");

                    HtmlGenericControl hmonth = new HtmlGenericControl("h2");
                    hmonth.ID = "hmonth" + i;
                    hmonth.InnerText = initialListing[i] .ToString("MMM");

                    HtmlGenericControl pUnits = new HtmlGenericControl("p");
                    pUnits.ID = "pUnits" + i;
                    pUnits.InnerText = "Units Consumed: " + (billObj.TotalUnits).ToString() + " Units";

                    HtmlGenericControl approxUnitPrice = new HtmlGenericControl("p");
                    approxUnitPrice.ID = "app" + i;
                    approxUnitPrice.InnerText = "Approximate (per unit) price: " + Math.Round(billObj.BillAmount / billObj.TotalUnits, 2).ToString();
                    HtmlGenericControl br = new HtmlGenericControl("hr");
                    br.ID = "br" + i;

                    HtmlGenericControl hTotal = new HtmlGenericControl("h3");
                    hTotal.ID = "hTotal" + i;
                    hTotal.InnerText = "Bill Amount: Rs " + billObj.BillAmount.ToString();
                    hTotal.Style.Add("color", "white");

                    billDiv.Controls.Add(hmonth);
                    billDiv.Controls.Add(pUnits);
                    billDiv.Controls.Add(approxUnitPrice);

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
        try
        {
            WebAnalytics.LoggerService LG = new LoggerService();

            LoggingEvent logObj = new LoggingEvent();
            logObj.EventID = "Faculty Log Out";
            logObj.UserID = Session["UserID"].ToString();
            bool sts = LG.LogEvent(logObj);

        }
        catch (Exception exp)
        {

        }
        Session["UserName"] = null;
        Response.Redirect("~/Loggin.aspx");
    }
}