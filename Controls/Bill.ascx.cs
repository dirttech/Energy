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

public partial class Controls_Bill : System.Web.UI.UserControl
{

    protected void Page_Load(object sender, EventArgs e)
    {
    //    fullName.InnerText = "";
    //    address.InnerText = "";
    //    mobile.InnerText = "";
    //    meterNo.InnerText = "";
    //    billAmount.InnerText = "";
    //    billDate.InnerText = "";
    //    billNo.InnerText = "";
    //    billPeriod.InnerText = "";
    //    dueDate.InnerText = "";
        
    }
    private DateTime fr_Date;
    public DateTime fromDate
    {
        get { return fr_Date; }
        set { fr_Date = value; }
    }
    private DateTime to_Date;
    public DateTime toDate
    {
        get { return to_Date; }
        set { to_Date = value; }
    }
    private string tip_heading;
    public string tipHeading
    {
        get { return tip_heading; }
        set { tip_heading = value; }
    }
    private string tip_text;
    public string tipText
    {
        get { return tip_text; }
        set { tip_text = value; }
    }
    private string meter_1;
    public string meter1
    {
        get { return meter_1; }
        set { meter_1 = value; }
    }
    private string meter_2;
    public string meter2
    {
        get { return meter_2 ; }
        set { meter_2 = value; }
    }


    public void calculatePrint(UserMapping userData)
    {
        try
        {
            headingTip.InnerText = tip_heading;
            headingText.InnerText = tip_text;

            UserMapping map = UserMapping_S.UserMapWithApartmentBuilding("Faculty Housing", userData.Apartment);
            if (map != null)
            {
                DateTime frDate = fromDate;
                DateTime tDate = toDate;

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

                    int[] timeStMet1=new int[2]; double[] valuesMet1=new double[2];
                    if (meter_1 != null)
                    {
                        FetchEnergyDataS_Map.FetchBillConsumption(utFr.Epoch, utTo.Epoch, map.Apartment, meter_1, out timeStMet1, out valuesMet1);
                        Utilitie_S.ZeroArrayRefiner(timeStMet1, valuesMet1, out timeStMet1, out valuesMet1);
                    }

                    int[] timeStMet2=new int[2]; double[] valuesMet2=new double[2];
                    if (meter_2 != null)
                    {
                        FetchEnergyDataS_Map.FetchBillConsumption(utFr.Epoch, utTo.Epoch, map.Apartment, meter_2, out timeStMet2, out valuesMet2);
                        Utilitie_S.ZeroArrayRefiner(timeStMet2, valuesMet2, out timeStMet2, out valuesMet2);
                    }

                    
                    if (valuesMet1!=null || valuesMet2!=null)
                    {
                        double lightingUnits=0;
                        double powerUnits=0;

                        if (meter_1 != null)
                        {
                            powerUnits = Math.Round(((valuesMet1[1] - valuesMet1[0]) / 1000), 2);                            
                        }
                        if (meter_2 != null)
                        {
                            lightingUnits = Math.Round(((valuesMet2[1] - valuesMet2[0]) / 1000), 2);
                        }

                        double totalUnit = lightingUnits + powerUnits;

                        int dayNo = (utTo.Epoch - utFr.Epoch) / (60 * 60 * 24);

                        double SL1CHRG = 3.7; double SL2CHRG = 5.5; double SL3CHRG = 6.5; double slabSize = 6.67;
                        double SL1PRC = 0; double SL2PRC = 0; double SL3PRC = 0;
                        string slabTxt = "";
                        double daslb = dayNo * slabSize;
                        daslb = Math.Round(daslb, 2);

                        if (totalUnit > daslb)
                        {
                            if (totalUnit >= (2 * daslb))
                            {
                                SL1PRC =Math.Round( SL1CHRG * daslb,2);
                                slabTxt = (daslb).ToString() + " X " + SL1CHRG.ToString() + " = " + SL1PRC.ToString();
                                SL2PRC = Math.Round(SL2CHRG * daslb,2);
                                slabTxt = slabTxt + "<br />" + (daslb).ToString() + " X " + SL2CHRG.ToString() + " = " + SL2PRC.ToString();
                                SL3PRC = Math.Round(SL3CHRG * (totalUnit - (2 * daslb)),2);
                                slabTxt = slabTxt + "<br />" + (totalUnit - (2 * daslb)).ToString() + " X " + SL3CHRG.ToString() + " = " + SL3PRC.ToString();
                            }
                            else
                            {
                                SL1PRC = Math.Round(SL1CHRG * daslb,2);
                                slabTxt = (daslb).ToString() + " X " + SL1CHRG.ToString() + " = " + SL1PRC.ToString();
                                SL2PRC = Math.Round(SL2CHRG * (totalUnit - (daslb)),2);
                                slabTxt = slabTxt + "<br />" + (totalUnit - (daslb)).ToString() + " X " + SL2CHRG.ToString() + " = " + SL2PRC.ToString();
                            }
                        }
                        else
                        {
                            SL1PRC = Math.Round(SL1CHRG * totalUnit,2);
                            slabTxt = (daslb).ToString() + " X " + SL1CHRG.ToString() + " = " + SL1PRC.ToString();
                        }

                        double TotalPRC = SL1PRC + SL2PRC + SL3PRC;
                        double FIXED_CHRG = 6;
                        double FIXED_PRC = FIXED_CHRG * dayNo;

                        double Adj_PRCNT = 1.5;
                        double Def_PRCNT = 8;

                        double Adj_Total_PRC =Math.Round((Adj_PRCNT / 100) * TotalPRC,2);
                        double Def_Total_PRC =Math.Round((Def_PRCNT / 100) * TotalPRC,2);

                        double Adj_FIX_PRC = Math.Round((Adj_PRCNT / 100) * FIXED_PRC,2);
                        double Def_FIX_PRC = Math.Round((Def_PRCNT / 100) * FIXED_PRC,2);

                        double temp1 = TotalPRC + Adj_Total_PRC + Def_Total_PRC;
                        double temp2 = FIXED_PRC + Adj_FIX_PRC + Def_FIX_PRC;

                        temp1 = Math.Round(temp1, 2);
                        temp2 = Math.Round(temp2, 2);

                        double subTotal = temp1 + temp2;

                        double ELEC_CHRG_PRCNT = 5;
                        double ELEC_TAX = (ELEC_CHRG_PRCNT / 100) * subTotal;
                        ELEC_TAX = Math.Round(ELEC_TAX, 2);

                        double Final_Total = subTotal + ELEC_TAX;

                        if (meter_1 != null)
                        {
                            meterType1.Text = meter_1;
                            metTyp1Units.Text = powerUnits.ToString();
                            metTyp1Units0.Text = (Math.Round(valuesMet1[0] / 1000, 2)).ToString();
                            metTyp1Units1.Text = (Math.Round(valuesMet1[1] / 1000, 2)).ToString();
                        }
                        else
                        {
                            meterType1.Text = "";
                            metTyp1Units.Text = "";
                            metTyp1Units0.Text = "";
                            metTyp1Units1.Text = "";
                        }

                        if (meter_2 != null)
                        {
                            meterType2.Text = meter_2;
                            metTyp2Units.Text = lightingUnits.ToString();
                            metTyp2Units0.Text = (Math.Round(valuesMet2[0] / 1000, 2)).ToString();
                            metTyp2Units1.Text = (Math.Round(valuesMet2[1] / 1000, 2)).ToString();
                        }
                        else
                        {
                            meterType2.Text = "";
                            metTyp2Units.Text = "";
                            metTyp2Units0.Text = "";
                            metTyp2Units1.Text = "";
                        }

                        dayTd.InnerHtml = "Days = " + dayNo.ToString(); totalUnits.Text = totalUnit.ToString();

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


                        subTotalTxt.Text = "Rs " + subTotal.ToString();
                        elecTax.InnerHtml = "Electricity Tax (" + ELEC_CHRG_PRCNT.ToString() + "%) on (Rs " + subTotal.ToString() + " ) = Rs " + ELEC_TAX.ToString();
                        netBillAmt.InnerHtml = "Net Bill Amount = Rs " + Math.Round(Final_Total, 2).ToString();

                        billAmount.InnerHtml = "Bill Amount = Rs " + Math.Round(Final_Total, 2).ToString();

                        /****888888888888888888888888888888*******************************/
                        address.InnerHtml = "Flat No: " + map.Apartment + ", " + map.Building + " (IIITD)," + " Okhla Phase III, Delhi";

                        meterNo.InnerText = map.Apartment;
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
}