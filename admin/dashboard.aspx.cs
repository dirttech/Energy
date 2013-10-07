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
    public double[][] a2D;
    public int[] timeArray;
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
       
            GenerateMeterList();
            Plot_ALL_Graph();
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

            var primeArray = selectedBoxes.Value.Split(',');
            a2D = new double[primeArray.Length-1][];

            for (int i = 0; i < primeArray.Length-1; i++)
            {
                double[] temp;
                int[] tmp;
                FetchEnergyDataS_Map.GetParamByIDBuilding(primeArray[i].ToString(), criteriaList.SelectedItem.Text, buildingList.SelectedItem.Text, frTime, tTime, out temp,out tmp);
                a2D[i] = temp;
            }
       
        }
        catch (Exception e)
        {

        }

    }

    protected void GenerateMeterList()
    {
        string[] meterIDs;
        FetchEnergyDataS_Map.ListingBuildingMeter(buildingList.SelectedItem.Text, out meterIDs);
        if (meterIDs != null)
        {
            for(int i=0;i<meterIDs.Length;i++)
            {
                CheckBox check = new CheckBox();
                check.ID = "check" + i;
                check.Attributes.Add("MeterId", meterIDs[i].ToString());
                check.Text= meterIDs[i].ToString();
                if (i == 0)
                {
                    check.Checked = true;
                }
                checkboxDiv.Controls.Add(check);

                HtmlGenericControl hr = new HtmlGenericControl("hr");
                hr.Style.Add("margin", "0px");
                checkboxDiv.Controls.Add(hr);
            }
        }
    }

}