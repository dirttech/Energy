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
    public static string criteria = "Power";
    public static int startDate;
    public static string plotType = "";
    public static string unit="";

    public static string[] energyTimeSeries;
    public double[] barEnergy;
    public int[] barTime;
    

    protected void Page_Load(object sender, EventArgs e)
    {
        //Response.Write(Session["Building-Selected"]);
        months.SelectedValue = DateTime.Now.Month.ToString();

        if (building == "Faculty Housing")
        {
            meterList.Enabled = true;
        }
        else
        {
            meterList.Enabled = false;
        }

        if (IsPostBack == false)
        {
            if (Session["Building-Selected"] != null)
            {

                building = Session["Building-Selected"].ToString();
                Plot_Building_Energy();
            }
            else
            {
                Response.Write("<script>alert('Sorry! This building is not registered yet.');</script>");

            }
            paramList.SelectedValue = criteria;
            meterList.SelectedValue = meter_type;
            unit = paramList.SelectedValue;
            plotType = paramList.SelectedItem.Text;

            if (building == "Girls Hostel AB")
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

            Plot_Building_All(null);
        }
        
    }

    protected void Plot_Building_All(string typ)
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

                    frTime = "now -" + (Convert.ToInt32((DateTime.Now - ftDate).TotalMinutes)).ToString() + "minutes";

                }
                if (toDate.Value != "")
                {
                    DateTime ttDate = DateTime.ParseExact(toDate.Value + ",000", "dd/MM/yyyy HH:mm:ss,fff",
                                          System.Globalization.CultureInfo.InvariantCulture);
                    if (ttDate > DateTime.Now)
                    {
                        ttDate = DateTime.Now;
                    }

                    tTime = "now -" + (Convert.ToInt32((DateTime.Now - ttDate).TotalMinutes)).ToString() + "minutes";

                }

            }
            else
            {
                fromDate.Value = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy HH:mm:ss");
                toDate.Value = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            }
            unit = paramList.SelectedItem.Attributes["units"].ToString();
            plotType = paramList.SelectedItem.Text;

            if (building == "Academic")
            {
                FetchEnergyDataS_Map.FetchBuildingAcademia(frTime, tTime, "Academic Building", paramList.SelectedValue, "Building Total Mains", "Academic Block", out timeSt, out energyArray);
                buildingimg.ImageUrl = "~/images/buildings/academia.png";
                buildInfo.InnerHtml = "<h3>Buiding Information</h3><br /><p>Smart Meter (EM6400) - 1 <a href='AcademicMeterStatus.aspx' style='font-size:large;'>(Meter Status)</a><br />Covered area (on ground) - 1000 sqm";
                buildInfo.InnerHtml+= "<br />Covered area (on floors) - 5638.88 sqm<br />No of storeys - G + 5<br />Height of Building - 23.1 m</p><br />";
              
            }
            if (building == "ClassRooms")
            {
                FetchEnergyDataS_Map.FetchBuildingAcademia(frTime, tTime, "Academic Building", paramList.SelectedValue, "Building Total Mains", "Lecture Block", out timeSt, out energyArray);
                buildingimg.ImageUrl = "~/images/buildings/classrooms.png";
                buildInfo.InnerHtml = "<h3>Buiding Information</h3><br /><p>Smart Meter (EM6400) - 1 <a href='AcademicMeterStatus.aspx' style='font-size:large;'>(Meter Status)</a><br />Covered area (on ground) - 577 sqm";
                buildInfo.InnerHtml += "<br />Covered area (on floors) - 1731 sqm<br />No of storeys - G + 2<br />Height of Building - 12.1 m</p><br />";
         
            }
            if (building == "Mess Building")
            {
                FetchEnergyDataS_Map.FetchBuildingData(frTime, tTime, building, paramList.SelectedValue, "Building Total Mains", out timeSt, out energyArray);
                buildingimg.ImageUrl = "~/images/buildings/mess.png";
                buildInfo.InnerHtml = "<h3>Buiding Information</h3><br /><p>Smart Meter (EM6400) - 1 <a href='MessMeterStatus.aspx' style='font-size:large;'>(Meter Status)</a><br />Covered area (on ground) - 1279.61 sqm";
                buildInfo.InnerHtml += "<br />Covered area (on floors) - 4690.78 sqm<br />No of storeys - G + 3<br />Height of Building - 16.3 m</p><br />";
         
            }
            if (building == "Library Building")
            {
                FetchEnergyDataS_Map.FetchBuildingData(frTime, tTime, building, paramList.SelectedValue, "Building Total Mains", out timeSt, out energyArray);
                
                buildingimg.ImageUrl = "~/images/buildings/library.png";
                buildInfo.InnerHtml = "<h3>Buiding Information</h3><br /><p>Smart Meter (EM6400) - 1 <a href='LibraryMeterStatus.aspx' style='font-size:large;'>(Meter Status)</a><br />Covered area (on ground) - 620.41 sqm";
                buildInfo.InnerHtml += "<br />Covered area (on floors) - 2467.49 sqm<br />No of storeys - G + 3<br />Height of Building - 13.65 m</p><br />";
         
            }
            if (building == "Faculty Housing")
            {
                FetchEnergyDataS_Map.FetchBuildingData(frTime, tTime, building, paramList.SelectedValue, meterList.SelectedValue, out timeSt, out energyArray);
                buildingimg.ImageUrl = "~/images/buildings/faculty.png";
                buildInfo.InnerHtml = "<h3>Buiding Information</h3><br /><p>Smart Meter (EM6400) - 83 <a href='FacultyMeterStatus.aspx' style='font-size:large;'>(Meter Status)</a><br />Covered area (on ground) - 559.67 sqm";
                buildInfo.InnerHtml += "<br />Covered area (on floors) - 6509.78 sqm<br />No of storeys - G+11<br />Height of Building - 34.30 m</p><br />";
         
            }
            if (building == "Girls Hostel AB")
            {
                FetchEnergyDataS_Map.FetchBuildingHostels(frTime, tTime, "Girls Hostel", "AB", paramList.SelectedValue, "Building Total Mains", out timeSt, out energyArray);
                buildingimg.ImageUrl = "~/images/buildings/girls_hostel.png";
                buildInfo.InnerHtml = "<h3>Buiding Information</h3><br /><p>Smart Meter (EM6400) - 23 <a href='GirlsHostelMeterStatus.aspx' style='font-size:large;'>(Meter Status)</a><br />Covered area (on ground) - 838.99 sqm";
                buildInfo.InnerHtml += "<br />Covered area (on floors) - 3562.28 sqm<br />No of storeys - G + 4<br />Height of Building - 16.50 m</p><br />";
                wing1.Text = "Wing AB   |";
            
            }
            if (building == "Girls Hostel BC")
            {
                FetchEnergyDataS_Map.FetchBuildingHostels(frTime, tTime, "Girls Hostel", "BC", paramList.SelectedValue, "Building Total Mains", out timeSt, out energyArray);
                buildingimg.ImageUrl = "~/images/buildings/girls_hostel.png";
                buildInfo.InnerHtml = "<h3>Buiding Information</h3><br /><p>Smart Meter (EM6400) - 23 <a href='GirlsHostelMeterStatus.aspx' style='font-size:large;'>(Meter Status)</a><br />Covered area (on ground) - 838.99 sqm";
                buildInfo.InnerHtml += "<br />Covered area (on floors) - 3562.28 sqm<br />No of storeys - G + 4<br />Height of Building - 16.50 m</p><br />";
            }

            if (building == "Boys Hostel A")
            {
                FetchEnergyDataS_Map.FetchBuildingHostels(frTime, tTime, "Boys Hostel", "A", paramList.SelectedValue, "Building Total Mains", out timeSt, out energyArray);
                buildingimg.ImageUrl = "~/images/buildings/boys_hostel.png";
                buildInfo.InnerHtml = "<h3>Buiding Information</h3><br /><p>Smart Meter (EM6400) - 34 <a href='BoysHostelMeterStatus.aspx' style='font-size:large;'>(Meter Status)</a><br />Covered area (on ground) - 1116.19 sqm";
                buildInfo.InnerHtml += "<br />Covered area (on floors) - 6798.57 sqm<br />No of storeys - G + 7<br />Height of Building - 26.40 m</p><br />";
                wing1.Text = "Wing A   |";
            }

            if (building == "Boys Hostel BC")
            {
                FetchEnergyDataS_Map.FetchBuildingHostels(frTime, tTime, "Boys Hostel", "BC", paramList.SelectedValue, "Building Total Mains", out timeSt, out energyArray);
                buildingimg.ImageUrl = "~/images/buildings/boys_hostel.png";
                buildInfo.InnerHtml = "<h3>Buiding Information</h3><br /><p>Smart Meter (EM6400) - 34 <a href='BoysHostelMeterStatus.aspx' style='font-size:large;'>(Meter Status)</a><br />Covered area (on ground) - 1116.19 sqm";
                buildInfo.InnerHtml += "<br />Covered area (on floors) - 6798.57 sqm<br />No of storeys - G + 7<br />Height of Building - 26.40 m</p><br />";
            }



            double en = energyArray[0];
            for (int l = 0; l < energyArray.Length; l++)
            {
                energyArray[l] = Math.Round(energyArray[l], 2);
            }

        

            interval = timeSt[timeSt.Length - 1] - timeSt[0];
            startDate = timeSt[0];

        }
        catch (Exception e)
        {

        }

    }

    protected void Plot_Building_Energy()
    {
        //plot return bar time with DTD comp type

        DateTime selectedDate = new DateTime(Convert.ToInt32(years.SelectedValue), Convert.ToInt32(months.SelectedValue), 1);
        List<int> selectDateList = Utilitie_S.Return_Bar_Time(selectedDate, "DTD");
        
        if (selectDateList != null)
        {
            int[] ep = new int[selectDateList.Count];
            for (int v = 0; v < selectDateList.Count; v++)
            {
                ep[v] = selectDateList[v];
            }
            energyTimeSeries = Utilitie_S.TimeFormatterBar(ep);
            List<int> toEpochs = new List<int>();
            for (int i = 0; i < selectDateList.Count; i++)
            {
                toEpochs.Add(selectDateList[i] + (selectDateList[1] - selectDateList[0]));
            }
            string[] frDateArray = Utilitie_S.SMapValidDateFormatter(selectDateList);
            string[] toDateArray = Utilitie_S.SMapValidDateFormatter(toEpochs);

            if (building == "Academic")
            {
                FetchEnergyDataS_Map.FetchBuildingBarConsumption(frDateArray, toDateArray, "Academic Building", "Academic Block", "Building Total Mains", out barTime, out barEnergy);
            }
            if (building == "ClassRooms")
            {
                FetchEnergyDataS_Map.FetchBuildingBarConsumption(frDateArray, toDateArray, "Academic Building", "Lecture Block", "Building Total Mains", out barTime, out barEnergy);
            }
            if (building == "Mess Building")
            {
                FetchEnergyDataS_Map.FetchBuildingBarConsumption(frDateArray, toDateArray, building, null, "Building Total Mains", out barTime, out barEnergy);
            }
            if (building == "Library Building")
            {
                FetchEnergyDataS_Map.FetchBuildingBarConsumption(frDateArray, toDateArray, building, null, "Building Total Mains", out barTime, out barEnergy);
            }
            if (building == "Faculty Housing")
            {
                FetchEnergyDataS_Map.FetchBuildingBarConsumption(frDateArray, toDateArray, building, null, "Building Total Mains", out barTime, out barEnergy);
            }
            if (building == "Girls Hostel AB")
            {
                FetchEnergyDataS_Map.FetchBuildingBarConsumption(frDateArray, toDateArray, "Girls Hostel", "AB", "Building Total Mains", out barTime, out barEnergy);
            }
            if (building == "Girls Hostel BC")
            {
                FetchEnergyDataS_Map.FetchBuildingBarConsumption(frDateArray, toDateArray, "Girls Hostel", "BC", "Building Total Mains", out barTime, out barEnergy);
            }
            if (building == "Boys Hostel A")
            {
                FetchEnergyDataS_Map.FetchBuildingBarConsumption(frDateArray, toDateArray, "Boys Hostel", "A", "Building Total Mains", out barTime, out barEnergy);
            }
            if (building == "Boys Hostel BC")
            {
                FetchEnergyDataS_Map.FetchBuildingBarConsumption(frDateArray, toDateArray, "Boys Hostel", "BC", "Building Total Mains", out barTime, out barEnergy);
            }
            if (barTime != null)
            {
                Utilitie_S.ZeroArrayRefiner(barTime, barEnergy, out barTime, out barEnergy);
                if (barTime.Length>1)
                {
                    for (int p = 1; p < barTime.Length; p++)
                    {
                        barEnergy[p - 1] = Math.Round((barEnergy[p] - barEnergy[p - 1]) / 1000,0);
                    }
                    barEnergy[barEnergy.Length - 1] = 0;
                    energyTimeSeries = Utilitie_S.TimeFormatter(barTime);
                }
            }
        }

    }
    protected void plotButton_Click(object sender, EventArgs e)
    {
       
        Plot_Building_All("Button");
        Plot_Building_Energy();
    }
    protected void wing1_Click(object sender, EventArgs e)
    {
        
        if (building == "Girls Hostel BC")
        {
            building = "Girls Hostel AB";
        }
        else if (building == "Boys Hostel BC")
        {
            building = "Boys Hostel A";
        }
        Plot_Building_All(null);
        Plot_Building_Energy();
       
    }
    protected void wing2_Click(object sender, EventArgs e)
    {
       
        if (building == "Girls Hostel AB")
        {
            building = "Girls Hostel BC";
        }
        else if (building == "Boys Hostel A")
        {
            building = "Boys Hostel BC";
        }
        Plot_Building_All(null);
        Plot_Building_Energy();
    }
    protected void plotBar_Click(object sender, EventArgs e)
    {
        Plot_Building_Energy();
        Plot_Building_All("Button");
    }
}