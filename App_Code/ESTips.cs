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

namespace App_Code.ESTip
{

    #region ES_Tips Object

    public class EsTips
    {
        #region Constructer

        public EsTips()
        {

        }
        #endregion

        #region Fields & Properties


        private int id = 0;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string tips = "";
        public string Tips
        {
            get { return tips; }
            set { tips = value; }
        }


        #endregion

    }


    #endregion


    public static class ES_Tips
    {
        #region Feilds

        private static string connString = ConfigurationManager.ConnectionStrings["BillingAppConnectionString"].ConnectionString;

        private static DbProviderFactory provider = DbProviderFactories.GetFactory(ConfigurationManager.ConnectionStrings["BillingAppConnectionString"].ProviderName);
        private static string parmPrefix = "@";

        #endregion

        public static List<EsTips> SelectTips()
        {
            List<EsTips> tipsList = new List<EsTips>();

            try
            {
                using (DbConnection conn = provider.CreateConnection())
                {
                    conn.ConnectionString = connString;

                    using (DbCommand cmd = conn.CreateCommand())
                    {
                        string sqlQuery = "SELECT ID, tips" +
                                         " FROM energy_tips";

                        if (parmPrefix != "@")
                        {
                            sqlQuery = sqlQuery.Replace("@", parmPrefix);
                        }
                        cmd.CommandText = sqlQuery;
                        cmd.CommandType = CommandType.Text;


                        conn.Open();

                        using (DbDataReader rdr = cmd.ExecuteReader())
                        {
                            if (rdr.HasRows)
                            {
                                while (rdr.Read())
                                {
                                    EsTips etip = new EsTips();

                                    if (!rdr.IsDBNull(0))
                                    {
                                        etip.Id = rdr.GetInt32(0);
                                    }
                                    if (!rdr.IsDBNull(1))
                                    {
                                        etip.Tips = rdr.GetString(1);
                                    }

                                    tipsList.Add(etip);

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
            return tipsList;

        }

    
    }
}