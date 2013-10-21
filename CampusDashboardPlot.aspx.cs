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
    public double[] barEnergyPeak;
    public int[] barTimePeak;
    public double[] barEnergyOffPeak;
    public int[] barTimeOffPeak;
    public int[] slab1, slab2, slab3, slab4; public double[] slab1Val, slab2Val, slab3Val, slab4Val;
    List<int> slab11, slab22, slab33, slab44;
    string[] frDateArray, toDateArray;
    public string slab1Txt = "", slab2Txt = "", slab3Txt = "", slab4Txt = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        //Response.Write(Session["Building-Selected"]);
        

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
            months.SelectedValue = DateTime.Now.Month.ToString();
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
            DateTime ftDate = DateTime.Now.AddDays(-1);
            DateTime ttDate = DateTime.Now;
            int factor = 1;

            if (typ != null)
            {
                if (fromDate.Value != "")
                {
                    ftDate = DateTime.ParseExact(fromDate.Value + ",000", "dd/MM/yyyy HH:mm:ss,fff",
                                          System.Globalization.CultureInfo.InvariantCulture);             
                }
                if (toDate.Value != "")
                {
                    ttDate = DateTime.ParseExact(toDate.Value + ",000", "dd/MM/yyyy HH:mm:ss,fff",
                                          System.Globalization.CultureInfo.InvariantCulture);                
                }
                if (fromDate.Value != "" || toDate.Value != "")
                {
                    frTime = "now -" + (Convert.ToInt32((DateTime.Now - ftDate).TotalMinutes)).ToString() + "minutes";
                    tTime = "now -" + (Convert.ToInt32((DateTime.Now - ttDate).TotalMinutes)).ToString() + "minutes";

                    double min = (ttDate - ftDate).TotalMinutes;
                    if (min < 43200)
                    {
                        factor = 1;
                    }                    
                    else
                    {
                        factor = 30;
                    }
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
                FetchEnergyDataS_Map.FetchBuildingAcademia(frTime, tTime,factor, "Academic Building", paramList.SelectedValue, "Building Total Mains", "Academic Block", out timeSt, out energyArray);
                buildingimg.ImageUrl = "~/images/buildings/academia.png";
                buildInfo.InnerHtml = "<h3>Buiding Information</h3><br /><p>Smart Meter (EM6400) - 1 <a href='AcademicMeterStatus.aspx' style='font-size:large;'>(Meter Status)</a><br />Covered area (on ground) - 1000 sqm";
                buildInfo.InnerHtml+= "<br />Covered area (on floors) - 5638.88 sqm<br />No of storeys - G + 5<br />Height of Building - 23.1 m</p><br />";
              
            }
            if (building == "ClassRooms")
            {
                FetchEnergyDataS_Map.FetchBuildingAcademia(frTime, tTime,factor, "Academic Building", paramList.SelectedValue, "Building Total Mains", "Lecture Block", out timeSt, out energyArray);
                buildingimg.ImageUrl = "~/images/buildings/classrooms.png";
                buildInfo.InnerHtml = "<h3>Buiding Information</h3><br /><p>Smart Meter (EM6400) - 1 <a href='AcademicMeterStatus.aspx' style='font-size:large;'>(Meter Status)</a><br />Covered area (on ground) - 577 sqm";
                buildInfo.InnerHtml += "<br />Covered area (on floors) - 1731 sqm<br />No of storeys - G + 2<br />Height of Building - 12.1 m</p><br />";
         
            }
            if (building == "Mess Building")
            {
                FetchEnergyDataS_Map.FetchBuildingData(frTime, tTime,factor, building, paramList.SelectedValue, "Building Total Mains", out timeSt, out energyArray);
                buildingimg.ImageUrl = "~/images/buildings/mess.png";
                buildInfo.InnerHtml = "<h3>Buiding Information</h3><br /><p>Smart Meter (EM6400) - 1 <a href='MessMeterStatus.aspx' style='font-size:large;'>(Meter Status)</a><br />Covered area (on ground) - 1279.61 sqm";
                buildInfo.InnerHtml += "<br />Covered area (on floors) - 4690.78 sqm<br />No of storeys - G + 3<br />Height of Building - 16.3 m</p><br />";
         
            }
            if (building == "Library Building")
            {
                FetchEnergyDataS_Map.FetchBuildingData(frTime, tTime,factor, building, paramList.SelectedValue, "Building Total Mains", out timeSt, out energyArray);
                
                buildingimg.ImageUrl = "~/images/buildings/library.png";
                buildInfo.InnerHtml = "<h3>Buiding Information</h3><br /><p>Smart Meter (EM6400) - 1 <a href='LibraryMeterStatus.aspx' style='font-size:large;'>(Meter Status)</a><br />Covered area (on ground) - 620.41 sqm";
                buildInfo.InnerHtml += "<br />Covered area (on floors) - 2467.49 sqm<br />No of storeys - G + 3<br />Height of Building - 13.65 m</p><br />";
         
            }
            if (building == "Faculty Housing")
            {
                FetchEnergyDataS_Map.FetchBuildingData(frTime, tTime,factor, building, paramList.SelectedValue, meterList.SelectedValue, out timeSt, out energyArray);
                buildingimg.ImageUrl = "~/images/buildings/faculty.png";
                buildInfo.InnerHtml = "<h3>Buiding Information</h3><br /><p>Smart Meter (EM6400) - 83 <a href='FacultyMeterStatus.aspx' style='font-size:large;'>(Meter Status)</a><br />Covered area (on ground) - 559.67 sqm";
                buildInfo.InnerHtml += "<br />Covered area (on floors) - 6509.78 sqm<br />No of storeys - G+11<br />Height of Building - 34.30 m</p><br />";
         
            }
            if (building == "Girls Hostel AB")
            {
                FetchEnergyDataS_Map.FetchBuildingHostels(frTime, tTime, factor, "Girls Hostel", "AB", paramList.SelectedValue, "Building Total Mains", out timeSt, out energyArray);
                buildingimg.ImageUrl = "~/images/buildings/girls_hostel.png";
                buildInfo.InnerHtml = "<h3>Buiding Information</h3><br /><p>Smart Meter (EM6400) - 23 <a href='GirlsHostelMeterStatus.aspx' style='font-size:large;'>(Meter Status)</a><br />Covered area (on ground) - 838.99 sqm";
                buildInfo.InnerHtml += "<br />Covered area (on floors) - 3562.28 sqm<br />No of storeys - G + 4<br />Height of Building - 16.50 m</p><br />";
                wing1.Text = "Wing AB   |";
            
            }
            if (building == "Girls Hostel BC")
            {
                FetchEnergyDataS_Map.FetchBuildingHostels(frTime, tTime,factor, "Girls Hostel", "BC", paramList.SelectedValue, "Building Total Mains", out timeSt, out energyArray);
                buildingimg.ImageUrl = "~/images/buildings/girls_hostel.png";
                buildInfo.InnerHtml = "<h3>Buiding Information</h3><br /><p>Smart Meter (EM6400) - 23 <a href='GirlsHostelMeterStatus.aspx' style='font-size:large;'>(Meter Status)</a><br />Covered area (on ground) - 838.99 sqm";
                buildInfo.InnerHtml += "<br />Covered area (on floors) - 3562.28 sqm<br />No of storeys - G + 4<br />Height of Building - 16.50 m</p><br />";
            }

            if (building == "Boys Hostel A")
            {
                FetchEnergyDataS_Map.FetchBuildingHostels(frTime, tTime,factor, "Boys Hostel", "A", paramList.SelectedValue, "Building Total Mains", out timeSt, out energyArray);
                buildingimg.ImageUrl = "~/images/buildings/boys_hostel.png";
                buildInfo.InnerHtml = "<h3>Buiding Information</h3><br /><p>Smart Meter (EM6400) - 34 <a href='BoysHostelMeterStatus.aspx' style='font-size:large;'>(Meter Status)</a><br />Covered area (on ground) - 1116.19 sqm";
                buildInfo.InnerHtml += "<br />Covered area (on floors) - 6798.57 sqm<br />No of storeys - G + 7<br />Height of Building - 26.40 m</p><br />";
                wing1.Text = "Wing A   |";
            }

            if (building == "Boys Hostel BC")
            {
                FetchEnergyDataS_Map.FetchBuildingHostels(frTime, tTime,factor, "Boys Hostel", "BC", paramList.SelectedValue, "Building Total Mains", out timeSt, out energyArray);
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
        int slabCount = 0; 
        
        List<int> selectDateList;
        if (selectedDate!=null)
        {
            List<int> lst=Utilitie_S.Return_Bar_Time(selectedDate, "DTD");
            if (lst != null)
            {
                timeArray = new int[lst.Count];
                for (int r = 0; r < lst.Count; r++)
                {
                    timeArray[r] = lst[r];
                }
                energyTimeSeries = Utilitie_S.TimeFormatterBar(timeArray);
            }
            if (building == "Academic")
            {
               slabCount = 0;
               selectDateList = Utilitie_S.Return_Slab_Time(selectedDate, "DTD-Slabs", true, out slabCount);
               Get_Slab_Data(selectDateList, slabCount, "Academic Building", "Academic Block");
            }
            if (building == "ClassRooms")
            {
                slabCount = 0;
                selectDateList = Utilitie_S.Return_Slab_Time(selectedDate, "DTD-Slabs", true, out slabCount);
                Get_Slab_Data(selectDateList, slabCount, "Academic Building", "Lecture Block");
            }
            if (building == "Mess Building")
            {
                slabCount = 0;
                selectDateList = Utilitie_S.Return_Slab_Time(selectedDate, "DTD-Slabs", true, out slabCount);
                Get_Slab_Data(selectDateList, slabCount, building, null);
            }
            if (building == "Library Building")
            {
                slabCount = 0;
                selectDateList = Utilitie_S.Return_Slab_Time(selectedDate, "DTD-Slabs", true, out slabCount);
                Get_Slab_Data(selectDateList, slabCount, building, null);
            }
            if (building == "Faculty Housing")
            {
                slabCount = 0;                
                selectDateList = Utilitie_S.Return_Slab_Time(selectedDate, "DTD-Slabs", false, out slabCount);
                Get_Slab_Data(selectDateList, slabCount, "Faculty Housing", null);                
            }
            if (building == "Girls Hostel AB")
            {
                slabCount = 0;
                selectDateList = Utilitie_S.Return_Slab_Time(selectedDate, "DTD-Slabs", false, out slabCount);
                Get_Slab_Data(selectDateList, slabCount, "Girls Hostel", "AB");
            }
            if (building == "Girls Hostel BC")
            {
                slabCount = 0;
                selectDateList = Utilitie_S.Return_Slab_Time(selectedDate, "DTD-Slabs", false, out slabCount);
                Get_Slab_Data(selectDateList, slabCount,"Girls Hostel", "BC");
            }
            if (building == "Boys Hostel A")
            {
                slabCount = 0;
                selectDateList = Utilitie_S.Return_Slab_Time(selectedDate, "DTD-Slabs", false, out slabCount);
                Get_Slab_Data(selectDateList, slabCount, "Boys Hostel", "A");
            }
            if (building == "Boys Hostel BC")
            {
                slabCount = 0;
                selectDateList = Utilitie_S.Return_Slab_Time(selectedDate, "DTD-Slabs", false, out slabCount);
                Get_Slab_Data(selectDateList, slabCount, "Boys Hostel", "BC");
            }          
        }
    }

    protected void slabText(int slabCount)
    {
        if (slabCount == 1)
        {
            slab2Txt = "00:00Hrs - 24:00Hr";
        }
        if (slabCount == 3)
        {
            slab1Txt = "00:00Hrs - 06:00Hrs";
            slab2Txt = "06:00Hrs - 15:00Hrs";
            slab3Txt = "15:00Hrs - 24:00Hrs";
        }
        if (slabCount == 4)
        {
            slab1Txt = "00:00Hrs - 06:00Hrs";
            slab2Txt = "06:00Hrs - 17:00Hrs";
            slab3Txt = "17:00Hrs - 23:00Hrs";
            slab4Txt = "23:00Hrs - 24:00Hrs";
        }
    }

    protected void Time_Division(List<int> time, int slabCount, out List<int> slab1, out List<int> slab2, out List<int> slab3, out List<int> slab4)
    {
        slab1 = new List<int>();
        slab2 = new List<int>();
        slab3 = new List<int>();
        slab4 = new List<int>();
        int ct = 0;
        try
        {          
            for (int i = 0; i < time.Count; i = i + slabCount)
            {
                if (slabCount == 1)
                {
                    slab2.Add(time[i]);
                }
                if (slabCount == 3 || slabCount == 4)
                {
                    slab1.Add(time[i]);
                    slab2.Add(time[i + 1]);
                    slab3.Add(time[i + 2]);
                    if (slabCount == 4)
                    {
                        slab4.Add(time[i + 3]);
                    }
                    if (slabCount == 3)
                    {
                        slab4 = null;
                    }
                }
                ct++;
            }
        }
        catch (Exception f)
        {

        }        
    }

    protected void Time_Bound_Limit(List<int> epochs, out string[] fromDates, out string[] toDates)
    {
        fromDates=new string[epochs.Count];
        toDates = new string[epochs.Count];
        List<int> toEpochs = new List<int>();
        for (int i = 0; i < epochs.Count; i++)
        {
            toEpochs.Add(epochs[i] + 60);
        }
        toDates = Utilitie_S.SMapValidDateFormatter(toEpochs);
        fromDates = Utilitie_S.SMapValidDateFormatter(epochs);
    }

    protected void Get_Slab_Data(List<int> selectDateList, int slabCount, string buildingName, string block_wing)
    {
        Time_Division(selectDateList, slabCount, out slab11, out slab22, out slab33, out slab44);
        slabText(slabCount);
        if (slabCount > 0)
        {
            Time_Bound_Limit(slab22, out frDateArray, out toDateArray);
            FetchEnergyDataS_Map.FetchBuildingBarConsumption(frDateArray, toDateArray, buildingName, block_wing, "Building Total Mains", out slab2, out slab2Val);
            //SubtractEnergyArray(slab2Val, out slab2Val);
            if (slabCount == 3 || slabCount == 4)
            {
                Time_Bound_Limit(slab11, out frDateArray, out toDateArray);
                FetchEnergyDataS_Map.FetchBuildingBarConsumption(frDateArray, toDateArray, buildingName, block_wing, "Building Total Mains", out slab1, out slab1Val);
                //SubtractEnergyArray(slab1Val, out slab1Val);
                Time_Bound_Limit(slab33, out frDateArray, out toDateArray);
                FetchEnergyDataS_Map.FetchBuildingBarConsumption(frDateArray, toDateArray, buildingName, block_wing, "Building Total Mains", out slab3, out slab3Val);
                //SubtractEnergyArray(slab3Val, out slab3Val);
                if (slabCount == 4)
                {
                    Time_Bound_Limit(slab44, out frDateArray, out toDateArray);
                    FetchEnergyDataS_Map.FetchBuildingBarConsumption(frDateArray, toDateArray, buildingName, block_wing, "Building Total Mains", out slab4, out slab4Val);
                    //SubtractEnergyArray(slab4Val, out slab4Val);
                }
            }
            merger(slabCount, slab1Val, slab2Val, slab3Val, slab4Val,out slab1Val,out slab2Val,out slab3Val,out slab4Val);
        }
    }

    protected void merger(int sc, double[] slab1Value, double[] slab2Value, double[] slab3Value, double[] slab4Value, out double[] s1v,out double[] s2v,out double[] s3v, out double[] s4v)
    {
        s1v = slab1Value; s2v = slab2Value; s3v = slab3Value; s4v = slab4Value;
        if (sc > 0)
        {
            if (sc == 1)
            {
                SubtractEnergyArray(s2v, out s2v);
            }
            if (sc == 3)
            {
                for (int d = 0; d < s1v.Length-1; d++)
                {
                    if (slab1Value[d] > 0 && slab2Value[d] > 0)
                    {
                        s1v[d] = Math.Round(s2v[d] - s1v[d],0);
                    }
                    else
                    {
                        s1v[d] = -1;
                    }
                    if (slab2Value[d] > 0 && slab3Value[d] > 0)
                    {
                        s2v[d] =  Math.Round(s3v[d] - s2v[d],0);
                    }
                    else
                    {
                        s2v[d] = -1;
                    }
                    if (slab3Value[d] > 0 && slab1Value[d+1] > 0)
                    {
                        s3v[d] =  Math.Round(s1v[d+1] - s3v[d],0);
                    }
                    else
                    {
                        s3v[d] = -1;
                    }
                }
            }
            if (sc == 4)
            {
                for (int d = 0; d < s1v.Length - 1; d++)
                {
                    if (slab1Value[d] > 0 && slab2Value[d] > 0)
                    {
                        s1v[d] = Math.Round(s2v[d] - s1v[d], 0);
                    }
                    else
                    {
                        s1v[d] = -1;
                    }
                    if (slab2Value[d] > 0 && slab3Value[d] > 0)
                    {
                        s2v[d] = Math.Round(s3v[d] - s2v[d], 0);
                    }
                    else
                    {
                        s2v[d] = -1;
                    }
                    if (slab3Value[d] > 0 && slab4Value[d] > 0)
                    {
                        s3v[d] =  Math.Round(s4v[d] - s3v[d],0);
                    }
                    else
                    {
                        s3v[d] = -1;
                    }
                    if (slab4Value[d] > 0 && slab1Value[d + 1] > 0)
                    {
                        s4v[d] =  Math.Round(s1v[d + 1] - s4v[d],0);
                    }
                    else
                    {
                        s4v[d] = -1;
                    }
                }
            }            
        }
    }

    protected void SubtractEnergyArray(double[] values, out double[] subtractedValues)
    {
        subtractedValues = null;
        if (values != null)
        {
            subtractedValues = new double[values.Length - 2];
            List<int> neg = new List<int>();
            for (int d = 0; d < values.Length; d++)
            {
                if (values[d] >= 0)
                {
                    neg.Add(d);
                }
            }
            
            int prvs = -1;
            foreach (int index in neg)
            {
                if (prvs != -1)
                {
                    values[prvs] = Math.Round((values[index] - values[prvs]),0);
                }
                prvs = index;
            }
            subtractedValues = values;
            subtractedValues[subtractedValues.Length - 2] = -1;
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