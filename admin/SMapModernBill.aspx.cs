using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using App_Code.FetchingEnergyss;
using App_Code.FetchingEnergySmap;
using App_Code.Login;
using App_Code.User_Mapping;
using App_Code.Utility;
using System.Web.Script.Serialization;
using App_Code.ESTip;


public partial class SMapModernBill : System.Web.UI.Page
{
    static int listBoxCounter = -1;
    public static int myEnergy = 0;
    public static int avgEnergy = 0;
    public double[] energyArray;
    public double[] energyLightingArray;
    public int[] timeArray;
    public int[] timeArrayFinal;
    public int[] timeLightingArray;
    public static string[] timeSeries;
    public static string meterTyped1 = "Power";
    public static string location = "Faculty Housing";
    public static string meterTyped2 = "Light Backup";


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
    protected void calculatePrint(UserMapping userData)
    {
        try
        {

            UserMapping map = UserMapping_S.UserMapWithApartmentBuilding("Faculty Housing", userData.Apartment);
            if (map != null)
            {

                bill1.tipText = tipOfMonth.SelectedItem.Text;
                bill1.tipHeading = "Tip of Month";

                DateTime frDate = DateTime.ParseExact(fromDate.Value + ",000", "dd/MM/yyyy HH:mm:ss,fff",
                                           System.Globalization.CultureInfo.InvariantCulture);
                DateTime tDate = DateTime.ParseExact(toDate.Value + ",000", "dd/MM/yyyy HH:mm:ss,fff",
                                           System.Globalization.CultureInfo.InvariantCulture);


                if (powerCheck.Checked == true)
                {
                    bill1.meter1 = "Power";
                }
                else
                {
                    bill1.meter1 = null;
                }
                if (lightCheck.Checked == true)
                {
                    bill1.meter2 = "Light Backup";
                }
                else
                {
                    bill1.meter2 = null;
                }
                bill1.fromDate = frDate;
                bill1.toDate = tDate;
                bill1.calculatePrint(userData);

                int day=frDate.Day;
                int month=frDate.Month;
                int year=frDate.Year;

                frDate=new DateTime(year,month,day,0,0,1);
                day=tDate.Day;
                month=tDate.Month;
                year=tDate.Year;

                tDate=new DateTime(year,month,day,23,59,59);
               
                if (frDate != null && tDate != null)
                {
                    Utilities utFr=Utilitie_S.DateTimeToEpoch(frDate);
                    Utilities utTo=Utilitie_S.DateTimeToEpoch(tDate);

                    int[] timeStMet1 = new int[2]; double[] valuesMet1 = new double[2];
                    if (powerCheck.Checked == true)
                    {
                        FetchEnergyDataS_Map.FetchBillConsumption(utFr.Epoch, utTo.Epoch, map.Apartment, bill1.meter1, out timeStMet1, out valuesMet1);
                        Utilitie_S.ZeroArrayRefiner(timeStMet1, valuesMet1, out timeStMet1, out valuesMet1);
                    }

                    int[] timeStMet2 = new int[2]; double[] valuesMet2 = new double[2];
                    if (lightCheck.Checked==true)
                    {
                        FetchEnergyDataS_Map.FetchBillConsumption(utFr.Epoch, utTo.Epoch, map.Apartment, bill1.meter2, out timeStMet2, out valuesMet2);
                        Utilitie_S.ZeroArrayRefiner(timeStMet2, valuesMet2, out timeStMet2, out valuesMet2);
                    }

                    
                    if (valuesMet1!=null || valuesMet2!=null)
                    {
                        double lightingUnits = 0;
                        double powerUnits = 0;
                        
                        if (lightCheck.Checked == true)
                        {
                            lightingUnits = Math.Round(((valuesMet2[1] - valuesMet2[0]) / 1000), 2);
                        }
                        if (powerCheck.Checked == true)
                        {
                            powerUnits = Math.Round(((valuesMet1[1] - valuesMet1[0]) / 1000), 2);          
                        }

                        double totalUnit = lightingUnits + powerUnits;

                        //this portion for graph below you vs avg + co2 emission
                        double kwh = totalUnit;
                        myEnergy = Convert.ToInt32(totalUnit);
                        double co2Emission =Math.Round( kwh * 0.87,2);
                        string f1 = "<font color='#f18221 !important'>";
                        string f2 = "</font>";
                        co2.InnerHtml = f1 + (kwh).ToString() + "KWhr" + f2 + " of energy combustion is equivalent to CO2 emission of " + f1 + co2Emission.ToString() + " Kg" + f2 + " which is further equivalent to driving your car for " + f1 + (Math.Round((kwh * 5.8), 2)).ToString() + "KM" + f2;

                        //ends here--------------------------------------------

                    }

                    string[] frTim=new string[2];
                    string[] tTim=new string[2];

                    frTim[0]=frDate.ToString("MM/dd/yyyy HH:mm");
                    frTim[1]=tDate.ToString("MM/dd/yyyy HH:mm");

                    tTim[0]=frDate.AddMinutes(-5).ToString("MM/dd/yyyy HH:mm");
                    tTim[1]=tDate.AddMinutes(-5).ToString("MM/dd/yyyy HH:mm");

                    int[] avgTime,avgTime2;
                    double[] avgValues, avgValues2;
                    int avg1 = 0, avg2 = 0;

                    if (powerCheck.Checked == true)
                    {
                        FetchEnergyDataS_Map.FetchAvgConsumption(frTim, tTim, map.Building, meterTyped1, out avgTime, out avgValues);
                        Utilitie_S.ZeroArrayRefiner(avgTime, avgValues, out avgTime, out avgValues);
                        if (avgTime.Length == 2)
                        {
                            avg1 = Convert.ToInt32((avgValues[1] - avgValues[0]) / 1000);
                        }
                    }
                    if (lightCheck.Checked == true)
                    {
                        FetchEnergyDataS_Map.FetchAvgConsumption(frTim, tTim, map.Building, meterTyped2, out avgTime2, out avgValues2);
                        Utilitie_S.ZeroArrayRefiner(avgTime2, avgValues2, out avgTime2, out avgValues2);
                        if (avgTime2.Length == 2)
                        {
                            avg2 = Convert.ToInt32((avgValues2[1] - avgValues2[0]) / 1000);
                        }
                    }
                    avgEnergy = avg1 + avg2;
                    

                    List<int> epochs=Utilitie_S.DashDaysEpochs(utFr.Epoch,5,3);
                    List<int> toEpochs=new List<int>();

                    for(int s=0; s<epochs.Count;s++)
                    {
                        toEpochs.Add(epochs[s]+300);
                    }
                    string[] fromTimes=Utilitie_S.SMapValidDateFormatter(epochs);
                    string[] toTimes=Utilitie_S.SMapValidDateFormatter(toEpochs);

                    //for power meter
                    if (powerCheck.Checked == true)
                    {
                        FetchEnergyDataS_Map.FetchBarConsumption(fromTimes, toTimes, map.Apartment, meterTyped1, out timeArray, out energyArray);
                        Utilitie_S.ZeroArrayRefiner(timeArray, energyArray, out timeArray, out energyArray);
                        for (int ik = energyArray.Length - 1; ik > 0; ik = ik - 1)
                        {
                            energyArray[ik] = Math.Round((energyArray[ik] - energyArray[ik - 1]) / 1000, 2);
                        }
                        timeArrayFinal = timeArray;
                        timeSeries = new string[energyArray.Length];
                        if (timeSeries.Length > 0)
                        {
                            timeSeries = Utilitie_S.TimeFormatter(timeArrayFinal);
                        }
                        energyArray[0] = 0; timeArray[0] = 0;
                        Utilitie_S.ZeroArrayRefiner(timeArray, energyArray, out timeArray, out energyArray);
                    }

                    //for the lighting meter
                    if (lightCheck.Checked == true)
                    {
                        FetchEnergyDataS_Map.FetchBarConsumption(fromTimes, toTimes, map.Apartment, meterTyped2, out timeLightingArray, out energyLightingArray);
                        Utilitie_S.ZeroArrayRefiner(timeLightingArray, energyLightingArray, out timeLightingArray, out energyLightingArray);
                        for (int ki = energyLightingArray.Length - 1; ki > 0; ki = ki - 1)
                        {
                            energyLightingArray[ki] = Math.Round((energyLightingArray[ki] - energyLightingArray[ki - 1]) / 1000, 2);
                        }
                       
                        timeArrayFinal = timeLightingArray;
                        timeSeries = new string[energyLightingArray.Length];
                        if (timeSeries.Length > 0)
                        {
                            timeSeries = Utilitie_S.TimeFormatter(timeArrayFinal);
                        }
                        energyLightingArray[0] = 0; timeLightingArray[0] = 0;
                        Utilitie_S.ZeroArrayRefiner(timeLightingArray, energyLightingArray, out timeLightingArray, out energyLightingArray);
                    }
                    

                    
                   
                }
            }
        }
        catch (Exception e)
        {

        }
    }

    protected void generateSideBarItems()
    {

        List<UserMapping> AllApartments = UserMapping_S.ListAllBuildingApartments("Faculty Housing");
        if (AllApartments != null)
        {
            Table sideTable = new Table();
            sideTable.ID = "sideTable";

            for (int i = 0; i < AllApartments.Count; i++)
            {

                TableRow wrapper = new TableRow();
                wrapper.ID = "wrapper" + i;

                TableCell cell = new TableCell();
                cell.ID = "cell" + i;
                cell.Style.Add("width", "250px");
                cell.Style.Add("height", "40px");
                cell.Style.Add("border-bottom-style", "groove");

                HtmlGenericControl nameLabel = new HtmlGenericControl("label");
                nameLabel.ID = "nameLabel" + i;
                nameLabel.InnerText = AllApartments[i].Apartment;
                nameLabel.Style.Add("font-size", "large");
                nameLabel.Attributes.Add("class", "clicker");
                nameLabel.Attributes.Add("UID", AllApartments[i].UserId.ToString());
                nameLabel.Attributes.Add("Apart", AllApartments[i].Apartment);
                ListBox1.Items.Add(AllApartments[i].Apartment);
                nameLabel.Attributes.Add("onclick", "JavaScript:CopyHidden(this)");

                cell.Controls.Add(nameLabel);
                wrapper.Cells.Add(cell);
                sideTable.Rows.Add(wrapper);

            }
            sideBar.Controls.Add(sideTable);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        CheckLogin();

        if (IsPostBack == false)
        {
            List<EsTips> etips = ES_Tips.SelectTips();
            if (etips != null)
            {
                for (int x = 0; x < etips.Count; x++)
                {
                    tipOfMonth.Items.Add(new ListItem(etips[x].Tips,etips[x].Id.ToString()));

                    tip1.Items.Add(new ListItem(etips[x].Tips, etips[x].Id.ToString()));
                    tip2.Items.Add(new ListItem(etips[x].Tips, etips[x].Id.ToString()));
                    tip3.Items.Add(new ListItem(etips[x].Tips, etips[x].Id.ToString()));
                }
            }
        }

     
        UNameOfPrinter.InnerText = "";

        generateSideBarItems();



    }

    protected void DoneTipsClick(object sender, EventArgs e)
    {
        tipp1.InnerText = tip1.SelectedItem.Text;
        tipp2.InnerText = tip2.SelectedItem.Text;
        tipp3.InnerText = tip3.SelectedItem.Text;
    }

    protected UserLogin returnUserObj(string userName)
    {
        UserLogin userObj = UserLogin_S.SeeUserInfo(userName);
        if (userObj != null)
        {
            return userObj;
        }
        else
        {
            return null;
        }


    }

    protected void prvs_Click(object sender, EventArgs e)
    {
        listBoxCounter--;
        if (listBoxCounter >= 0)
        {
            uid.Value = ListBox1.Items[listBoxCounter].Text;
            UserMapping userObj = UserMapping_S.UserMapWithApartmentBuilding("Faculty Housing", uid.Value);
            UNameOfPrinter.InnerText = userObj.Apartment;
            calculatePrint(userObj);
        }
    }
    protected void nxt_Click(object sender, EventArgs e)
    {
        listBoxCounter++;
        if (listBoxCounter >= 0)
        {
            uid.Value = ListBox1.Items[listBoxCounter].Text;
            UserMapping userObj = UserMapping_S.UserMapWithApartmentBuilding("Faculty Housing", uid.Value);
            UNameOfPrinter.InnerText = userObj.Apartment;
            calculatePrint(userObj);
        }
    }
    protected void printBill_Click(object sender, EventArgs e)
    {
        //uid.Value = ListBox1.Items[0].Text;
        UserMapping userObj = UserMapping_S.UserMapWithApartmentBuilding("Faculty Housing", uid.Value);
        UNameOfPrinter.InnerText = userObj.Apartment;
        calculatePrint(userObj);
    }
   

}