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

namespace App_Code.ImportCSV
{
    public static class Import_CSVs
    {
        #region Feilds

        private static string connString = ConfigurationManager.ConnectionStrings["BillingAppConnectionString"].ConnectionString;

        private static DbProviderFactory provider = DbProviderFactories.GetFactory(ConfigurationManager.ConnectionStrings["BillingAppConnectionString"].ProviderName);
        private static string parmPrefix = "@";

        #endregion

        public static bool ImportBuildingSchema(string PATH)
        {
            try
            {
                using (DbConnection conn = provider.CreateConnection())
                {
                    
                    conn.ConnectionString = connString;
                    conn.Open();

                    using (DbCommand cmd = conn.CreateCommand())
                    {
                        PATH = PATH.Replace("\\", "/");
                        string sqlQuery = "LOAD DATA LOCAL INFILE '"+PATH+"' IGNORE INTO TABLE meter_map FIELDS TERMINATED BY ',' LINES TERMINATED BY '\n' IGNORE 1 LINES";
                     

                        if (parmPrefix != "@")
                        {
                            sqlQuery = sqlQuery.Replace("@", parmPrefix);
                        }
                        cmd.CommandText = sqlQuery;
                        cmd.CommandType = CommandType.Text;

                        cmd.ExecuteNonQuery();

                    }
                    conn.Close();

                } return true;
            }
            catch (Exception e)
            {
                return false;
            }

        

        }

        public static string ImportEnergyTips(string PATH)
        {
            try
            {
                using (DbConnection conn = provider.CreateConnection())
                {

                    conn.ConnectionString = connString;
                    conn.Open();

                    using (DbCommand cmd = conn.CreateCommand())
                    {
                        PATH = PATH.Replace("\\", "/");
                        string sqlQuery = "LOAD DATA LOCAL INFILE '" + PATH + "' IGNORE INTO TABLE energy_tips FIELDS TERMINATED BY ',' LINES TERMINATED BY '\n' IGNORE 1 LINES";


                        if (parmPrefix != "@")
                        {
                            sqlQuery = sqlQuery.Replace("@", parmPrefix);
                        }
                        cmd.CommandText = sqlQuery;
                        cmd.CommandType = CommandType.Text;

                        cmd.ExecuteNonQuery();

                    }
                    conn.Close();

                } return true.ToString();
            }
            catch (Exception e)
            {
                return e.Source+ e.InnerException + e.Message;
            }



        }

        public static bool InsertTips(string tip_text)
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
                        sqlQuery = "INSERT INTO energy_tips" +
                               "(tips) " +
                               "VALUES('"+tip_text+"')";

                        cmd.CommandText = sqlQuery;
                        cmd.CommandType = CommandType.Text;
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

        public static bool DeleteTips(int id)
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
                        sqlQuery = "DELETE FROM energy_tips" +
                               " where ID = " + id;
                              

                        cmd.CommandText = sqlQuery;
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                        
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
    }
}