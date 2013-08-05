using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using App_Code.FetchingEnergyss;
using App_Code.Utility;

public partial class Users_front : System.Web.UI.Page
{
    public static int meterId;
    public static string deviceId;
    public float[] energyArray = new float [14];

    protected void logOut_Click(object sender, EventArgs e)
    {
        Session["UserName"] = null;
        Response.Redirect("~/Loggin.aspx");
    }
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
        CheckLogin();
        if (Session["MeterID"] != null && Session["DeviceID"] != null)
        {
            meterId = Convert.ToInt32(Session["MeterID"]);
            deviceId = Session["DeviceID"].ToString();
        }
        else
        {
            Response.Write("<script>alert('Sorry! Your Meter is not registered yet.');</script>");
        }

        DateTime fromTime = DateTime.Now.AddDays(-7);
        List<int> epochs = Utilitie_S.Return_Bar_Time(fromTime, "7Days");
        if (epochs != null)
        {
            List<FetchingEnergy> energyObject = FetchingEnergy_s.fetchEnergyBar(epochs, meterId, deviceId);
            if (energyObject != null)
            {
                generateDashs(energyObject);

            }
        }

        Utilities ut1=Utilitie_S.DateTimeToEpoch(DateTime.Today.AddDays(-2));

        Utilities ut2=Utilitie_S.DateTimeToEpoch(DateTime.Today.AddDays(-1));

        List<FetchingEnergy> ftList = FetchingEnergy_s.fetchBillingData(ut1.Epoch, ut2.Epoch, meterId, deviceId);
        string str1 = "", str2 = "";
        if (ftList != null)
        {
            str1 = "Previous day (" + DateTime.Now.AddDays(-1).ToString("dd MMM yyyy") + "), You! have consumed <font color='#f18221'>" + (ftList[1].FwdHr - ftList[0].FwdHr).ToString() + " Whrs </font>";
        }
        List<FetchingEnergy> ft = FetchingEnergy_s.fetchAVGDashDayEnergy(ut1.Epoch, deviceId,86400);
        if (ft != null)
        {
            float avg = 0;
            int ctr = 0;
            float percent = 0;
            for (int i = 0; i < ft.Count; i++)
            {
                avg = avg +(ft[i].fwdHrFinal- ft[i].FwdHr);
                ctr++;
            }
            avg = avg / ctr;
            percent = ((avg - (ftList[1].FwdHr - ftList[0].FwdHr))/avg)*100;

            if (percent > 0)
            {
                str2 = "which is <font color='#f18221'>" +Convert.ToInt32( percent).ToString() + "% </font> " + " less " + "than " + "your fellow neighbours.";
            }
            else
            {
                str2 = "which is <font color='#f18221'>" +Convert.ToInt32( Math.Abs(percent)).ToString() + "% </font> " + " more " + "than " + "your fellow neighbours.";
            }
            topLine.InnerHtml = str1 + str2;
        }
    }
    protected void generateDashs(List<FetchingEnergy> ft)
    {
        try
        {
            for (int i = ft.Count-1; i >=0; i = i - 1)
            {
                Utilities ut1 = Utilitie_S.EpochToDateTime(ft[i-1].TimeStamp);
                Utilities ut2 = Utilitie_S.EpochToDateTime(ft[i].TimeStamp);

                HtmlGenericControl billDiv = new HtmlGenericControl("div");
                billDiv.ID = "billDiv" + i;
                billDiv.Attributes.Add("class", "bill-wrapper");

                HtmlGenericControl hday = new HtmlGenericControl("h3");
                hday.ID = "hday" + i;
                hday.InnerText = ut1.Date.ToString("dd MMM");

                HtmlGenericControl pUnits = new HtmlGenericControl("h2");
                pUnits.ID = "pUnits" + i;
                pUnits.InnerText = (ft[i].FwdHr - ft[i-1].FwdHr).ToString();


                billDiv.Controls.Add(hday);
                billDiv.Controls.Add(pUnits);
                dashes.Controls.Add(billDiv);

            }
        }
        catch (Exception e)
        {

        }
    }
}