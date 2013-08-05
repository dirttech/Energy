using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Configuration.Provider;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace App_Code.FetchingEnergyss
{
    public class FetchingEnergy
    {
        #region Constructer

        public FetchingEnergy()
        {
            //this.Id = Guid.NewGuid();
        }
        
        #endregion

        #region Fields & Properties

        private string deviceId = "";
        public string DeviceId
        {
            get { return deviceId; }
            set { deviceId = value; }
        }

        private int timeStamp = 0;
        public int TimeStamp
        {
            get { return timeStamp; }
            set { timeStamp = value; }
        }

        private int meterId = 0;
        public int MeterId
        {
            get { return meterId; }
            set { meterId = value; }
        }

        private float w = 0;
        public float W
        {
            get { return w; }
            set { w = value; }
        }

        private float fwdHr = 0;
        public float FwdHr
        {
            get { return fwdHr; }
            set { fwdHr = value; }
        }

        public float fwdHrFinal=0;
        public float FwdHrFinal
        {
            get { return fwdHrFinal; }
            set { fwdHrFinal = value; }
        }


        #endregion

        }

    public static class FetchingEnergy_s
    {
        #region Feilds

        private static string connString = ConfigurationManager.ConnectionStrings["BillingAppConnectionString"].ConnectionString;

        private static DbProviderFactory provider = DbProviderFactories.GetFactory(ConfigurationManager.ConnectionStrings["BillingAppConnectionString"].ProviderName);
        private static string parmPrefix = "@";

        #endregion

        #region Methods

        public static List<FetchingEnergy> fetchEnergyLine(int fromTime, int toTime, int meterID, string deviceID, int ct)
        {
            List<FetchingEnergy> listObj = new List<FetchingEnergy>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection())
                {
                    conn.ConnectionString = connString;

                    using (MySqlCommand cmd = conn.CreateCommand())
                    {
                      
                        cmd.CommandText = "FetchEnergyLine";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("From_Time", fromTime);
                        cmd.Parameters["From_Time"].Direction = ParameterDirection.Input;
                        cmd.Parameters.AddWithValue("To_Time", toTime);
                        cmd.Parameters["To_Time"].Direction = ParameterDirection.Input;
                        cmd.Parameters.AddWithValue("Meter_Id", meterID);
                        cmd.Parameters["Meter_Id"].Direction = ParameterDirection.Input;
                        cmd.Parameters.AddWithValue("Device_Id", deviceID);
                        cmd.Parameters["Device_Id"].Direction = ParameterDirection.Input;
                        cmd.Parameters.AddWithValue("ct", ct);
                        cmd.Parameters["ct"].Direction = ParameterDirection.Input;



                        conn.Open();

                        using (MySqlDataReader rdr = cmd.ExecuteReader())
                        {
                            
                            if (rdr.HasRows)
                            {
                                while (rdr.Read())
                                {
                                    FetchingEnergy obj = new FetchingEnergy();

                                    if (!rdr.IsDBNull(0))
                                    {
                                        obj.TimeStamp = rdr.GetInt32(0);
                                    }
                                    if (!rdr.IsDBNull(1))
                                    {
                                        obj.FwdHr = rdr.GetFloat(1);
                                    }
                                    if (!rdr.IsDBNull(2))
                                    {
                                        obj.W = rdr.GetFloat(2);
                                    }
                                    obj.DeviceId = deviceID;
                                    obj.MeterId = meterID;
                                    listObj.Add(obj);
                                }
                               
                               
                            }
                            else
                            {
                                return null;
                            }
                        }


                    }
                    conn.Close();
                }
                return listObj;
            }
            catch (Exception e)
            {
                return null;
            }

        }

        public static List<FetchingEnergy> fetchEnergyBar(List<int> timeSt, int meterID, string deviceID)
        {
            List<FetchingEnergy> listObj = new List<FetchingEnergy>();
            try
            {
                using (DbConnection conn = provider.CreateConnection())
                {
                    conn.ConnectionString = connString;

                    using (DbCommand cmd = conn.CreateCommand())
                    {
                        int window = timeSt[1] - timeSt[0];
                      
                       
                        string sqlQuery = "(SELECT TimeStamp, FwdHr, W FROM Meter_Data WHERE TimeStamp Between " + (timeSt[0]).ToString() + " AND " + (timeSt[0] + window).ToString() + " AND MeterID = @meterID AND DeviceID = @deviceID ORDER BY TimeStamp ASC LIMIT 1)";
                        
                        for (int i = 1; i < timeSt.Count; i++)
                        {
                            sqlQuery = sqlQuery + " UNION (SELECT TimeStamp, FwdHr, W FROM Meter_Data WHERE TimeStamp Between " + (timeSt[i]).ToString() + " AND " + (timeSt[i] + window).ToString() + " AND MeterID = @meterID AND DeviceID = @deviceID ORDER BY TimeStamp ASC LIMIT 1)";
                        
                        }

                        
                        if (parmPrefix != "@")
                        {
                            sqlQuery = sqlQuery.Replace("@", parmPrefix);
                        }
                        cmd.CommandText = sqlQuery;
                        cmd.CommandType = CommandType.Text;

                      
                        DbParameter dpMeterID = provider.CreateParameter();
                        dpMeterID.ParameterName = parmPrefix + "meterID";
                        dpMeterID.Value = meterID;
                        cmd.Parameters.Add(dpMeterID);

                        DbParameter dpDeviceID = provider.CreateParameter();
                        dpDeviceID.ParameterName = parmPrefix + "deviceID";
                        dpDeviceID.Value = deviceID;
                        cmd.Parameters.Add(dpDeviceID);


                        conn.Open();

                        using (DbDataReader rdr = cmd.ExecuteReader())
                        {

                            if (rdr.HasRows)
                            {
                                while (rdr.Read())
                                {
                                    FetchingEnergy obj = new FetchingEnergy();

                                    if (!rdr.IsDBNull(0))
                                    {
                                        obj.TimeStamp = rdr.GetInt32(0);
                                    }
                                    if (!rdr.IsDBNull(1))
                                    {
                                        obj.FwdHr = rdr.GetFloat(1);
                                    }
                                    if (!rdr.IsDBNull(2))
                                    {
                                        obj.W = rdr.GetFloat(2);
                                    }
                                    obj.DeviceId = deviceID;
                                    obj.MeterId = meterID;
                                    listObj.Add(obj);
                                }


                            }
                            else
                            {
                                return null;
                            }
                        }


                    }
                    conn.Close();
                }
                return listObj;
            }
            catch (Exception e)
            {
                return null;
            }

        }

        public static List<FetchingEnergy> fetchAVGBar(List<int> timeSt, string deviceID)
        {
            List<FetchingEnergy> listObj = new List<FetchingEnergy>();
            try
            {
                using (DbConnection conn = provider.CreateConnection())
                {
                    conn.ConnectionString = connString;

                    using (DbCommand cmd = conn.CreateCommand())
                    {
                        int window = 300;
                        

                        string sqlQuery = "(SELECT TimeStamp, FwdHr, W, meterID FROM Meter_Data WHERE TimeStamp Between " + (timeSt[0]).ToString() + " AND " + (timeSt[0] + window).ToString() + " AND DeviceID = @deviceID GROUP BY meterID)";

                        for (int i = 1; i < timeSt.Count; i++)
                        {
                            sqlQuery = sqlQuery + " UNION (SELECT TimeStamp, FwdHr, W, meterID FROM Meter_Data WHERE TimeStamp Between " + (timeSt[i]).ToString() + " AND " + (timeSt[i] + window).ToString() + " AND DeviceID = @deviceID GROUP BY meterID)";

                        }


                        if (parmPrefix != "@")
                        {
                            sqlQuery = sqlQuery.Replace("@", parmPrefix);
                        }
                        cmd.CommandText = sqlQuery;
                        cmd.CommandType = CommandType.Text;


                        

                        DbParameter dpDeviceID = provider.CreateParameter();
                        dpDeviceID.ParameterName = parmPrefix + "deviceID";
                        dpDeviceID.Value = deviceID;
                        cmd.Parameters.Add(dpDeviceID);


                        conn.Open();

                        using (DbDataReader rdr = cmd.ExecuteReader())
                        {

                            if (rdr.HasRows)
                            {
                                while (rdr.Read())
                                {
                                    FetchingEnergy obj = new FetchingEnergy();

                                    if (!rdr.IsDBNull(0))
                                    {
                                        obj.TimeStamp = rdr.GetInt32(0);
                                    }
                                    if (!rdr.IsDBNull(1))
                                    {
                                        obj.FwdHr = rdr.GetFloat(1);
                                    }
                                    if (!rdr.IsDBNull(2))
                                    {
                                        obj.W = rdr.GetFloat(2);
                                    }
                                    if (!rdr.IsDBNull(3))
                                    {
                                        obj.MeterId = rdr.GetInt32(3);
                                    }
                                    obj.DeviceId = deviceID;
                                  
                                    listObj.Add(obj);
                                }


                            }
                            else
                            {
                                return null;
                            }
                        }


                    }
                    conn.Close();
                }
                return listObj;
            }
            catch (Exception e)
            {
                return null;
            }

        }

        public static List<FetchingEnergy> fetchEnergyLining(int fromTime, int toTime, int meterID, string deviceID, int ct)
        {
            List<FetchingEnergy> listObj = new List<FetchingEnergy>();
            try
            {
                using (DbConnection conn = provider.CreateConnection())
                {
                    conn.ConnectionString = connString;

                    using (DbCommand cmd = conn.CreateCommand())
                    {
                        int window = 120;
                        ct = 30;
                        int sample = (toTime-fromTime) / ct;
                        List<int> timeSt = new List<int>();
                        for (int i = fromTime; i <= toTime; i = i + sample)
                        {
                            timeSt.Add(i);
                        }


                        string sqlQuery = "(SELECT TimeStamp, FwdHr, W FROM Meter_Data WHERE TimeStamp Between " + (timeSt[0]).ToString() + " AND " + (timeSt[0] + window).ToString() + " AND MeterID = @meterID AND DeviceID = @deviceID ORDER BY TimeStamp LIMIT 1)";

                        for (int i = 1; i < timeSt.Count; i++)
                        {
                            sqlQuery = sqlQuery + " UNION (SELECT TimeStamp, FwdHr, W FROM Meter_Data WHERE TimeStamp Between " + (timeSt[i]).ToString() + " AND " + (timeSt[i] + window).ToString() + " AND MeterID = @meterID AND DeviceID = @deviceID ORDER BY TimeStamp LIMIT 1)";

                        }


                        if (parmPrefix != "@")
                        {
                            sqlQuery = sqlQuery.Replace("@", parmPrefix);
                        }
                        cmd.CommandText = sqlQuery;
                        cmd.CommandType = CommandType.Text;


                        DbParameter dpMeterID = provider.CreateParameter();
                        dpMeterID.ParameterName = parmPrefix + "meterID";
                        dpMeterID.Value = meterID;
                        cmd.Parameters.Add(dpMeterID);

                        DbParameter dpDeviceID = provider.CreateParameter();
                        dpDeviceID.ParameterName = parmPrefix + "deviceID";
                        dpDeviceID.Value = deviceID;
                        cmd.Parameters.Add(dpDeviceID);


                        conn.Open();

                        using (DbDataReader rdr = cmd.ExecuteReader())
                        {

                            if (rdr.HasRows)
                            {
                                while (rdr.Read())
                                {
                                    FetchingEnergy obj = new FetchingEnergy();

                                    if (!rdr.IsDBNull(0))
                                    {
                                        obj.TimeStamp = rdr.GetInt32(0);
                                    }
                                    if (!rdr.IsDBNull(1))
                                    {
                                        obj.FwdHr = rdr.GetFloat(1);
                                    }
                                    if (!rdr.IsDBNull(2))
                                    {
                                        obj.W = rdr.GetFloat(2);
                                    }
                                    obj.DeviceId = deviceID;
                                    obj.MeterId = meterID;
                                    listObj.Add(obj);
                                }


                            }
                            else
                            {
                                return null;
                            }
                        }


                    }
                    conn.Close();
                }
                return listObj;
            }
            catch (Exception e)
            {
                return null;
            }

        }

        public static List<FetchingEnergy> fetchBillingData(int timeStFrom, int timeStTo, int meterID, string deviceID)
        {
            List<FetchingEnergy> listObj = new List<FetchingEnergy>();
            try
            {
                using (DbConnection conn = provider.CreateConnection())
                {
                    conn.ConnectionString = connString;

                    using (DbCommand cmd = conn.CreateCommand())
                    {
                        int window = 24 * 60 * 60;

                        string sqlQuery = "(SELECT TimeStamp, FwdHr, W FROM Meter_Data WHERE TimeStamp Between " + (timeStFrom).ToString() + " AND " + (timeStFrom + window).ToString() + " AND MeterID = @meterID AND DeviceID = @deviceID ORDER BY TimeStamp ASC LIMIT 1)";

                       
                        sqlQuery = sqlQuery + " UNION (SELECT TimeStamp, FwdHr, W FROM Meter_Data WHERE TimeStamp Between " + (timeStTo - window).ToString() + " AND " + (timeStTo).ToString() + " AND MeterID = @meterID AND DeviceID = @deviceID ORDER BY TimeStamp DESC LIMIT 1)";



                        if (parmPrefix != "@")
                        {
                            sqlQuery = sqlQuery.Replace("@", parmPrefix);
                        }
                        cmd.CommandText = sqlQuery;
                        cmd.CommandType = CommandType.Text;


                        DbParameter dpMeterID = provider.CreateParameter();
                        dpMeterID.ParameterName = parmPrefix + "meterID";
                        dpMeterID.Value = meterID;
                        cmd.Parameters.Add(dpMeterID);

                        DbParameter dpDeviceID = provider.CreateParameter();
                        dpDeviceID.ParameterName = parmPrefix + "deviceID";
                        dpDeviceID.Value = deviceID;
                        cmd.Parameters.Add(dpDeviceID);


                        conn.Open();

                        using (DbDataReader rdr = cmd.ExecuteReader())
                        {

                            if (rdr.HasRows)
                            {
                                while (rdr.Read())
                                {
                                    FetchingEnergy obj = new FetchingEnergy();

                                    if (!rdr.IsDBNull(0))
                                    {
                                        obj.TimeStamp = rdr.GetInt32(0);
                                    }
                                    if (!rdr.IsDBNull(1))
                                    {
                                        obj.FwdHr = rdr.GetFloat(1);
                                    }
                                    if (!rdr.IsDBNull(2))
                                    {
                                        obj.W = rdr.GetFloat(2);
                                    }
                                    obj.DeviceId = deviceID;
                                    obj.MeterId = meterID;
                                    listObj.Add(obj);
                                }


                            }
                            else
                            {
                                return null;
                            }
                        }


                    }
                    conn.Close();
                }
                return listObj;
            }
            catch (Exception e)
            {
                return null;
            }

        }

        public static List<FetchingEnergy> fetchAVGDashDayEnergy(int timeSt, string deviceID , int sec)
        {
            List<FetchingEnergy> listObj = new List<FetchingEnergy>();
            try
            {
                using (DbConnection conn = provider.CreateConnection())
                {
                    conn.ConnectionString = connString;

                    using (DbCommand cmd = conn.CreateCommand())
                    {
                        int window = sec;
                        

                        string sqlQuery = "(SELECT MAX(FwdHr), MIN(FwdHr) FROM Meter_Data WHERE TimeStamp Between " + (timeSt).ToString() + " AND " + (timeSt + window).ToString() + " AND DeviceID = @deviceID GROUP BY meterID)";
                     


                        if (parmPrefix != "@")
                        {
                            sqlQuery = sqlQuery.Replace("@", parmPrefix);
                        }
                        cmd.CommandText = sqlQuery;
                        cmd.CommandType = CommandType.Text;




                        DbParameter dpDeviceID = provider.CreateParameter();
                        dpDeviceID.ParameterName = parmPrefix + "deviceID";
                        dpDeviceID.Value = deviceID;
                        cmd.Parameters.Add(dpDeviceID);


                        conn.Open();

                        using (DbDataReader rdr = cmd.ExecuteReader())
                        {

                            if (rdr.HasRows)
                            {
                                while (rdr.Read())
                                {
                                    FetchingEnergy obj = new FetchingEnergy();

                                    if (!rdr.IsDBNull(0))
                                    {
                                        obj.fwdHrFinal = rdr.GetFloat(0);
                                    }
                                    if (!rdr.IsDBNull(1))
                                    {
                                        obj.FwdHr = rdr.GetFloat(1);
                                    }
                                   

                                    listObj.Add(obj);
                                }


                            }
                            else
                            {
                                return null;
                            }
                        }


                    }
                    conn.Close();
                }
                return listObj;
            }
            catch (Exception e)
            {
                return null;
            }

        }

        public static List<FetchingEnergy> fetchEnergyALL(int fromTime, int toTime, int meterID, string deviceID)
        {
            List<FetchingEnergy> listObj = new List<FetchingEnergy>();
            try
            {
                using (DbConnection conn = provider.CreateConnection())
                {
                    conn.ConnectionString = connString;

                    using (DbCommand cmd = conn.CreateCommand())
                    {
                       
                         string sqlQuery = "(SELECT TimeStamp, FwdHr, W FROM Meter_Data WHERE TimeStamp Between " + fromTime.ToString() + " AND " + toTime.ToString() + " AND MeterID = @meterID AND DeviceID = @deviceID ORDER BY TimeStamp ASC)";

                      
                        if (parmPrefix != "@")
                        {
                            sqlQuery = sqlQuery.Replace("@", parmPrefix);
                        }
                        cmd.CommandText = sqlQuery;
                        cmd.CommandType = CommandType.Text;


                        DbParameter dpMeterID = provider.CreateParameter();
                        dpMeterID.ParameterName = parmPrefix + "meterID";
                        dpMeterID.Value = meterID;
                        cmd.Parameters.Add(dpMeterID);

                        DbParameter dpDeviceID = provider.CreateParameter();
                        dpDeviceID.ParameterName = parmPrefix + "deviceID";
                        dpDeviceID.Value = deviceID;
                        cmd.Parameters.Add(dpDeviceID);


                        conn.Open();

                        using (DbDataReader rdr = cmd.ExecuteReader())
                        {

                            if (rdr.HasRows)
                            {
                                while (rdr.Read())
                                {
                                    FetchingEnergy obj = new FetchingEnergy();

                                    if (!rdr.IsDBNull(0))
                                    {
                                        obj.TimeStamp = rdr.GetInt32(0);
                                    }
                                    if (!rdr.IsDBNull(1))
                                    {
                                        obj.FwdHr = rdr.GetFloat(1);
                                    }
                                    if (!rdr.IsDBNull(2))
                                    {
                                        obj.W = rdr.GetFloat(2);
                                    }
                                    obj.DeviceId = deviceID;
                                    obj.MeterId = meterID;
                                    listObj.Add(obj);
                                }


                            }
                            else
                            {
                                return null;
                            }
                        }


                    }
                    conn.Close();
                }
                return listObj;
            }
            catch (Exception e)
            {
                return null;
            }

        }


      
        #endregion

    }
}