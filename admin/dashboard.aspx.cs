using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using App_Code.FetchingEnergySmap;
using App_Code.Utility;
using System.Web.Script.Serialization;

public partial class admin_dashboard : System.Web.UI.Page
{
    public JavaScriptSerializer javaSerial = new JavaScriptSerializer();

    public int[] timeArray1;
    public double[] valueArray1;
    public int[] timeArray2;
    public double[] valueArray2;
    public int[] timeArray3;
    public double[] valueArray3;
    public int[] timeArray4;
    public double[] valueArray4;
    public int[] timeArray5;
    public double[] valueArray5;
    public string[] midArr;

    public static Int32[] timeSt;
  
    public static int meterId;
    public static string deviceId;
    public static int startDate;
    public static int timeInterval=0;
    public static string[] timeSeries;

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
       // Plot_ALL_Graph();
    }

    protected void submitDate_Click(object sender, EventArgs e)
    {        
        Plot_ALL_Graph();
    }

    protected void Plot_ALL_Graph()
    {
        try
        {
            DateTime frDate = DateTime.Now.AddDays(-1);
            DateTime tDate = DateTime.Now;
            string frTime = "now -1440minutes";
            string tTime = "now";

            if (fromDate.Value != "")
            {
                frDate = DateTime.ParseExact(fromDate.Value + ",000", "dd/MM/yyyy HH:mm:ss,fff",
                                                  System.Globalization.CultureInfo.InvariantCulture);
                frTime = "now -" + (Convert.ToInt32((DateTime.Now - frDate).TotalMinutes)).ToString() + "minutes";
            }
            if (toDate.Value != "")
            {
                tDate = DateTime.ParseExact(toDate.Value + ",000", "dd/MM/yyyy HH:mm:ss,fff",
                                                  System.Globalization.CultureInfo.InvariantCulture);
                tTime = "now -" + (Convert.ToInt32((DateTime.Now - tDate).TotalMinutes)).ToString() + "minutes";
            }
            Utilities ut = Utilitie_S.DateTimeToEpoch(frDate);
            startDate = ut.Epoch;
            Utilities ut2 = Utilitie_S.DateTimeToEpoch(tDate);
            timeInterval = ut2.Epoch - startDate;

            midArr = new string[5];
            midArr[0] = meterTxt1.Text; midArr[1] = meterTxt2.Text; midArr[2] = meterTxt3.Text; midArr[3] = meterTxt4.Text; midArr[4] = meterTxt5.Text;
            FetchEnergyDataS_Map.GetParamByIDBuilding(meterTxt1.Text, criteriaList.SelectedItem.Text,build1.SelectedItem.Text, frTime, tTime, out valueArray1, out timeArray1);
            FetchEnergyDataS_Map.GetParamByIDBuilding(meterTxt2.Text, criteriaList.SelectedItem.Text, build2.SelectedItem.Text, frTime, tTime, out valueArray2, out timeArray2);
            FetchEnergyDataS_Map.GetParamByIDBuilding(meterTxt3.Text, criteriaList.SelectedItem.Text, build3.SelectedItem.Text, frTime, tTime, out valueArray3, out timeArray3);
            FetchEnergyDataS_Map.GetParamByIDBuilding(meterTxt4.Text, criteriaList.SelectedItem.Text, build4.SelectedItem.Text, frTime, tTime, out valueArray4, out timeArray4);
            FetchEnergyDataS_Map.GetParamByIDBuilding(meterTxt5.Text, criteriaList.SelectedItem.Text, build5.SelectedItem.Text, frTime, tTime, out valueArray5, out timeArray5);               

        }
        catch (Exception e)
        {

        }

    }

    //protected void GenerateMeterList()
    //{
    //    string[] meterIDs;
    //    FetchEnergyDataS_Map.ListingBuildingMeter(buildingList.SelectedItem.Text, out meterIDs);
    //    if (meterIDs != null)
    //    {
    //        for (int i = 0; i < meterIDs.Length; i++)
    //        {
    //            CheckBox check = new CheckBox();
    //            check.ID = "check" + i;
    //            check.Attributes.Add("MeterId", meterIDs[i].ToString());
    //            check.Text = meterIDs[i].ToString();
    //            if (i == 0)
    //            {
    //                check.Checked = true;
    //            }
    //            checkboxDiv.Controls.Add(check);

    //            HtmlGenericControl hr = new HtmlGenericControl("hr");
    //            hr.Style.Add("margin", "0px");
    //            checkboxDiv.Controls.Add(hr);
    //        }
    //    }
    //}

}