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
        

        ///<summary>
        ///To Fetch Power data for Apartment between given time limit 
        ///</summary>        
        public static void FetchPowerConsumption(string fromtime, string toTime, string flat, string type, out Int32[] timeSt, out double[] values)
        {
            string stringData = "";
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

        ///<summary>
        ///To Fetch Energy data for Apartment between Array of times
        ///Give "FromTime" in first array and "ToTime" in corresponding element of seconed array
        ///</summary> 
        public static void FetchBarConsumption(string[] fromTimeArray, string[] toTimeArray, string flat, string type, out Int32[] timeSt, out double[] values)
        {
            string stringData = "";
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

        ///<summary>
        ///To Fetch Energy Values for Bills of Apartment between given time limit 
        ///This function applies "Window" of 5 minutes and "From-Time = start of day" , "To-Time = end of day"  
        ///</summary> 
        public static void FetchBillConsumption(int fromTime, int toTime, string flat, string type, out Int32[] timeSt, out double[] values)
        {
            string stringData = "";
            timeSt = new int[2];
            values = new double[2];
            try
            {

                List<int> fromTim = new List<int>();
                fromTim.Add(fromTime);
                fromTim.Add(toTime);

                List<int> toTim = new List<int>();
                toTim.Add(fromTime + 300);
                toTim.Add(toTime+300);

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

        ///<summary>
        ///Provides "Average Energy Consumption" between given times of provided "Building"
        ///Floors = 2 to 9
        ///Give "FromTime" in first array and "ToTime" in corresponding element of seconed array
        ///
        ///</summary> 
        public static void FetchAvgConsumption(string[] fromTimeArray, string[] toTimeArray, string location, string type, out Int32[] timeSt, out double[] values)
        {
            string stringData = "";
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


                    stringData = "select data before '" + fromTimeArray[j] + "' limit 1 where Metadata/Location/Building ='" + location + "' and Metadata/Extra/PhysicalParameter='Energy' and Metadata/Extra/Type='" + type + "' and (Metadata/Location/Floor = '2' or Metadata/Location/Floor='3'  or Metadata/Location/Floor='4'  or Metadata/Location/Floor='5'  or Metadata/Location/Floor='6'  or Metadata/Location/Floor='7'  or Metadata/Location/Floor='8'  or Metadata/Location/Floor='9' )";

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

        ///<summary>
        ///Provides Electric Parameter Values of given building.
        ///It provides "Sampled Data" for "Sample Time = 'width' Minutes provided.
        ///</summary>        
        public static void FetchBuildingData(string fromtime, string toTime, int width, string building, string criteria, string meter_type, out Int32[] timeSt, out double[] values)
        {
            string stringData = "";
            timeSt = new int[1];
            values = new double[1];

            try
            {
                stringData = "apply window(first, field='minute', width=" + width.ToString() + ") to data in (" + fromtime + ", " + toTime + ") limit 100000000 where Metadata/Location/Building ='" + building + "' and Metadata/Extra/PhysicalParameter='" + criteria + "' and Metadata/Extra/Type='" + meter_type + "'";

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

        ///<summary>
        ///Provides Electric Parameter Values of given building.
        ///It provides "Sampled Data" for "Sample Time = 'width' Minutes provided.
        ///Building Should have Blocks (e.g Academic Building)
        ///</summary>        
        public static void FetchBuildingAcademia(string fromtime, string toTime,int width, string building, string criteria, string meter_type,string block, out Int32[] timeSt, out double[] values)
        {
            string stringData = "";
            timeSt = new int[1];
            values = new double[1];

            try
            {
                stringData = "apply window(first, field='minute', width=" + width.ToString() + ") to data in (" + fromtime + ", " + toTime + ") limit 100000000 where Metadata/Location/Building ='" + building + "' and Metadata/Extra/PhysicalParameter='" + criteria + "' and Metadata/Extra/Block = '" + block + "' and Metadata/Extra/Type='" + meter_type + "'";

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

        ///<summary>
        ///Provides Electric Parameter Values of given building.
        ///It provides "Sampled Data" for "Sample Time = 'width' Minutes provided.
        ///Building Should have Wings (e.g Hostels)
        ///</summary>        
        public static void FetchBuildingHostels(string fromtime, string toTime, int width, string building, string wing, string criteria, string meter_type, out Int32[] timeSt, out double[] values)
        {
            string stringData = "";
            timeSt = new int[1];
            values = new double[1];

            try
            {
                stringData = "apply window(first, field='minute', width="+width.ToString()+") to data in (" + fromtime + ", " + toTime + ") limit 100000000 where Metadata/Location/Building ='" + building + "' and Metadata/Extra/PhysicalParameter='" + criteria + "' and Metadata/Extra/Wing = '" + wing + "' and Metadata/Extra/Type='" + meter_type + "'";

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

        ///<summary>
        ///Provides Electric Parameter Values of given building + FLOOR.
        ///Building Should have Wings (e.g Hostels)
        ///</summary>        
        public static void FetchWingsHostelsFloorWise(string fromtime, string toTime, string building, string wing, int floor, string criteria, string meter_type, out Int32[] timeSt, out double[] values)
        {
            string stringData = "";
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

                req.ContentLength = data.Length;
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

        ///<summary>
        ///Provides Electric Parameter Value of given Building,Time
        ///Only returns First Value
        ///</summary>        
        public static void FetchBuildingTotal(string frtime, string totime, string building, string block_wing, string criteria, string meter_type, out Int32 timeSt, out double values)
        {
            string stringData = "";
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

        ///<summary>
        ///Provides Electric Parameter Values(Mostly Energy) of given building (+) Wing/Block
        ///Give "FromTime" in first array and "ToTime" in corresponding element of seconed array
        ///</summary>        
        public static void FetchBuildingBarConsumption(string[] frtime, string[] totime, string building, string block_wing, string meter_type, out Int32[] timeSt, out double[] values)
        {
            string stringData = "";
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

                    try
                    {
                        if (f3.Length>0)
                        {
                            var f4 = f3[0];                        
                            timeSt[j] = Convert.ToInt32(f4[0] / 1000);
                            values[j] = Convert.ToDouble(f4[1]);
                            values[j] = values[j] / 1000;
                        }
                        else
                        {
                            timeSt[j] = -1;
                            values[j] = -1;
                        }
                    }
                    catch (Exception h)
                    { }

                    response.Close();
                }
            }
            catch (Exception exp)
            {

            }
        }

        ///<summary>
        ///To Ping Meter and it returns its status for given meter id
        ///</summary>        
        public static void PingingMeter(string building, string meter_id, out bool status)
        {
          string stringData = "";
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

        ///<summary>
        ///Returns Array of Floors for given Building
        ///</summary>        
        public static void ListingFloors(string building, out string[] floors)
        {
            string stringData = "";
            floors = new string[1];
            try
            {
                stringData = "select distinct Metadata/Location/Floor where Metadata/Location/Building ='" + building + "'";

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

                floors = new string[f1.Length];

                for (int i = 0; i < f1.Length; i++)
                {

                    floors[i] = f1[i];
                }

                response.Close();
            }
            catch (Exception exp)
            {

            }

        }

        ///<summary>
        ///Returns Meter Id's in given Building + Floor
        ///</summary>        
        public static void ListingMeter(string building, string floor, out string[] meterIDs)
        {
            string stringData = "";
            meterIDs = new string[1];
            try
            {
                stringData = "select distinct Metadata/Extra/MeterID where Metadata/Location/Building ='" + building + "' and Metadata/Location/Floor ='"+floor+"'";

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

        ///<summary>
        ///Returns Meter Id's in given Building 
        ///</summary>        
        public static void ListingBuildingMeter(string building, out string[] meterIDs)
        {
            string stringData = "";
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

        ///<summary>
        ///Returns Electrical Parameter value for given Meter ID
        ///</summary>        
        public static void GetMeterByID(string meterID, string building, string param, out double value, out int time)
        {
            string stringData = "";
            value = 0; time = 0;          
            try
            {
                stringData = "select data before now where Metadata/Extra/MeterID = '" + meterID + "' and Metadata/Extra/PhysicalParameter='" + param + "' AND Metadata/Location/Building='"+building+"'";

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

        ///<summary>
        ///Returns Electrical Parameter value for given Meter ID
        ///</summary>        
        public static void GetParamByIDBuilding(string meterID, string param, string building, string fromtime, string totime, out double[] value, out int[] time)
        {
            string stringData = "";
            value = new double[1]; time = new int[1];
            try
            {
                stringData = "apply window(first, field='minute', width=1) to data in (" + fromtime + ", " + totime + ") limit 100000000 where Metadata/Extra/MeterID = '" + meterID + "' and Metadata/Extra/PhysicalParameter='" + param +"' and Metadata/Location/Building ='" + building + "'";

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
                time= new int[f3.Length];
                value = new double[f3.Length];

                for (int i = 0; i < f3.Length; i++)
                {
                    var f4 = f3[i];
                    time[i] = Convert.ToInt32(f4[0] / 1000);
                    value[i] = Convert.ToDouble(f4[1]);
                }

                response.Close();
            }
            catch (Exception exp)
            {

            }

        }

        ///<summary>
        ///Returns Exact Location for given Meter ID
        ///Returns Floor, Wing, Building, Flat, Block, Meter Type (if any)
        ///</summary>        
        public static void GetMeterLocationByID(string meterID,string build, out string building, out string floor, out string wing, out string flat, out string block, out string type)
        {
            string stringData = "";
            building = ""; floor = ""; wing = "";
            flat = ""; block = ""; type = "";
            try
            {
                stringData = "select Metadata/Location/Building, Metadata/Location/Floor, Metadata/Extra/Wing, Metadata/Extra/FlatNumber, Metadata/Extra/Block, Metadata/Extra/Type where Metadata/Extra/MeterID = '" + meterID + "' AND  Metadata/Location/Building='"+build+"'";

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