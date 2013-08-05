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


public partial class admin_ModernBill : System.Web.UI.Page
{
    static int listBoxCounter = -1;
    public static int myEnergy = 0;
    public static int avgEnergy = 0;
    public float[] energyArray;
    public int[] timeArray;
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
    protected void calculatePrint(UserLogin userData)
    {
        try
        {
            UserMapping map = UserMapping_S.MapUser(userData.UserId);
            if (map != null)
            {
                DateTime frDate = DateTime.ParseExact(fromDate.Value + ",000", "dd/MM/yyyy HH:mm:ss,fff",
                                           System.Globalization.CultureInfo.InvariantCulture);
                DateTime tDate = DateTime.ParseExact(toDate.Value + ",000", "dd/MM/yyyy HH:mm:ss,fff",
                                           System.Globalization.CultureInfo.InvariantCulture);
                if (frDate != null && tDate != null)
                {
                    Utilities utFr = Utilitie_S.DateTimeToEpoch(frDate);
                    Utilities utTo = Utilitie_S.DateTimeToEpoch(tDate);
                    List<FetchingEnergy> energy = FetchingEnergy_s.fetchBillingData(utFr.Epoch, utTo.Epoch, map.MeterId, map.Apartment);

                    if (energy != null)
                    {
                        float en = energy[1].FwdHr - energy[0].FwdHr;
                        float untPrice = 3;
                        decimal bill = Convert.ToDecimal(en * untPrice);
                        bill = Math.Round(bill, 2);

                        fullName.InnerText = userData.FullName;

                        unitsConsumed.InnerText = (energy[1].FwdHr - energy[0].FwdHr).ToString();
                        
                        //this portion for graph below you vs avg + co2 emission
                        double kwh = (energy[1].FwdHr - energy[0].FwdHr) / 1000;
                        myEnergy = Convert.ToInt32(energy[1].FwdHr - energy[0].FwdHr);
                        double co2Emission = kwh * 0.87;
                        string f1="<font color='#f18221 !important'>";
                        string f2="</font>";
                        co2.InnerHtml = f1+(kwh).ToString() + "KWhr"+f2+" of energy combustion is equivalent to CO2 emission of " + f1+co2Emission.ToString() + " Kg"+f2+" which is further equivalent to driving your car for " +f1+ (kwh * 6).ToString() + "KM"+f2;

                        //ends here--------------------------------------------
                        address.InnerText = userData.Apartment;
                        mobile.InnerText = userData.Mobile;

                        meterNo.InnerText = map.Apartment + " - " + map.MeterId.ToString();
                        billPeriod.InnerText = frDate.ToString("dd-MMM-yyyy") + " - " + tDate.ToString("dd-MMM-yyyy");
                        unitRate.InnerText = untPrice.ToString() + " Rs/unit";
                        total.InnerText = bill.ToString();
                        billAmount.InnerHtml = "Bill Amount: Rs " + bill.ToString();
                        dueDate.InnerHtml = "Due Date: " + DateTime.Now.AddDays(15).ToString("dd-MMM-yyyy");
                        billNo.InnerText = "Rep " + meterNo.InnerText + " - " + DateTime.Today.ToString("dd-MMM-yyyy");
                        billDate.InnerText = DateTime.Now.ToString("dd-MMM-yyyy");
                    }

                    List<FetchingEnergy> ft = FetchingEnergy_s.fetchAVGDashDayEnergy(utFr.Epoch, map.Apartment, utTo.Epoch-utFr.Epoch);
                    if (ft != null)
                    {
                        float avg = 0;
                        int ctr = 0;
                        for (int i = 0; i < ft.Count; i++)
                        {
                            avg = avg + (ft[i].fwdHrFinal - ft[i].FwdHr);
                            ctr++;
                        }
                        avg = avg / ctr;
                        avgEnergy = Convert.ToInt32( avg);
                    }
                    
                    
                    List<int> epochs=Utilitie_S.DashDaysEpochs(utFr.Epoch,4,7);


                    List<FetchingEnergy> barEnergy = FetchingEnergy_s.fetchEnergyBar(epochs, map.MeterId, map.Apartment);

                    if (barEnergy != null)
                    {
                        energyArray = new float[barEnergy.Count];
                        timeArray = new int[barEnergy.Count];
                        timeSeries = new string[barEnergy.Count];
                        for (int i = 0; i < barEnergy.Count; i++)
                        {
                            energyArray[i] = barEnergy[i].FwdHr;
                            timeArray[i] = barEnergy[i].TimeStamp;
                            
                        }
                        timeSeries = Utilitie_S.TimeFormatterBar(timeArray);


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

        List<UserLogin> AllUsers = UserLogin_S.ListOfAllUsers();
        if (AllUsers != null)
        {
            Table sideTable = new Table();
            sideTable.ID = "sideTable";

            for (int i = 0; i < AllUsers.Count; i++)
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
                nameLabel.InnerText = AllUsers[i].FullName;
                nameLabel.Style.Add("font-size", "large");
                nameLabel.Attributes.Add("class", "clicker");
                nameLabel.Attributes.Add("UID", AllUsers[i].UserName);
                ListBox1.Items.Add(AllUsers[i].UserName);
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

        fullName.InnerText = "";
        address.InnerText = "";
        mobile.InnerText = "";
        meterNo.InnerText = "";
        unitsConsumed.InnerText = "";
        unitRate.InnerText = "";
        total.InnerText = "";
        billAmount.InnerText = "";
        billDate.InnerText = "";
        billNo.InnerText = "";
        billPeriod.InnerText = "";
        dueDate.InnerText = "";
        UNameOfPrinter.InnerText = "";

        generateSideBarItems();



    }

    protected void DoneTipsClick(object sender, EventArgs e)
    {
        monthTip.InnerText = tipOfMonth.Text;
        tipp1.InnerText = tip1.Text;
        tipp2.InnerText = tip2.Text;
        tipp3.InnerText = tip3.Text;
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
            UserLogin userObj = returnUserObj(uid.Value);
            UNameOfPrinter.InnerText = userObj.UserName;
            calculatePrint(userObj);
        }
    }
    protected void nxt_Click(object sender, EventArgs e)
    {
        listBoxCounter++;
        if (listBoxCounter >= 0)
        {
            uid.Value = ListBox1.Items[listBoxCounter].Text;
            UserLogin userObj = returnUserObj(uid.Value);
            UNameOfPrinter.InnerText = userObj.UserName;
            calculatePrint(userObj);
        }
    }
    protected void printBill_Click(object sender, EventArgs e)
    {

        UserLogin userObj = returnUserObj(uid.Value);
        UNameOfPrinter.InnerText = userObj.UserName;
        calculatePrint(userObj);
    }
   

}