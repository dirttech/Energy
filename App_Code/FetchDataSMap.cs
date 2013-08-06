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


                    stringData = "select data in ('" + fromTimeArray[j] + "' , '" + toTimeArray[j] + "') limit 1 where Metadata/Location/Building ='" + location + "' and Metadata/Extra/PhysicalParameter='Energy' and Metadata/Extra/Type='" + type + "'";

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
                stringData = "select data in (" + fromtime + ", " + toTime + ") where Metadata/Location/Building ='" + building + "' and Metadata/Extra/PhysicalParameter='" + criteria + "' and Metadata/Extra/Type='" + meter_type + "'";

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
                stringData = "select data in (" + fromtime + ", " + toTime + ") where Metadata/Location/Building ='" + building + "' and Metadata/Extra/PhysicalParameter='" + criteria + "' and Metadata/Extra/Block = '" + block + "' and Metadata/Extra/Type='" + meter_type + "'";

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


    }
}