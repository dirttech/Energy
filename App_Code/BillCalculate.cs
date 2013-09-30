﻿using System;
using System.Collections.Generic;
using System.Web;
using App_Code.User_Mapping;
using App_Code.FetchingEnergySmap;
using App_Code.Utility;

namespace App_Code.BillCalculate
{
    public class CalculateBill
    {
        public CalculateBill()
        {

        }

        private DateTime fromDate;
        public DateTime FromDate
        {
            get { return fromDate; }
            set { fromDate = value; }
        }
        private DateTime toDate;
        public DateTime ToDate
        {
            get { return toDate; }
            set { toDate = value; }
        }

        private string meter_1;
        public string Meter_1
        {
            get { return meter_1; }
            set { meter_1 = value; }
        }
        private string meter_2;
        public string Meter_2
        {
            get { return meter_2; }
            set { meter_2 = value; }
        }

        private double meter1Units;
        public  double Meter1Units
        {
            get { return meter1Units; }
            set { meter1Units = value; }
        }
        private double meter1InitialReading;
        public double Meter1InitialReading
        {
            get { return meter1InitialReading; }
            set { meter1InitialReading = value; }
        }
        private double meter1FinalReading;
        public double Meter1FinalReading
        {
            get { return meter1FinalReading; }
            set { meter1FinalReading = value; }
        }

        private double meter2Units;
        public double Meter2Units
        {
            get { return meter2Units; }
            set { meter2Units = value; }
        }
        private double meter2InitialReading;
        public double Meter2InitialReading
        {
            get { return meter2InitialReading; }
            set { meter2InitialReading = value; }
        }
        private double meter3FinalReading;
        public double Meter3FinalReading
        {
            get { return meter3FinalReading; }
            set { meter3FinalReading = value; }
        }

        private double totalUnits;
        public double TotalUnits
        {
            get { return totalUnits; }
            set { totalUnits = value; }
        }
        private int billDays;
        public int BillDays
        {
            get { return billDays; }
            set { billDays = value; }
        }

        private double slab1Size;
        public double Slab1Size
        {
            get { return slab1Size; }
            set { slab1Size = value; }
        }
        public double Slab1Charge= 3.7;        
        private double slab1Price=0;
        public double Slab1Price
        {
            get { return slab1Price; }
            set { slab1Price = value; }
        }

        private double slab2Size;
        public double Slab2Size
        {
            get { return slab2Size; }
            set { slab2Size = value; }
        }
        public double Slab2Charge = 5.5;        
        private double slab2Price=0;
        public double Slab2Price
        {
            get { return slab2Price; }
            set { slab2Price = value; }
        }

        private double slab3Size;
        public double Slab3Size
        {
            get { return slab3Size; }
            set { slab3Size = value; }
        }
        public double Slab3Charge= 6.5;        
        private double slab3Price=0;
        public double Slab3Price
        {
            get { return slab3Price; }
            set { slab3Price = value; }
        }

        private double slabTotal;
        public double SlabTotal
        {
            get { return slabTotal; }
            set { slabTotal = value; }
        }

        public int FixedCharge=6;
        public double adjCharge = 1.5;
        public int defCharge = 8;
        public int electricityTax = 5;

        private double fixedPrice;
        public double FixedPrice
        {
            get { return fixedPrice; }
            set { fixedPrice = value; }
        }

        private double adjChargeOnSlabTotal;
        public double AdjChargeOnSlabTotal
        {
            get { return adjChargeOnSlabTotal; }
            set { adjChargeOnSlabTotal = value; }
        }
        private double defChargeOnSlabTotal;
        public double DefChargeOnSlabTotal
        {
            get { return defChargeOnSlabTotal; }
            set { defChargeOnSlabTotal = value; }
        }
        private double netSlabTotalAfterAllCharges;
        public double NetSlabTotalAfterAllCharges
        {
            get { return netSlabTotalAfterAllCharges; }
            set { netSlabTotalAfterAllCharges = value; }
        }

        private double adjChargeOnFixedTotal;
        public double AdjChargeOnFixedTotal
        {
            get { return adjChargeOnFixedTotal; }
            set { adjChargeOnFixedTotal = value; }
        }
        private double defChargeOnFixedTotal;
        public double DefChargeOnFixedTotal
        {
            get { return defChargeOnFixedTotal; }
            set { defChargeOnFixedTotal = value; }
        }
        private double netFixedTotalAfterAllCharges;
        public double NetFixedTotalAfterAllCharges
        {
            get { return netFixedTotalAfterAllCharges; }
            set { netFixedTotalAfterAllCharges = value; }
        }

        private double netTotalBeforeElecticityTax;
        public double NetTotalBeforeElecticityTax
        {
            get { return netTotalBeforeElecticityTax; }
            set {  netTotalBeforeElecticityTax = value; }
        }

        private double electricityPrice;
        public double ElectricityPrice
        {
            get { return electricityPrice; }
            set { electricityPrice = value; }
        }

        private double billAmount;
        public double BillAmount
        {
            get { return billAmount; }
            set { billAmount = value; }
        }

        public string billDate = DateTime.Now.ToString("dd-MMM-yyyy");
        public string dueDate = DateTime.Now.AddDays(7).ToString("dd-MMM-yyyy");
       
    }
    public static class Calculate_Bill
    {
        public static CalculateBill BillCalculator(DateTime FromDate, DateTime ToDate, string Apartment, string Meter_1, string Meter_2)
        {
            //Meter1 Power
            //Meter2 Lighting
          
            CalculateBill calculateObj = new CalculateBill();
            try
            {
                UserMapping map = UserMapping_S.UserMapWithApartmentBuilding("Faculty Housing", Apartment);
                if (map != null)
                {
                    //Reading Date and defining start and endtimes for bill calculation
                    calculateObj.FromDate = FromDate;
                    calculateObj.ToDate = ToDate;

                    int day = calculateObj.FromDate.Day;
                    int month = calculateObj.FromDate.Month;
                    int year = calculateObj.FromDate.Year;

                    calculateObj.FromDate = new DateTime(year, month, day, 0, 0, 1);  //Start Time

                    day = calculateObj.ToDate.Day;
                    month = calculateObj.ToDate.Month;
                    year = calculateObj.ToDate.Year;
                    calculateObj.ToDate = new DateTime(year, month, day, 23, 59, 59);             //End Time

                    if (calculateObj.FromDate != null && calculateObj.ToDate != null)
                    {
                        Utilities utFr = Utilitie_S.DateTimeToEpoch(calculateObj.FromDate);        //Converting datetime to unix time. These functions are defined in Utilities.cs file
                        Utilities utTo = Utilitie_S.DateTimeToEpoch(calculateObj.ToDate);

                        int[] timeStMet1 = new int[2]; double[] valuesMet1 = new double[2];
                        if (Meter_1 != null)
                        {//Energy Consumption for meter 1
                            FetchEnergyDataS_Map.FetchBillConsumption(utFr.Epoch, utTo.Epoch, map.Apartment, Meter_1, out timeStMet1, out valuesMet1);
                            Utilitie_S.ZeroArrayRefiner(timeStMet1, valuesMet1, out timeStMet1, out valuesMet1);
                            calculateObj.Meter_1 = Meter_1;
                        }
                        int[] timeStMet2 = new int[2]; double[] valuesMet2 = new double[2];
                        if (Meter_2 != null)
                        {//Energy Consumption for meter 2
                            FetchEnergyDataS_Map.FetchBillConsumption(utFr.Epoch, utTo.Epoch, map.Apartment, Meter_2, out timeStMet2, out valuesMet2);
                            Utilitie_S.ZeroArrayRefiner(timeStMet2, valuesMet2, out timeStMet2, out valuesMet2);
                            calculateObj.Meter_2 = Meter_2;
                        }

                        if (valuesMet1 != null || valuesMet2 != null)
                        {
                            double lightingUnits = 0, powerUnits = 0;                   //Initializing and calculating units consumed in next step
                            if (Meter_1 != null)
                            {
                                powerUnits = Math.Round(((valuesMet1[1] - valuesMet1[0]) / 1000), 2);
                                calculateObj.Meter1Units = powerUnits;
                            }
                            if (Meter_2 != null)
                            {
                                lightingUnits = Math.Round(((valuesMet2[1] - valuesMet2[0]) / 1000), 2);
                                calculateObj.Meter2Units = lightingUnits;
                            }
                            double totalUnit = lightingUnits + powerUnits;              //Total units consumed for both light and power meters(1&2)
                            calculateObj.TotalUnits = totalUnit;
                            int dayNo = ((utTo.Epoch - utFr.Epoch) / (60 * 60 * 24)) + 1;     //Calculating for how much time we did billing (in days)
                            calculateObj.BillDays = dayNo;

                            double slabSize = 6.67;   //Slab charges and slab size for one day
                            double SL1PRC = 0; double SL2PRC = 0; double SL3PRC = 0;                                    //Initialize sla price varibales
                            double daslb = dayNo * slabSize; daslb = Math.Round(daslb, 2);                              //Calculating Slab size for Bill Period for each slab category

                            if (totalUnit > daslb)
                            {//This if else is used to calculate number of slabs corresponding to units consumed and price for each.
                                if (totalUnit >= (2 * daslb))
                                {
                                    SL1PRC = Math.Round(calculateObj.Slab1Charge * daslb, 2);
                                    calculateObj.Slab1Price = SL1PRC;
                                    SL2PRC = Math.Round(calculateObj.Slab2Charge * daslb, 2);
                                    calculateObj.Slab2Price = SL2PRC;
                                    SL3PRC = Math.Round(calculateObj.Slab3Charge * (totalUnit - (2 * daslb)), 2);
                                    calculateObj.Slab3Price = SL3PRC;
                                }
                                else
                                {
                                    SL1PRC = Math.Round(calculateObj.Slab1Charge * daslb, 2);
                                    calculateObj.Slab1Price = SL1PRC;
                                    SL2PRC = Math.Round(calculateObj.Slab2Charge * (totalUnit - (daslb)), 2);
                                    calculateObj.Slab1Price = SL1PRC;
                                }
                            }
                            else
                            {
                                SL1PRC = Math.Round(calculateObj.Slab1Charge * totalUnit, 2);
                                calculateObj.Slab1Price = SL1PRC;
                            }

                            double TotalPRC = SL1PRC + SL2PRC + SL3PRC;                     //Total price(Adding Slabs)
                            calculateObj.SlabTotal = TotalPRC;
                            double FIXED_CHRG = calculateObj.FixedCharge;                                          //Fixed charge per day
                            double FIXED_PRC = FIXED_CHRG * dayNo;                          //Fixed charge for Bill Period
                            calculateObj.FixedPrice = FIXED_PRC;

                            double Adj_PRCNT = calculateObj.adjCharge;
                            double Def_PRCNT = calculateObj.defCharge;                                                        //percentage for both adjacent and def. charges

                            double Adj_Total_PRC = Math.Round((Adj_PRCNT / 100) * TotalPRC, 2);             //Calculating both charges on Total Price
                            calculateObj.AdjChargeOnSlabTotal = Adj_Total_PRC;
                            double Def_Total_PRC = Math.Round((Def_PRCNT / 100) * TotalPRC, 2);
                            calculateObj.DefChargeOnSlabTotal = Def_Total_PRC;

                            double Adj_FIX_PRC = Math.Round((Adj_PRCNT / 100) * FIXED_PRC, 2);              //Calculating both charges on Fixed Price
                            calculateObj.AdjChargeOnFixedTotal = Adj_FIX_PRC;
                            double Def_FIX_PRC = Math.Round((Def_PRCNT / 100) * FIXED_PRC, 2);
                            calculateObj.DefChargeOnFixedTotal = Def_FIX_PRC;

                            double temp1 = TotalPRC + Adj_Total_PRC + Def_Total_PRC;                        //Temporary Totals                         
                            double temp2 = FIXED_PRC + Adj_FIX_PRC + Def_FIX_PRC;
                            temp1 = Math.Round(temp1, 2); calculateObj.NetSlabTotalAfterAllCharges = temp1;          //Rounding off temp totals
                            temp2 = Math.Round(temp2, 2); calculateObj.NetFixedTotalAfterAllCharges = temp2;

                            double subTotal = temp1 + temp2;                                                //Total bill before Electricity Tax
                            calculateObj.NetTotalBeforeElecticityTax = subTotal;

                            double ELEC_CHRG_PRCNT = calculateObj.electricityTax;
                            double ELEC_TAX = (ELEC_CHRG_PRCNT / 100) * subTotal;                           //Electricity charge (5%) calculations
                            ELEC_TAX = Math.Round(ELEC_TAX, 2);
                            calculateObj.ElectricityPrice = ELEC_TAX;

                            double Final_Total = subTotal + ELEC_TAX;                                       //Final total (Your Bill Amount) after all taxes/charges
                            calculateObj.BillAmount = Final_Total;
                        }
                    }
                }
            }
            catch (Exception exp)
            {

            }
            return calculateObj;
        }
    //end
    }       
}