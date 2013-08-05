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

public partial class SMapClassicBill : System.Web.UI.Page
{
    static int listBoxCounter = -1;

    public static string meterTyped1 = "Power";
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
                int day = frDate.Day;
                int month = frDate.Month;
                int year = frDate.Year;

                frDate = new DateTime(year, month, day, 0, 0, 1);
                day = tDate.Day;
                month = tDate.Month;
                year = tDate.Year;

                tDate = new DateTime(year, month, day, 23, 59, 59);

                if (frDate != null && tDate != null)
                {
                    Utilities utFr = Utilitie_S.DateTimeToEpoch(frDate);
                    Utilities utTo = Utilitie_S.DateTimeToEpoch(tDate);
              
                    int[] timeStMet1; double[] valuesMet1;

                    FetchEnergyDataS_Map.FetchBillConsumption(utFr.Epoch, utTo.Epoch, map.Apartment, meterTyped1 , out timeStMet1, out valuesMet1);

                    int[] timeStMet2; double[] valuesMet2;

                    FetchEnergyDataS_Map.FetchBillConsumption(utFr.Epoch, utTo.Epoch, map.Apartment, meterTyped2, out timeStMet2, out valuesMet2);


                    Utilitie_S.ZeroArrayRefiner(timeStMet1, valuesMet1, out timeStMet1, out valuesMet1);
                    Utilitie_S.ZeroArrayRefiner(timeStMet2, valuesMet2, out timeStMet2, out valuesMet2);


                    if (valuesMet1.Length>1 && valuesMet2.Length>1)
                    {

                        double lightingUnits = (valuesMet2[1] - valuesMet2[0])/1000;
                        double powerUnits = (valuesMet1[1] - valuesMet1[0])/1000;
                        
                        lightingUnits = Math.Round(lightingUnits, 2);
                        powerUnits = Math.Round(powerUnits, 2);

                        double totalUnit = lightingUnits + powerUnits;

                        int dayNo = (utTo.Epoch-utFr.Epoch) / (60 * 60 * 24);

                        double SL1CHRG = 3.7; double SL2CHRG = 5.5; double SL3CHRG = 6.5; double slabSize=6.67;
                        double SL1PRC=0; double SL2PRC=0; double SL3PRC=0;
                        string slabTxt = "";
                        double daslb = dayNo * slabSize;
                        daslb = Math.Round(daslb, 2);

                        if (totalUnit > daslb)
                        {
                            if (totalUnit >= (2 * daslb))
                            {
                                SL1PRC = SL1CHRG * daslb;
                                slabTxt = (daslb).ToString() + " X " + SL1CHRG.ToString() + " = " + SL1PRC.ToString();
                                SL2PRC = SL2CHRG * daslb;
                                slabTxt = slabTxt + "<br />" + (daslb).ToString() + " X " + SL2CHRG.ToString() + " = " + SL2PRC.ToString();
                                SL3PRC = SL3CHRG * (totalUnit - (2 * daslb));
                                slabTxt = slabTxt + "<br />" + (totalUnit - (2 * daslb)).ToString() + " X " + SL3CHRG.ToString() + " = " + SL3PRC.ToString();
                            }
                            else
                            {
                                SL1PRC = SL1CHRG * daslb;
                                slabTxt = (daslb).ToString() + " X " + SL1CHRG.ToString() + " = " + SL1PRC.ToString();
                                SL2PRC = SL2CHRG * (totalUnit - (daslb));
                                slabTxt = slabTxt + "<br />" +(totalUnit- (daslb)).ToString() + " X " + SL2CHRG.ToString() + " = " + SL2PRC.ToString();
                            }
                        }
                        else
                        {
                            SL1PRC = SL1CHRG * totalUnit;
                            slabTxt = (daslb).ToString() + " X " + SL1CHRG.ToString() + " = " + SL1PRC.ToString();
                        }

                        double TotalPRC = SL1PRC + SL2PRC + SL3PRC;
                        double FIXED_CHRG = 6;
                        double FIXED_PRC = FIXED_CHRG * dayNo;

                        double Adj_PRCNT = 1.5;
                        double Def_PRCNT = 8;

                        double Adj_Total_PRC = (Adj_PRCNT / 100) * TotalPRC;
                        double Def_Total_PRC = (Def_PRCNT / 100) * TotalPRC;

                        double Adj_FIX_PRC = (Adj_PRCNT / 100) * FIXED_PRC;
                        double Def_FIX_PRC = (Def_PRCNT / 100) * FIXED_PRC;
                       
                        double temp1 = TotalPRC + Adj_Total_PRC + Def_Total_PRC;
                        double temp2 = FIXED_PRC + Adj_FIX_PRC + Def_FIX_PRC;

                        temp1 = Math.Round(temp1, 2);
                        temp2 = Math.Round(temp2, 2);

                        double subTotal = temp1 + temp2;

                        double ELEC_CHRG_PRCNT = 5;
                        double ELEC_TAX = (ELEC_CHRG_PRCNT / 100) * subTotal;
                        ELEC_TAX = Math.Round(ELEC_TAX, 2);
                        
                        double Final_Total = subTotal + ELEC_TAX;

                        meterType1.Text = meterTyped1;                      meterType2.Text = meterTyped2;
                        metTyp1Units.Text = powerUnits.ToString();          metTyp2Units.Text = lightingUnits.ToString();
                        metTyp1Units0.Text = (Math.Round(valuesMet1[0]/1000,2)).ToString();      metTyp1Units1.Text = (Math.Round(valuesMet1[1]/1000,2)).ToString();
                        metTyp2Units0.Text = (Math.Round(valuesMet2[0]/1000,2)).ToString();      metTyp2Units1.Text = (Math.Round(valuesMet2[1]/1000,2)).ToString();

                        dayTd.InnerHtml ="Days = "+dayNo.ToString();                  totalUnits.Text = totalUnit.ToString();

                        totalUnitsConsumed.Text = totalUnit.ToString();
                        slabText.InnerHtml = slabTxt;
                        fixedText.InnerHtml = FIXED_CHRG.ToString() + " X " + dayNo.ToString() + "(Days)";

                        totalSlabCharge.Text = TotalPRC.ToString();
                        totalFixCharge.Text = FIXED_PRC.ToString();

                        energyChrg.Text = TotalPRC.ToString();
                        fixChrg.Text = FIXED_PRC.ToString();
                        adjEnrgyChrg.Text = Adj_Total_PRC.ToString();
                        adjFixChrg.Text = Adj_FIX_PRC.ToString();
                        defEnrgyChrg.Text = Def_Total_PRC.ToString();
                        defFixChrg.Text = Def_FIX_PRC.ToString();
                        netEnrgyChrg.Text = temp1.ToString();
                        netFixChrg.Text = temp2.ToString();


                        subTotalTxt.Text = "Rs "+subTotal.ToString();
                        elecTax.InnerHtml = "Electricity Tax (" + ELEC_CHRG_PRCNT.ToString() + "%) on (Rs " + subTotal.ToString() + " ) = Rs " + ELEC_TAX.ToString();
                        netBillAmt.InnerHtml = "Net Bill Amount = Rs " +Math.Round( Final_Total,2).ToString();

                        billAmount.InnerHtml = "Bill Amount = Rs " + Math.Round( Final_Total,2).ToString();

                        /****888888888888888888888888888888*******************************/
                        address.InnerHtml = "Flat No: " + map.Apartment + ", " + map.Building + " (IIITD)," + " Okhla Phase III, Delhi";
                        mobile.InnerText = userData.Mobile;

                        meterNo.InnerText = map.Apartment + " - " + map.MeterId.ToString();
                        billPeriod.InnerText = frDate.ToString("dd/MM/yyyy") + " to " + tDate.ToString("dd/MM/yyyy");
                        dueDate.InnerHtml = "Due Date: " + DateTime.Now.AddDays(7).ToString("dd-MMM-yyyy");
                        billNo.InnerText = "Rep " + meterNo.InnerText + " - " + DateTime.Today.ToString("dd-MMM-yyyy");
                        billDate.InnerText = DateTime.Now.ToString("dd-MMM-yyyy");
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
                nameLabel.InnerText = AllUsers[i].Apartment + " - " + AllUsers[i].Building;
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
       
        billAmount.InnerText = "";
        billDate.InnerText = "";
        billNo.InnerText = "";
        billPeriod.InnerText = "";
        dueDate.InnerText = "";
        UNameOfPrinter.InnerText = "";

        generateSideBarItems();

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