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
using App_Code.BillCalculate;


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
            get { return meter_2; }
            set { meter_2 = value; }
        }
        private string mode="auto";
        public string Mode
        {
            get { return mode; }
            set { mode = value; }
        }
        private double[] meter_1Readings = null;
        public double[] meter1Readings
        {
            get { return meter_1Readings; }
            set { meter_1Readings = value; }
        }
        private double[] meter_2Readings = null;
        public double[] meter2Readings        
        {
            get { return meter_2Readings; }
            set { meter_2Readings = value; }
        }

        public void calculatePrint(UserMapping userData)
        {
                headingTip.InnerText = tip_heading;
                headingText.InnerText = tip_text;

                CalculateBill billObj = Calculate_Bill.BillCalculator(fromDate, toDate, userData.Apartment, meter_1, meter_2,mode, meter_1Readings, meter_2Readings);
                string slabTxt="";
                if (billObj.ApplicableSlabs > 0)
                {
                    double tempUnits = billObj.TotalUnits;
                    for (int gh = 0; gh < billObj.ApplicableSlabs; gh++)
                    {
                        slabTxt =slabTxt+ billObj.SlabSizeArr[gh].ToString() + " X " + billObj.SlabChargeArr[gh].ToString() + " = " + billObj.SlabPriceArr[gh].ToString() + "<br />";
                    }
                }
                /*if (billObj.TotalUnits > billObj.SlabSize)
                {
                    if (billObj.TotalUnits > (2 * billObj.SlabSize))
                    {
                        slabTxt = billObj.SlabSize.ToString() + " X " + billObj.Slab1Charge.ToString() + " = " + billObj.Slab1Price.ToString();
                        slabTxt = slabTxt + "<br />" + billObj.SlabSize.ToString() + " X " + billObj.Slab2Charge.ToString() + " = " + billObj.Slab2Price.ToString();
                        slabTxt = slabTxt + "<br />" + (billObj.TotalUnits - (2 * billObj.SlabSize)).ToString() + " X " + billObj.Slab3Charge.ToString() + " = " + billObj.Slab3Price.ToString();
                    }
                    else
                    {
                        slabTxt = billObj.SlabSize.ToString() + " X " + billObj.Slab1Charge.ToString() + " = " + billObj.Slab1Price.ToString();
                        slabTxt = slabTxt + "<br />" + (billObj.TotalUnits - (billObj.SlabSize)).ToString() + " X " + billObj.Slab2Charge.ToString() + " = " + billObj.Slab2Price.ToString();
                    }
                }
                else
                {
                    slabTxt = slabTxt + "<br />" + (billObj.TotalUnits).ToString() + " X " + billObj.Slab1Charge.ToString() + " = " + billObj.Slab1Price.ToString();
                }
                */ 
                            if (meter_1 != null)
                            {
                                meterType1.Text = meter_1;
                                metTyp1Units.Text =billObj.Meter1Units.ToString();
                                metTyp1Units0.Text = billObj.Meter1InitialReading.ToString();
                                metTyp1Units1.Text = billObj.Meter1FinalReading.ToString();
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
                                metTyp2Units.Text = billObj.Meter2Units.ToString();
                                metTyp2Units0.Text =billObj.Meter2InitialReading.ToString();
                                metTyp2Units1.Text = billObj.Meter2FinalReading.ToString();
                            }
                            else
                            {
                                meterType2.Text = "";
                                metTyp2Units.Text = "";
                                metTyp2Units0.Text = "";
                                metTyp2Units1.Text = "";
                            }

                            dayTd.InnerHtml = "Days = " +billObj.BillDays.ToString(); totalUnits.Text = billObj.TotalUnits.ToString();

                            totalUnitsConsumed.Text =  billObj.TotalUnits.ToString();
                            slabText.InnerHtml = slabTxt;
                            fixedText.InnerHtml = billObj.FixedCharge.ToString()+ " X " + billObj.BillDays.ToString() + "(Days)";

                            totalSlabCharge.Text = billObj.SlabTotal.ToString();
                            totalFixCharge.Text = billObj.FixedPrice.ToString();

                            energyChrg.Text = billObj.SlabTotal.ToString();
                            fixChrg.Text = billObj.FixedPrice.ToString();
                            adjEnrgyChrg.Text = billObj.AdjChargeOnSlabTotal.ToString();
                            adjFixChrg.Text = billObj.AdjChargeOnFixedTotal.ToString();
                            defEnrgyChrg.Text = billObj.DefChargeOnSlabTotal.ToString();
                            defFixChrg.Text = billObj.DefChargeOnFixedTotal.ToString();
                            netEnrgyChrg.Text = billObj.NetSlabTotalAfterAllCharges.ToString();
                            netFixChrg.Text = billObj.NetFixedTotalAfterAllCharges.ToString();
                            subTotalTxt.Text = "Rs " + billObj.NetTotalBeforeElecticityTax.ToString();

                            elecTax.InnerHtml = "Electricity Tax (" + billObj.electricityTax.ToString() + "%) on (Rs " + billObj.NetTotalBeforeElecticityTax.ToString() + " ) = Rs " + billObj.ElectricityPrice.ToString();
                            netBillAmt.InnerHtml = "Net Bill Amount = Rs " + billObj.BillAmount.ToString();

                            billAmount.InnerHtml = "Bill Amount = Rs " +billObj.BillAmount.ToString();

                            address.InnerHtml = "Flat No: " + userData.Apartment + ", " + userData.Building + " (IIITD)," + " Okhla Phase III, Delhi";

                            meterNo.InnerText =userData.Apartment;
                            billPeriod.InnerText = fromDate.ToString("dd/MM/yyyy") + " to " + toDate.ToString("dd/MM/yyyy");
                            dueDate.InnerHtml = "Due Date: " + billObj.dueDate;
                            billNo.InnerText = "Rep " + meterNo.InnerText + " - " + DateTime.Today.ToString("dd-MMM-yyyy");
                            billDate.InnerText =billObj.billDate;
                        }
                    
                
           
    }
