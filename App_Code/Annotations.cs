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

namespace App_Code.AnnotateDevice
{
    public class DeviceAnnotations
    {
        #region Constructer

        public DeviceAnnotations()
        {
            //this.Id = Guid.NewGuid();
        }

        #endregion

        #region Fields & Properties

        private string device = "";
        public string Device
        {
            get { return device; }
            set { device = value; }
        }

        private int fromtime = 0;
        public int FromTime
        {
            get { return fromtime; }
            set { fromtime = value; }
        }

        private int totime = 0;
        public int ToTime
        {
            get { return totime; }
            set { totime = value; }
        }

        private int meterId = 0;
        public int MeterId
        {
            get { return meterId; }
            set { meterId = value; }
        }

        public string building = "";
        public string Building
        {
            get { return building; }
            set { building = value; }
        }

        #endregion

    }

    public static class Device_Annotations
    {
        #region Feilds

        private static string connString = ConfigurationManager.ConnectionStrings["BillingAppConnectionString"].ConnectionString;

        private static DbProviderFactory provider = DbProviderFactories.GetFactory(ConfigurationManager.ConnectionStrings["BillingAppConnectionString"].ProviderName);
        private static string parmPrefix = "@";

        #endregion

        #region Methods

        public static List<DeviceAnnotations> GettingAnnotations(int fromtime, int totime, int meterId, string building)
        {
            List<DeviceAnnotations> annotateObj = new List<DeviceAnnotations>();
          
            try
            {
                using (DbConnection conn = provider.CreateConnection())
                {
                    conn.ConnectionString = connString;

                    using (DbCommand cmd = conn.CreateCommand())
                    {

                        string sqlQuery = "SELECT meter_id, fromtime, totime, device, building FROM annonation_data WHERE fromtime BETWEEN " +fromtime + " AND " +totime+ " AND meter_id = @meterID AND building = @build";

                        if (parmPrefix != "@")
                        {
                            sqlQuery = sqlQuery.Replace("@", parmPrefix);
                        }
                        cmd.CommandText = sqlQuery;
                        cmd.CommandType = CommandType.Text;


                        DbParameter dpMeterID = provider.CreateParameter();
                        dpMeterID.ParameterName = parmPrefix + "meterID";
                        dpMeterID.Value = meterId;
                        cmd.Parameters.Add(dpMeterID);

                        DbParameter dpDeviceID = provider.CreateParameter();
                        dpDeviceID.ParameterName = parmPrefix + "build";
                        dpDeviceID.Value = building;
                        cmd.Parameters.Add(dpDeviceID);


                        conn.Open();

                        using (DbDataReader rdr = cmd.ExecuteReader())
                        {
                            if (rdr.HasRows)
                            {
                                DeviceAnnotations fetchObj;
                                while (rdr.Read())
                                {
                                    fetchObj = new DeviceAnnotations();

                                    if (!rdr.IsDBNull(0))
                                    {
                                        fetchObj.MeterId = rdr.GetInt32(0);
                                    }
                                    if (!rdr.IsDBNull(1))
                                    {
                                        fetchObj.FromTime = rdr.GetInt32(1);
                                    }
                                    if (!rdr.IsDBNull(2))
                                    {
                                        fetchObj.ToTime = rdr.GetInt32(2);
                                    }
                                    if (!rdr.IsDBNull(3))
                                    {
                                        fetchObj.Device = rdr.GetString(3);
                                    }
                                    if (!rdr.IsDBNull(4))
                                    {
                                        fetchObj.Building = rdr.GetString(4);
                                    }
                                    annotateObj.Add(fetchObj);
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
                return annotateObj;
            }
            catch (Exception e)
            {
                return null;
            }            
        }

        public static bool InsertAnnotations(DeviceAnnotations annotateObj)
        {
            try
            {
                using (DbConnection conn = provider.CreateConnection())
                {
                    conn.ConnectionString = connString;
                    conn.Open();

                    using (DbCommand cmd = conn.CreateCommand())
                    {
                        string sqlQuery;
                        sqlQuery = "INSERT INTO annonation_data" +
                               "(fromtime,totime,device,Meter_Id,Building) " +
                               "VALUES (@frmtime,@ttime,@device,@metId,@blding)";

                        if (parmPrefix != "@")
                        {
                            sqlQuery = sqlQuery.Replace("@", parmPrefix);
                        }
                        cmd.CommandText = sqlQuery;
                        cmd.CommandType = CommandType.Text;

                        DbParameter sFrmTime = provider.CreateParameter();
                        sFrmTime.ParameterName = parmPrefix + "frmTime";
                        sFrmTime.Value = annotateObj.FromTime;
                        cmd.Parameters.Add(sFrmTime);

                        DbParameter sTTime = provider.CreateParameter();
                        sTTime.ParameterName = parmPrefix + "ttime";
                        sTTime.Value = annotateObj.ToTime;
                        cmd.Parameters.Add(sTTime);

                        DbParameter sDevice = provider.CreateParameter();
                        sDevice.ParameterName = parmPrefix + "device";
                        sDevice.Value = annotateObj.Device;
                        cmd.Parameters.Add(sDevice);


                        DbParameter sMeterID = provider.CreateParameter();
                        sMeterID.ParameterName = parmPrefix + "metId";
                        sMeterID.Value = annotateObj.MeterId;
                        cmd.Parameters.Add(sMeterID);

                        DbParameter dBuilding = provider.CreateParameter();
                        dBuilding.ParameterName = parmPrefix + "blding";
                        dBuilding.Value = annotateObj.Building;
                        cmd.Parameters.Add(dBuilding);

                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }
                    conn.Close();
                }
                return true;
            }
            catch (Exception exp)
            {
                return false;
            }
        }

        #endregion
    }


}