using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App_Code.FetchingEnergySmap;
using App_Code.Utility;
using System.Web.Script.Serialization;

public partial class CampusDashboardPlot : System.Web.UI.Page
{
    public JavaScriptSerializer javaSerial = new JavaScriptSerializer();
    public double[] energyArray;
    public int[] timeArray;
    public static Int32[] timeSt;
    public static int interval;
    public static string building = "";
    public static string meter_type = "Building Total Mains";
    public static string criteria = "Watts";
    public static int startDate;
    public static string plotType = "";
    public static string unit="";

    protected void Page_Load(object sender, EventArgs e)
    {
        //Response.Write(Session["Building-Selected"]);
        if (Session["Building-Selected"] != null)
        {

            building = Session["Building-Selected"].ToString();
        }
        else
        {
            Response.Write("<script>alert('Sorry! This building is not registered yet.');</script>");

        }
        if (IsPostBack == false)
        {
            paramList.SelectedValue = criteria;
            meterList.SelectedValue = meter_type;
            unit = paramList.SelectedValue;
            plotType = paramList.SelectedItem.Text;

            if (building == "Girls Hostel A")
            {
                wing1.Visible = true;
                wing2.Visible = true;
            }
            else if (building == "Boys Hostel A")
            {
                wing1.Visible = true;
                wing2.Visible = true;
            }
            else
            {
                wing1.Visible = false;
                wing2.Visible = false;
            }

            Plot_Line_Graph(null);
        }
        
    }

    protected void Plot_Line_Graph(string typ)
    {
        try
        {
      

            string frTime = "now -1440minutes";
            string tTime = "now";

            if (typ != null)
            {
                if (fromDate.Value != "")
                {
                    DateTime ftDate = DateTime.ParseExact(fromDate.Value + ",000", "dd/MM/yyyy HH:mm:ss,fff",
                                          System.Globalization.CultureInfo.InvariantCulture);
                   
                    frTime = "now -" +(Convert.ToInt32( (DateTime.Now - ftDate).TotalMinutes)).ToString() + "minutes";
                  
                }
                if (toDate.Value != "")
                {
                    DateTime ttDate = DateTime.ParseExact(toDate.Value + ",000", "dd/MM/yyyy HH:mm:ss,fff",
                                          System.Globalization.CultureInfo.InvariantCulture);

                    tTime = "now -" + (Convert.ToInt32((DateTime.Now - ttDate).TotalMinutes)).ToString() + "minutes";

                }

            }
            unit = paramList.SelectedValue;
            plotType = paramList.SelectedItem.Text;
           
            FetchEnergyDataS_Map.FetchBuildingData(frTime, tTime, building, paramList.SelectedValue, meterList.SelectedValue, out timeSt, out energyArray);

            double en = energyArray[0]; 
                //for (int l = 0; l < energyArray.Length; l++)
                //{
                //   energyArray[l]= energyArray[l] -en;
                //}

            interval = timeSt[timeSt.Length - 1] - timeSt[0];
            startDate = timeSt[0];

        }
        catch (Exception e)
        {

        }

    }
    protected void plotButton_Click(object sender, EventArgs e)
    {
        Plot_Line_Graph("Button");
        

    }
    protected void wing1_Click(object sender, EventArgs e)
    {
        if (building == "Girls Hostel A")
        {
            building = "Girls Hostel BC";
        }
        else if (building == "Boys Hostel A")
        {
            building = "Boys Hostel BC";
        }
       
    }
    protected void wing2_Click(object sender, EventArgs e)
    {
        if (building == "Girls Hostel BC")
        {
            building = "Girls Hostel A";
        }
        else if (building == "Boys Hostel BC")
        {
            building = "Boys Hostel A";
        }
    }
}