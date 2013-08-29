using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Text;
using System.IO;
using System.Web.Script.Serialization;
using App_Code.Utility;

namespace App_Code.FetchingEnergySmap
{
    public class FetchEnergyDataSMap
    {

    }

    public static class FetchEnergyDataS_Map
    {
        static string uuid;
        static string sURL = "http://192.168.1.40:9101/api/query";
        static string stringData = "";
       
        public static void FetchPowerConsumption(string fromtime, string toTime, string flat, string type, out Int32[] timeSt, out double[] values)
        {
           
            timeSt = new int[1];
            values = new double[1];

            try
            {
                stringData = "select data in (" + fromtime + ", " + toTime + ") where Metadata/Extra/FlatNumber ='" + flat + "' and Metadata/Extra/PhysicalParameter='Power' and Metadata/Extra/Type='" + type + "'";

                HttpWebRequest req = WebRequest.Create(sURL) as HttpWebRequest;
                IWebProxy iwprxy = WebRequest.GetSystemWebProxy();
                req.Proxy = iwprxy;

                req.Method = "POST";
                req.ContentType = "";

                ASCIIEncoding encoding = new ASCIIEncoding();
                byte[] data = encoding.GetBytes(stringData);

                req.ContentLength = data.Length;

                Stream os = req.GetRequestStream();
                os.Write(data, 0, data.Length);
                os.Close();

                
                HttpWebResponse response = req.GetResponse() as HttpWebResponse;

                Stream objStream = req.GetResponse().GetResponseStream();

                StreamReader objReader = new StreamReader(objStream);

                var jss = new JavaScriptSerializer();

                string sline = objReader.ReadLine();

                var f1 = jss.Deserialize<dynamic>(sline);

                var f21 = f1[0];
                var f2 = f21["uuid"];
                var f3 = f21["Readings"];

                timeSt = new int[f3.Length];
                values = new double[f3.Length];

                for (int i = 0; i < f3.Length; i++)
                {
                    var f4 = f3[i];
                    timeSt[i] = Convert.ToInt32(f4[0] / 1000);
                    values[i] = Convert.ToDouble(f4[1]);
                }

                response.Close();
            }
            catch (Exception exp)
            {

            }

        }

        public static void FetchBarConsumption(string[] fromTimeArray, string[] toTimeArray, string flat, string type, out Int32[] timeSt, out double[] values)
        {
            timeSt = new int[toTimeArray.Length];
            values = new double[toTimeArray.Length];
            try
            {
                

                for (int j = 0; j < toTimeArray.Length; j++)
                {
                    HttpWebRequest req = WebRequest.Create(sURL) as HttpWebRequest;
                    IWebProxy iwprxy = WebRequest.GetSystemWebProxy();
                    req.Proxy = iwprxy;

                    req.Method = "POST";
                    req.ContentType = "";


                    stringData = "select data in ('" + fromTimeArray[j] + "' , '" + toTimeArray[j] + "') limit 1 where Metadata/Extra/FlatNumber ='" + flat + "' and Metadata/Extra/PhysicalParameter='Energy' and Metadata/Extra/Type='" + type + "'";

                    ASCIIEncoding encoding = new ASCIIEncoding();
                    byte[] data = encoding.GetBytes(stringData);

                    req.ContentLength = data.Length;

                    Stream os = req.GetRequestStream();
                    os.Write(data, 0, data.Length);
                    os.Close();

                    HttpWebResponse response = req.GetResponse() as HttpWebResponse;

                    Stream objStream = req.GetResponse().GetResponseStream();

                    StreamReader objReader = new StreamReader(objStream);

                    var jss = new JavaScriptSerializer();

                    string sline = objReader.ReadLine();

                    var f1 = jss.Deserialize<dynamic>(sline);

                    var f21 = f1[0];
                    var f2 = f21["uuid"];
                    var f3 = f21["Readings"];

                    for (int i = 0; i < f3.Length; i++)
                    {
                        var f4 = f3[i];
                        timeSt[j] = Convert.ToInt32(f4[0] / 1000);
                        values[j] =Convert.ToDouble(f4[1]);
                    }

                    response.Close();
                }
            }
            catch (Exception exp)
            {

            }
        }

        public static void FetchBillConsumption(int fromTime, int toTime, string flat, string type, out Int32[] timeSt, out double[] values)
        {

            timeSt = new int[2];
            values = new double[2];
            try
            {

                List<int> fromTim = new List<int>();
                fromTim.Add(fromTime);
                fromTim.Add(toTime - 300);

                List<int> toTim = new List<int>();
                toTim.Add(fromTime + 300);
                toTim.Add(toTime);

                string[] fromArr = Utilitie_S.SMapValidDateFormatter(fromTim);
                string[] toArr = Utilitie_S.SMapValidDateFormatter(toTim);

                for (int j = 0; j < fromArr.Length; j++)
                {
                    HttpWebRequest req = WebRequest.Create(sURL) as HttpWebRequest;
                    IWebProxy iwprxy = WebRequest.GetSystemWebProxy();
                    req.Proxy = iwprxy;

                    req.Method = "POST";
                    req.ContentType = "";


                    stringData = "select data in ('" + fromArr[j] + "' , '" + toArr[j] + "') limit 1 where Metadata/Extra/FlatNumber ='" + flat + "' and Metadata/Extra/PhysicalParameter='Energy' and Metadata/Extra/Type='" + type + "'";

                    ASCIIEncoding encoding = new ASCIIEncoding();
                    byte[] data = encoding.GetBytes(stringData);

                    req.ContentLength = data.Length;

                    Stream os = req.GetRequestStream();
                    os.Write(data, 0, data.Length);
                    os.Close();

                    HttpWebResponse response = req.GetResponse() as HttpWebResponse;

                    Stream objStream = req.GetResponse().GetResponseStream();

                    StreamReader objReader = new StreamReader(objStream);

                    var jss = new JavaScriptSerializer();

                    string sline = objReader.ReadLine();

                    var f1 = jss.Deserialize<dynamic>(sline);

                    var f21 = f1[0];
                    var f2 = f21["uuid"];
                    var f3 = f21["Readings"];


                    for (int i = 0; i < f3.Length; i++)
                    {
                        var f4 = f3[0];
                        timeSt[j] = Convert.ToInt32(f4[0] / 1000);
                        values[j] =Convert.ToDouble(f4[1]);

                    }
                    response.Close();
                }
            }
            catch (Exception exp)
            {

            }
        }

        public static void FetchAvgConsumption(string[] fromTimeArray, string[] toTimeArray, string location, string type, out Int32[] timeSt, out double[] values)
        {
            timeSt = new int[toTimeArray.Length];
            values = new double[toTimeArray.Length];

            try
            {
                for (int j = 0; j < toTimeArray.Length; j++)
                {
                    int count = 0;
                    HttpWebRequest req = WebRequest.Create(sURL) as HttpWebRequest;
                    IWebProxy iwprxy = WebRequest.GetSystemWebProxy();
                    req.Proxy = iwprxy;

                    req.Method = "POST";
                    req.ContentType = "";


                    stringData = "select data before '" + fromTimeArray[j] + "' limit 1 where Metadata/Location/Building ='" + location + "' and Metadata/Extra/PhysicalParameter='Energy' and Metadata/Extra/Type='" + type + "'";

                    ASCIIEncoding encoding = new ASCIIEncoding();
                    byte[] data = encoding.GetBytes(stringData);

                    req.ContentLength = data.Length;

                    Stream os = req.GetRequestStream();
                    os.Write(data, 0, data.Length);
                    os.Close();

                    HttpWebResponse response = req.GetResponse() as HttpWebResponse;

                    Stream objStream = req.GetResponse().GetResponseStream();

                    StreamReader objReader = new StreamReader(objStream);

                    var jss = new JavaScriptSerializer();

                    string sline = objReader.ReadLine();

                    var f1 = jss.Deserialize<dynamic>(sline);

                    for (int k = 0; k < f1.Length; k++)
                    {

                        var f21 = f1[k];
                        var f2 = f21["uuid"];
                        var f3 = f21["Readings"];

                        if (f3.Length > 0)
                        {
                            //if (count == 0)
                            //{
                            //    using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\BillingApp\avgData.txt", true))
                            //    {
                            //        file.WriteLine(sline);
                            //        file.WriteLine("\n ------------------------------------ \n");
                            //    }
                            //}
                            count++;
                            var f4 = f3[0];
                            timeSt[j] = Convert.ToInt32(f4[0] / 1000);
                            values[j] = values[j] + Convert.ToDouble(f4[1]);
                        }

                    }
                    if (count > 1)
                    {
                        values[j] = values[j] / count;
                    }

                    response.Close();
                }
            }
            catch (Exception exp)
            {

            }
        }

        public static void FetchBuildingData(string fromtime, string toTime, string building, string criteria, string meter_type, out Int32[] timeSt, out double[] values)
        {

            timeSt = new int[1];
            values = new double[1];

            try
            {
                stringData = "select data in (" + fromtime + ", " + toTime + ") limit 100000 where Metadata/Location/Building ='" + building + "' and Metadata/Extra/PhysicalParameter='" + criteria + "' and Metadata/Extra/Type='" + meter_type + "'";

                HttpWebRequest req = WebRequest.Create(sURL) as HttpWebRequest;
                IWebProxy iwprxy = WebRequest.GetSystemWebProxy();
                req.Proxy = iwprxy;

                req.Method = "POST";
                req.ContentType = "";

                ASCIIEncoding encoding = new ASCIIEncoding();
                byte[] data = encoding.GetBytes(stringData);

                req.ContentLength = data.Length;

                Stream os = req.GetRequestStream();
                os.Write(data, 0, data.Length);
                os.Close();


                HttpWebResponse response = req.GetResponse() as HttpWebResponse;

                Stream objStream = req.GetResponse().GetResponseStream();

                StreamReader objReader = new StreamReader(objStream);

                var jss = new JavaScriptSerializer();

                string sline = objReader.ReadLine();

                var f1 = jss.Deserialize<dynamic>(sline);

                var f21 = f1[0];
                var f2 = f21["uuid"];
                var f3 = f21["Readings"];

                timeSt = new int[f3.Length];
                values = new double[f3.Length];

                for (int i = 0; i < f3.Length; i++)
                {
                    var f4 = f3[i];
                    timeSt[i] = Convert.ToInt32(f4[0] / 1000);
                    values[i] = Convert.ToDouble(f4[1]);
                }

                response.Close();
            }
            catch (Exception exp)
            {

            }

        }

        public static void FetchBuildingAcademia(string fromtime, string toTime, string building, string criteria, string meter_type,string block, out Int32[] timeSt, out double[] values)
        {

            timeSt = new int[1];
            values = new double[1];

            try
            {
                stringData = "select data in (" + fromtime + ", " + toTime + ") limit 100000 where Metadata/Location/Building ='" + building + "' and Metadata/Extra/PhysicalParameter='" + criteria + "' and Metadata/Extra/Block = '" + block + "' and Metadata/Extra/Type='" + meter_type + "'";

                HttpWebRequest req = WebRequest.Create(sURL) as HttpWebRequest;
                IWebProxy iwprxy = WebRequest.GetSystemWebProxy();
                req.Proxy = iwprxy;

                req.Method = "POST";
                req.ContentType = "";

                ASCIIEncoding encoding = new ASCIIEncoding();
                byte[] data = encoding.GetBytes(stringData);

                req.ContentLength = data.Length;

                Stream os = req.GetRequestStream();
                os.Write(data, 0, data.Length);
                os.Close();


                HttpWebResponse response = req.GetResponse() as HttpWebResponse;

                Stream objStream = req.GetResponse().GetResponseStream();

                StreamReader objReader = new StreamReader(objStream);

                var jss = new JavaScriptSerializer();

                string sline = objReader.ReadLine();

                var f1 = jss.Deserialize<dynamic>(sline);

                var f21 = f1[0];
                var f2 = f21["uuid"];
                var f3 = f21["Readings"];

                timeSt = new int[f3.Length];
                values = new double[f3.Length];

                for (int i = 0; i < f3.Length; i++)
                {
                    var f4 = f3[i];
                    timeSt[i] = Convert.ToInt32(f4[0] / 1000);
                    values[i] = Convert.ToDouble(f4[1]);
                }

                response.Close();
            }
            catch (Exception exp)
            {

            }

        }

        public static void FetchBuildingHostels(string fromtime, string toTime, string building, string wing, string criteria, string meter_type, out Int32[] timeSt, out double[] values)
        {

            timeSt = new int[1];
            values = new double[1];

            try
            {
                stringData = "select data in (" + fromtime + ", " + toTime + ") limit 100000 where Metadata/Location/Building ='" + building + "' and Metadata/Extra/PhysicalParameter='" + criteria + "' and Metadata/Extra/Wing = '" + wing + "' and Metadata/Extra/Type='" + meter_type + "'";

                HttpWebRequest req = WebRequest.Create(sURL) as HttpWebRequest;
                IWebProxy iwprxy = WebRequest.GetSystemWebProxy();
                req.Proxy = iwprxy;

                req.Method = "POST";
                req.ContentType = "";

                ASCIIEncoding encoding = new ASCIIEncoding();
                byte[] data = encoding.GetBytes(stringData);

                req.ContentLength = data.Length;

                Stream os = req.GetRequestStream();
                os.Write(data, 0, data.Length);
                os.Close();


                HttpWebResponse response = req.GetResponse() as HttpWebResponse;

                Stream objStream = req.GetResponse().GetResponseStream();

                StreamReader objReader = new StreamReader(objStream);

                var jss = new JavaScriptSerializer();

                string sline = objReader.ReadLine();

                var f1 = jss.Deserialize<dynamic>(sline);

                var f21 = f1[0];
                var f2 = f21["uuid"];
                var f3 = f21["Readings"];

                timeSt = new int[f3.Length];
                values = new double[f3.Length];

                for (int i = 0; i < f3.Length; i++)
                {
                    var f4 = f3[i];
                    timeSt[i] = Convert.ToInt32(f4[0] / 1000);
                    values[i] = Convert.ToDouble(f4[1]);
                }

                response.Close();
            }
            catch (Exception exp)
            {

            }

        }

        public static void FetchWingsHostels(string fromtime, string toTime, string building, string wing, int floor, string criteria, string meter_type, out Int32[] timeSt, out double[] values)
        {

            timeSt = new int[1];
            values = new double[1];

            try
            {
                stringData = "select data in (" + fromtime + ", " + toTime + ") limit 100000 where Metadata/Location/Building ='" + building + "' and Metadata/Location/Floor =" + floor + " and Metadata/Extra/PhysicalParameter='" + criteria + "' and Metadata/Extra/Wing = '" + wing + "' and Metadata/Extra/Type='" + meter_type + "'";

                HttpWebRequest req = WebRequest.Create(sURL) as HttpWebRequest;
                IWebProxy iwprxy = WebRequest.GetSystemWebProxy();
                req.Proxy = iwprxy;

                req.Method = "POST";
                req.ContentType = "";

                ASCIIEncoding encoding = new ASCIIEncoding();
                byte[] data = encoding.GetBytes(stringData);

                req.ContentLength = data.Length;

                Stream os = req.GetRequestStream();
                os.Write(data, 0, data.Length);
                os.Close();


                HttpWebResponse response = req.GetResponse() as HttpWebResponse;

                Stream objStream = req.GetResponse().GetResponseStream();

                StreamReader objReader = new StreamReader(objStream);

                var jss = new JavaScriptSerializer();

                string sline = objReader.ReadLine();

                var f1 = jss.Deserialize<dynamic>(sline);

                var f21 = f1[0];
                var f2 = f21["uuid"];
                var f3 = f21["Readings"];

                timeSt = new int[f3.Length];
                values = new double[f3.Length];

                for (int i = 0; i < f3.Length; i++)
                {
                    var f4 = f3[i];
                    timeSt[i] = Convert.ToInt32(f4[0] / 1000);
                    values[i] = Convert.ToDouble(f4[1]);
                }

                response.Close();
            }
            catch (Exception exp)
            {

            }

        }

        public static void FetchBuildingTotal(string frtime, string totime, string building, string block_wing, string criteria, string meter_type, out Int32 timeSt, out double values)
        {
            timeSt = 0;
            values = 0;
           
            try
            {
                
                if (building == "Academic Building")
                {
                    stringData = "select data in ("+frtime+", "+totime+") limit 1 where Metadata/Location/Building ='" + building + "' and Metadata/Extra/PhysicalParameter='" + criteria + "' and Metadata/Extra/Block = '" + block_wing + "' and Metadata/Extra/Type='" + meter_type + "'";
                }
                if (building == "Mess Building" || building == "Library Building" || building == "Faculty Housing")
                {
                    stringData = "select data in (" + frtime + ", " + totime + ") limit 1 where Metadata/Location/Building ='" + building + "' and Metadata/Extra/PhysicalParameter='" + criteria + "' and Metadata/Extra/Type='" + meter_type + "'";
                }
                if (building == "Girls Hostel" || building=="Boys Hostel")
                {
                    stringData = "select data in (" + frtime + ", " + totime + ") limit 1 where Metadata/Location/Building ='" + building + "' and Metadata/Extra/PhysicalParameter='" + criteria + "' and Metadata/Extra/Wing = '" + block_wing + "' and Metadata/Extra/Type='" + meter_type + "'";
                }
              
                HttpWebRequest req = WebRequest.Create(sURL) as HttpWebRequest;
                IWebProxy iwprxy = WebRequest.GetSystemWebProxy();
                req.Proxy = iwprxy;

                req.Method = "POST";
                req.ContentType = "";
                
                ASCIIEncoding encoding = new ASCIIEncoding();
                byte[] data = encoding.GetBytes(stringData);

                req.ContentLength = data.Length;

                Stream os = req.GetRequestStream();
                os.Write(data, 0, data.Length);
                os.Close();


                HttpWebResponse response = req.GetResponse() as HttpWebResponse;

                Stream objStream = req.GetResponse().GetResponseStream();

                StreamReader objReader = new StreamReader(objStream);

                var jss = new JavaScriptSerializer();

                string sline = objReader.ReadLine();

                var f1 = jss.Deserialize<dynamic>(sline);

                var f21 = f1[0];
                var f2 = f21["uuid"];
                var f3 = f21["Readings"];

              
                for (int i = 0; i < f3.Length; i++)
                {
                    var f4 = f3[i];
                    timeSt = Convert.ToInt32(f4[0] / 1000);
                    values = Convert.ToDouble(f4[1]);
                }

                response.Close();
            }
            catch (Exception exp)
            {

            }

        }

        public static void FetchBuildingBarConsumption(string[] frtime, string[] totime, string building, string block_wing, string meter_type, out Int32[] timeSt, out double[] values)
        {
            string criteria = "Energy";
            timeSt = new int[totime.Length];
            values = new double[totime.Length];
            try
            {
                
                for (int j = 0; j < totime.Length; j++)
                {
                    HttpWebRequest req = WebRequest.Create(sURL) as HttpWebRequest;
                    IWebProxy iwprxy = WebRequest.GetSystemWebProxy();
                    req.Proxy = iwprxy;

                    req.Method = "POST";
                    req.ContentType = "";

                    if (building == "Academic Building")
                    {
                        stringData = "select data in ('" + frtime[j] + "' , '" + totime[j] + "') limit 1 where Metadata/Location/Building ='" + building + "' and Metadata/Extra/PhysicalParameter='" + criteria + "' and Metadata/Extra/Block = '" + block_wing + "' and Metadata/Extra/Type='" + meter_type + "'";
                    }
                    if (building == "Mess Building" || building == "Library Building" || building == "Faculty Housing")
                    {
                        stringData = "select data in ('" + frtime[j] + "' , '" + totime[j] + "') limit 1 where Metadata/Location/Building ='" + building + "' and Metadata/Extra/PhysicalParameter='" + criteria + "' and Metadata/Extra/Type='" + meter_type + "'";
                    }
                    if (building == "Girls Hostel" || building == "Boys Hostel")
                    {
                        stringData = "select data in ('" + frtime[j] + "' , '" + totime[j] + "') limit 1 where Metadata/Location/Building ='" + building + "' and Metadata/Extra/PhysicalParameter='" + criteria + "' and Metadata/Extra/Wing = '" + block_wing + "' and Metadata/Extra/Type='" + meter_type + "'";
                    }

                    ASCIIEncoding encoding = new ASCIIEncoding();
                    byte[] data = encoding.GetBytes(stringData);

                    req.ContentLength = data.Length;

                    Stream os = req.GetRequestStream();
                    os.Write(data, 0, data.Length);
                    os.Close();

                    HttpWebResponse response = req.GetResponse() as HttpWebResponse;

                    Stream objStream = req.GetResponse().GetResponseStream();

                    StreamReader objReader = new StreamReader(objStream);

                    var jss = new JavaScriptSerializer();

                    string sline = objReader.ReadLine();

                    var f1 = jss.Deserialize<dynamic>(sline);

                    var f21 = f1[0];
                    var f2 = f21["uuid"];
                    var f3 = f21["Readings"];

                    for (int i = 0; i < f3.Length; i++)
                    {
                        var f4 = f3[i];
                        timeSt[j] = Convert.ToInt32(f4[0] / 1000);
                        values[j] = Convert.ToDouble(f4[1]);
                    }

                    response.Close();
                }
            }
            catch (Exception exp)
            {

            }
        }

        public static void PingingMeter(string building, string meter_id, out bool status)
        {

          int[]  timeSt = new int[1];
          double[]  values = new double[1];
          status = false;

            try
            {
                stringData = "select data in (now -5minutes, now) limit 1 where Metadata/Extra/PhysicalParameter='Power' and Metadata/Extra/MeterID='" + meter_id + "'";

                HttpWebRequest req = WebRequest.Create(sURL) as HttpWebRequest;
                IWebProxy iwprxy = WebRequest.GetSystemWebProxy();
                req.Proxy = iwprxy;

                req.Method = "POST";
                req.ContentType = "";

                ASCIIEncoding encoding = new ASCIIEncoding();
                byte[] data = encoding.GetBytes(stringData);

                req.ContentLength = data.Length;

                Stream os = req.GetRequestStream();
                os.Write(data, 0, data.Length);
                os.Close();


                HttpWebResponse response = req.GetResponse() as HttpWebResponse;

                Stream objStream = req.GetResponse().GetResponseStream();

                StreamReader objReader = new StreamReader(objStream);

                var jss = new JavaScriptSerializer();

                string sline = objReader.ReadLine();

                var f1 = jss.Deserialize<dynamic>(sline);

                var f21 = f1[0];
                var f2 = f21["uuid"];
                var f3 = f21["Readings"];

                timeSt = new int[f3.Length];
                values = new double[f3.Length];

                for (int i = 0; i < f3.Length; i++)
                {
                    var f4 = f3[i];
                    timeSt[i] = Convert.ToInt32(f4[0] / 1000);
                    values[i] = Convert.ToDouble(f4[1]);
                }

                if (values.Length >= 1)
                {
                    status = true;
                }
                

                response.Close();
            }
            catch (Exception exp)
            {

            }

        }

        public static void ListingMeter(string building, out string[] meterIDs)
        {

            meterIDs = new string[1];

            try
            {
                stringData = "select distinct Metadata/Extra/MeterID where Metadata/Location/Building ='" + building + "'";

                HttpWebRequest req = WebRequest.Create(sURL) as HttpWebRequest;
                IWebProxy iwprxy = WebRequest.GetSystemWebProxy();
                req.Proxy = iwprxy;

                req.Method = "POST";
                req.ContentType = "";

                ASCIIEncoding encoding = new ASCIIEncoding();
                byte[] data = encoding.GetBytes(stringData);

                req.ContentLength = data.Length;

                Stream os = req.GetRequestStream();
                os.Write(data, 0, data.Length);
                os.Close();


                HttpWebResponse response = req.GetResponse() as HttpWebResponse;

                Stream objStream = req.GetResponse().GetResponseStream();

                StreamReader objReader = new StreamReader(objStream);

                var jss = new JavaScriptSerializer();

                string sline = objReader.ReadLine();

                var f1 = jss.Deserialize<dynamic>(sline);
                
                meterIDs = new string[f1.Length];

                for (int i = 0; i < f1.Length; i++)
                {
                   
                    meterIDs[i] = f1[i];
                }
                
                response.Close();
            }
            catch (Exception exp)
            {

            }

        }

        public static void GetMeterByID(string meterID,string param, out double value, out int time)
        {
            value = 0; time = 0;            

            try
            {
                stringData = "select data before now where Metadata/Extra/MeterID = '" + meterID + "' and Metadata/Extra/PhysicalParameter='"+param+"'";

                HttpWebRequest req = WebRequest.Create(sURL) as HttpWebRequest;
                IWebProxy iwprxy = WebRequest.GetSystemWebProxy();
                req.Proxy = iwprxy;

                req.Method = "POST";
                req.ContentType = "";

                ASCIIEncoding encoding = new ASCIIEncoding();
                byte[] data = encoding.GetBytes(stringData);

                req.ContentLength = data.Length;

                Stream os = req.GetRequestStream();
                os.Write(data, 0, data.Length);
                os.Close();


                HttpWebResponse response = req.GetResponse() as HttpWebResponse;

                Stream objStream = req.GetResponse().GetResponseStream();

                StreamReader objReader = new StreamReader(objStream);

                var jss = new JavaScriptSerializer();

                string sline = objReader.ReadLine();

                var f1 = jss.Deserialize<dynamic>(sline);

                var f21 = f1[0];
                var f2 = f21["uuid"];
                var f3 = f21["Readings"];
                if (f3.Length > 0)
                {
                    var f4 = f3[0];
                    time = Convert.ToInt32(f4[0] / 1000);
                    value = Convert.ToDouble(f4[1]);
                }
              
                response.Close();
            }
            catch (Exception exp)
            {

            }

        }

        public static void GetMeterLocationByID(string meterID, out string building, out string floor, out string wing, out string flat, out string block, out string type)
        {
            building = ""; floor = ""; wing = "";
            flat = ""; block = ""; type = "";

            try
            {
                stringData = "select Metadata/Location/Building, Metadata/Location/Floor, Metadata/Extra/Wing, Metadata/Extra/FlatNumber, Metadata/Extra/Block, Metadata/Extra/Type where Metadata/Extra/MeterID = '" + meterID + "'";

                HttpWebRequest req = WebRequest.Create(sURL) as HttpWebRequest;
                IWebProxy iwprxy = WebRequest.GetSystemWebProxy();
                req.Proxy = iwprxy;

                req.Method = "POST";
                req.ContentType = "";

                ASCIIEncoding encoding = new ASCIIEncoding();
                byte[] data = encoding.GetBytes(stringData);

                req.ContentLength = data.Length;

                Stream os = req.GetRequestStream();
                os.Write(data, 0, data.Length);
                os.Close();


                HttpWebResponse response = req.GetResponse() as HttpWebResponse;

                Stream objStream = req.GetResponse().GetResponseStream();

                StreamReader objReader = new StreamReader(objStream);

                var jss = new JavaScriptSerializer();

                string sline = objReader.ReadLine();

                var f1 = jss.Deserialize<dynamic>(sline);

                var f11 = f1[0];
                var f12 = f11["Metadata"];
                var f2 = f12["Location"]; var f3 = f12["Extra"];
                var f21 = f2["Building"]; var f31 = f3["Wing"];
                var f22 = f2["Floor"]; var f32 = f3["FlatNumber"]; var f33 = f3["Block"];var f34 = f3["Type"];

                building = f21; floor = f22; wing = f31;
                block = f33; flat = f32; type = f34;
                response.Close();
            }
            catch (Exception exp)
            {

            }

        }

    }
}