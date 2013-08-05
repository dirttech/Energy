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

namespace App_Code.User_Mapping
{


    #region UsersMapping Object

    public class UserMapping
    {
        #region Constructer

        public UserMapping()
        {
            this.UserId = Guid.NewGuid();
        }
        #endregion

        #region Fields & Properties


        private Guid userId;
        public Guid UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        private string apartment = "";
        public string Apartment
        {
            get { return apartment; }
            set { apartment = value; }
        }

        private int meterId = 0;
        public int MeterId
        {
            get { return meterId; }
            set { meterId = value; }
        }

        private int floor = 0;
        public int Floor
        {
            get { return floor; }
            set { floor = value; }
        }

        private string building = "";
        public string Building
        {
            get { return building; }
            set { building = value; }
        }

        private string meterType = "";
        public string MeterType
        {
            get { return meterType; }
            set { meterType = value; }
        }
     

        #endregion

    }


    #endregion

    public static class UserMapping_S
    {

        #region Feilds

        private static string connString = ConfigurationManager.ConnectionStrings["BillingAppConnectionString"].ConnectionString;

        private static DbProviderFactory provider = DbProviderFactories.GetFactory(ConfigurationManager.ConnectionStrings["BillingAppConnectionString"].ProviderName);
        private static string parmPrefix = "@";

        #endregion

        #region Methods

  

        public static UserMapping MapUser(Guid UserId)
        {
            UserMapping userDetail = new UserMapping();

            try
            {
                using (DbConnection conn = provider.CreateConnection())
                {
                    conn.ConnectionString = connString;

                    using (DbCommand cmd = conn.CreateCommand())
                    {
                        string sqlQuery = "SELECT UserID,Apartment,MeterNo,FloorNo,Building,MeterType" +
                                         " FROM meter_map WHERE UserID = @UserId";

                        if (parmPrefix != "@")
                        {
                            sqlQuery = sqlQuery.Replace("@", parmPrefix);
                        }
                        cmd.CommandText = sqlQuery;
                        cmd.CommandType = CommandType.Text;

                        DbParameter dpID = provider.CreateParameter();
                        dpID.ParameterName = parmPrefix + "UserId";
                        dpID.Value = UserId;
                        cmd.Parameters.Add(dpID);


                        conn.Open();

                        using (DbDataReader rdr = cmd.ExecuteReader())
                        {
                            if (rdr.HasRows)
                            {
                                while (rdr.Read())
                                {
                                    userDetail = new UserMapping();

                                    if (!rdr.IsDBNull(0))
                                    {
                                        userDetail.UserId = rdr.GetGuid(0);
                                    }
                                    if (!rdr.IsDBNull(1))
                                    {
                                        userDetail.Apartment = rdr.GetString(1);
                                    }

                                    if (!rdr.IsDBNull(2))
                                    {
                                        userDetail.MeterId = rdr.GetInt32(2);
                                    }

                                    if (!rdr.IsDBNull(3))
                                    {
                                        userDetail.Floor = rdr.GetInt32(3);
                                    }

                                    if (!rdr.IsDBNull(4))
                                    {
                                        userDetail.Building = rdr.GetString(4);
                                    }

                                    if (!rdr.IsDBNull(5))
                                    {
                                        userDetail.MeterType = rdr.GetString(5);
                                    }
                                   

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
            }
            catch (Exception exp)
            {
                return null;
            }
            return userDetail;

        }

        public static List<UserMapping> ListAllMeters(string building, string meterType)
        {
            List<UserMapping> allMeters = new List<UserMapping>();

            try
            {
                using (DbConnection conn = provider.CreateConnection())
                {
                    conn.ConnectionString = connString;

                    using (DbCommand cmd = conn.CreateCommand())
                    {
                        string sqlQuery = "SELECT UserID,Apartment, MeterNo, FloorNo, Building, MeterType" +
                                         " FROM meter_map WHERE Building=@build AND MeterType=@mType";

                        if (parmPrefix != "@")
                        {
                            sqlQuery = sqlQuery.Replace("@", parmPrefix);
                        }
                        cmd.CommandText = sqlQuery;
                        cmd.CommandType = CommandType.Text;

                        DbParameter dpID = provider.CreateParameter();
                        dpID.ParameterName = parmPrefix + "build";
                        dpID.Value = building;
                        cmd.Parameters.Add(dpID);

                        DbParameter metType = provider.CreateParameter();
                        metType.ParameterName = parmPrefix + "mType";
                        metType.Value = meterType;
                        cmd.Parameters.Add(metType);

                        conn.Open();

                        using (DbDataReader rdr = cmd.ExecuteReader())
                        {
                            if (rdr.HasRows)
                            {
                                while (rdr.Read())
                                {
                                  UserMapping  meter = new UserMapping();

                                    if (!rdr.IsDBNull(0))
                                    {
                                        meter.UserId = rdr.GetGuid(0);
                                    }
                                    if (!rdr.IsDBNull(1))
                                    {
                                        meter.Apartment = rdr.GetString(1);
                                    }
                                    if (!rdr.IsDBNull(2))
                                    {
                                        meter.MeterId = rdr.GetInt32(2);
                                    }
                                    if (!rdr.IsDBNull(3))
                                    {
                                        meter.Floor = rdr.GetInt32(3);
                                    }
                                    if (!rdr.IsDBNull(4))
                                    {
                                        meter.Building = rdr.GetString(4);
                                    }
                                    if (!rdr.IsDBNull(1))
                                    {
                                        meter.MeterType = rdr.GetString(5);
                                    }

                                    allMeters.Add(meter);

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
            }
            catch (Exception exp)
            {
                return null;
            }
            return allMeters;

        }


        public static UserMapping UserMapWithMeterBuilding(string building, int meterId)
        {
            UserMapping meter = new UserMapping();

            try
            {
                using (DbConnection conn = provider.CreateConnection())
                {
                    conn.ConnectionString = connString;

                    using (DbCommand cmd = conn.CreateCommand())
                    {
                        string sqlQuery = "SELECT UserID" +
                                         " FROM meter_map WHERE building = @building AND MeterNo = @meterId";

                        if (parmPrefix != "@")
                        {
                            sqlQuery = sqlQuery.Replace("@", parmPrefix);
                        }
                        cmd.CommandText = sqlQuery;
                        cmd.CommandType = CommandType.Text;

                        DbParameter dpID = provider.CreateParameter();
                        dpID.ParameterName = parmPrefix + "building";
                        dpID.Value = building;
                        cmd.Parameters.Add(dpID);

                        DbParameter dpmID = provider.CreateParameter();
                        dpmID.ParameterName = parmPrefix + "meterId";
                        dpmID.Value = meterId;
                        cmd.Parameters.Add(dpmID);


                        conn.Open();

                        using (DbDataReader rdr = cmd.ExecuteReader())
                        {
                            if (rdr.HasRows)
                            {
                                while (rdr.Read())
                                {
                                    meter = new UserMapping();

                                    if (!rdr.IsDBNull(0))
                                    {
                                        meter.UserId = rdr.GetGuid(0);
                                    }
                                    

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
            }
            catch (Exception exp)
            {
                return null;
            }
            return meter;

        }

        public static bool InsertMap(UserMapping insertMap)
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
                        sqlQuery = "INSERT INTO meter_map" +
                               "(apartment,UserID,MeterNo,FloorNo,Building,MeterType) " +
                               "VALUES(@apart,@usrID,@metId,@floor,@blding,@meterTyp)";

                        if (parmPrefix != "@")
                        {
                            sqlQuery = sqlQuery.Replace("@", parmPrefix);
                        }
                        cmd.CommandText = sqlQuery;
                        cmd.CommandType = CommandType.Text;

                        DbParameter sNewId = provider.CreateParameter();
                        sNewId.ParameterName = parmPrefix + "usrID";
                        sNewId.Value = insertMap.UserId;
                        cmd.Parameters.Add(sNewId);

                        DbParameter sDeviceId = provider.CreateParameter();
                        sDeviceId.ParameterName = parmPrefix + "apart";
                        sDeviceId.Value = insertMap.Apartment;
                        cmd.Parameters.Add(sDeviceId);


                        DbParameter sMeterID = provider.CreateParameter();
                        sMeterID.ParameterName = parmPrefix + "metId";
                        sMeterID.Value = insertMap.MeterId;
                        cmd.Parameters.Add(sMeterID);

                        DbParameter dFloor = provider.CreateParameter();
                        dFloor.ParameterName = parmPrefix + "floor";
                        dFloor.Value = insertMap.Floor;
                        cmd.Parameters.Add(dFloor);

                        DbParameter dBuilding = provider.CreateParameter();
                        dBuilding.ParameterName = parmPrefix + "blding";
                        dBuilding.Value = insertMap.Building;
                        cmd.Parameters.Add(dBuilding);

                        DbParameter dMeterType = provider.CreateParameter();
                        dMeterType.ParameterName = parmPrefix + "meterTyp";
                        dMeterType.Value = insertMap.MeterType;
                        cmd.Parameters.Add(dMeterType);

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

        public static bool UpdateMap(UserMapping insertMap)
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
                        sqlQuery = "Update meter_map " +
                               "SET MeterNo = @meterID, MeterType=@metType WHERE UserID = @userID ";
                             

                        if (parmPrefix != "@")
                        {
                            sqlQuery = sqlQuery.Replace("@", parmPrefix);
                        }
                        cmd.CommandText = sqlQuery;
                        cmd.CommandType = CommandType.Text;

                        DbParameter sNewId = provider.CreateParameter();
                        sNewId.ParameterName = parmPrefix + "userID";
                        sNewId.Value = insertMap.UserId;
                        cmd.Parameters.Add(sNewId);

                        //DbParameter sDeviceId = provider.CreateParameter();
                        //sDeviceId.ParameterName = parmPrefix + "apartment";
                        //sDeviceId.Value = insertMap.Apartment;
                        //cmd.Parameters.Add(sDeviceId);


                        DbParameter sMeterID = provider.CreateParameter();
                        sMeterID.ParameterName = parmPrefix + "meterID";
                        sMeterID.Value = insertMap.MeterId;
                        cmd.Parameters.Add(sMeterID);

                        //DbParameter dFloor = provider.CreateParameter();
                        //dFloor.ParameterName = parmPrefix + "floor";
                        //dFloor.Value = insertMap.Floor;
                        //cmd.Parameters.Add(dFloor);

                        //DbParameter dBuilding = provider.CreateParameter();
                        //dBuilding.ParameterName = parmPrefix + "building";
                        //dBuilding.Value = insertMap.Building;
                        //cmd.Parameters.Add(dBuilding);

                        DbParameter dMetType = provider.CreateParameter();
                        dMetType.ParameterName = parmPrefix + "metType";
                        dMetType.Value = insertMap.MeterType;
                        cmd.Parameters.Add(dMetType);

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

        public static bool UpdateUserIdinMap(UserMapping insertMap)
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
                        sqlQuery = "Update meter_map " +
                               "SET UserID = @userID WHERE Apartment = @apartment AND Building = @building";


                        if (parmPrefix != "@")
                        {
                            sqlQuery = sqlQuery.Replace("@", parmPrefix);
                        }
                        cmd.CommandText = sqlQuery;
                        cmd.CommandType = CommandType.Text;

                        DbParameter sNewId = provider.CreateParameter();
                        sNewId.ParameterName = parmPrefix + "userID";
                        sNewId.Value = insertMap.UserId;
                        cmd.Parameters.Add(sNewId);

                        DbParameter sApartment = provider.CreateParameter();
                        sApartment.ParameterName = parmPrefix + "apartment";
                        sApartment.Value = insertMap.Apartment;
                        cmd.Parameters.Add(sApartment);


                        //DbParameter sMeterID = provider.CreateParameter();
                        //sMeterID.ParameterName = parmPrefix + "meterID";
                        //sMeterID.Value = insertMap.MeterId;
                        //cmd.Parameters.Add(sMeterID);

                        //DbParameter dFloor = provider.CreateParameter();
                        //dFloor.ParameterName = parmPrefix + "floor";
                        //dFloor.Value = insertMap.Floor;
                        //cmd.Parameters.Add(dFloor);

                        DbParameter dBuilding = provider.CreateParameter();
                        dBuilding.ParameterName = parmPrefix + "building";
                        dBuilding.Value = insertMap.Building;
                        cmd.Parameters.Add(dBuilding);

                        //DbParameter dMetType = provider.CreateParameter();
                        //dMetType.ParameterName = parmPrefix + "metType";
                        //dMetType.Value = insertMap.MeterType;
                        //cmd.Parameters.Add(dMetType);

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