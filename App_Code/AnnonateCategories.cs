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

namespace App_Code.AnnonationCategories
{

    public class DeviceCategories
    {
        #region Constructer

        public DeviceCategories()
        {
            //this.Id = Guid.NewGuid();
        }

        #endregion

        #region Fields & Properties

        private string deviceName = "";
        public string DeviceName
        {
            get { return deviceName; }
            set { deviceName = value; }
        }

        private string createdBy = "";
        public string CreatedBy
        {
            get { return createdBy; }
            set { createdBy = value; }
        }

        public string description = "";
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        #endregion

    }

    public static class Device_Categories
    {
        #region Feilds

        private static string connString = ConfigurationManager.ConnectionStrings["BillingAppConnectionString"].ConnectionString;

        private static DbProviderFactory provider = DbProviderFactories.GetFactory(ConfigurationManager.ConnectionStrings["BillingAppConnectionString"].ProviderName);
        private static string parmPrefix = "@";

        #endregion

        #region Methods

        public static List<DeviceCategories> GetAnnonationCategories(string createdBy)
        {
            List<DeviceCategories> categoryObjList = new List<DeviceCategories>();

            try
            {
                using (DbConnection conn = provider.CreateConnection())
                {
                    conn.ConnectionString = connString;

                    using (DbCommand cmd = conn.CreateCommand())
                    {

                        string sqlQuery = "SELECT created_by, device_name, description FROM annonation_categories WHERE created_by = @creater OR created_by='Admin'";

                        if (parmPrefix != "@")
                        {
                            sqlQuery = sqlQuery.Replace("@", parmPrefix);
                        }
                        cmd.CommandText = sqlQuery;
                        cmd.CommandType = CommandType.Text;


                        DbParameter dpCreater = provider.CreateParameter();
                        dpCreater.ParameterName = parmPrefix + "creater";
                        dpCreater.Value = createdBy;
                        cmd.Parameters.Add(dpCreater);


                        conn.Open();

                        using (DbDataReader rdr = cmd.ExecuteReader())
                        {
                            if (rdr.HasRows)
                            {
                                DeviceCategories fetchObj;
                                while (rdr.Read())
                                {
                                    fetchObj = new DeviceCategories();

                                    if (!rdr.IsDBNull(0))
                                    {
                                        fetchObj.CreatedBy = rdr.GetString(0);
                                    }
                                    if (!rdr.IsDBNull(1))
                                    {
                                        fetchObj.DeviceName = rdr.GetString(1);
                                    }
                                    if (!rdr.IsDBNull(2))
                                    {
                                        fetchObj.Description = rdr.GetString(2);
                                    }
                                    categoryObjList.Add(fetchObj);
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
                return categoryObjList;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static bool InsertAnnonations(DeviceCategories annonateObj)
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
                        sqlQuery = "INSERT INTO annonation_categories " +
                               "(created_by, device_name, description) " +
                               "VALUES (@creater,@device,@desc)";

                        if (parmPrefix != "@")
                        {
                            sqlQuery = sqlQuery.Replace("@", parmPrefix);
                        }
                        cmd.CommandText = sqlQuery;
                        cmd.CommandType = CommandType.Text;

                        DbParameter sDevice = provider.CreateParameter();
                        sDevice.ParameterName = parmPrefix + "device";
                        sDevice.Value = annonateObj.DeviceName;
                        cmd.Parameters.Add(sDevice);


                        DbParameter sCreater = provider.CreateParameter();
                        sCreater.ParameterName = parmPrefix + "creater";
                        sCreater.Value = annonateObj.CreatedBy;
                        cmd.Parameters.Add(sCreater);

                        DbParameter dDesc = provider.CreateParameter();
                        dDesc.ParameterName = parmPrefix + "desc";
                        dDesc.Value = annonateObj.Description;
                        cmd.Parameters.Add(dDesc);

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