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

namespace App_Code.BillSettings
{
    #region Bill Configuration Object

    public class BillConfigure
    {
        #region Constructer

        public BillConfigure()
        {

        }
        #endregion

        #region Fields & Properties

        private DateTime applicableDate = DateTime.Now;
        public DateTime ApplicableDate
        {
            get { return applicableDate; }
            set { applicableDate = value; }
        }

        private double fixedCharge=0;
        public double FixedCharge
        {
            get { return fixedCharge; }
            set { fixedCharge = value; }
        }

        private double adjCharge = 0;
        public double AdjCharge
        {
            get { return adjCharge; }
            set { adjCharge = value; }
        }

        private double defCharge = 0;
        public double DefCharge
        {
            get { return defCharge; }
            set { defCharge = value; }
        }

        private double electricityTax = 0;
        public double ElectricityTax
        {
            get { return electricityTax; }
            set { electricityTax = value; }
        }

        private string slabSize = "";
        public string SlabSize
        {
            get { return slabSize; }
            set { slabSize = value; }
        }

        private string slabPrice = "";
        public string SlabPrice
        {
            get { return slabPrice; }
            set { slabPrice = value; }
        }

        private int id = 0;
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

     #endregion

    }

    public static class Bill_Configure
    {

        #region Feilds

        private static string connString = ConfigurationManager.ConnectionStrings["BillingAppConnectionString"].ConnectionString;

        private static DbProviderFactory provider = DbProviderFactories.GetFactory(ConfigurationManager.ConnectionStrings["BillingAppConnectionString"].ProviderName);
        private static string parmPrefix = "@";

        #endregion

        #region Methods

        public static BillConfigure GetLatestConfiguration()
        {
           BillConfigure billObj = new BillConfigure();

            try
            {
                using (DbConnection conn = provider.CreateConnection())
                {
                    conn.ConnectionString = connString;

                    using (DbCommand cmd = conn.CreateCommand())
                    {
                        string sqlQuery = "SELECT MAX(ID),fixed_charge,adj_charge,def_charge,electicity_tax,slab_size,slab_price,applicable_date" +
                                         " FROM bill_settings GROUP BY ID";

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
                                    billObj = new BillConfigure();

                                    if (!rdr.IsDBNull(0))
                                    {
                                        billObj.ID = rdr.GetInt32(0);
                                    }
                                    if (!rdr.IsDBNull(1))
                                    {
                                        billObj.FixedCharge = rdr.GetDouble(1);
                                    }
                                    if (!rdr.IsDBNull(2))
                                    {
                                        billObj.AdjCharge = rdr.GetDouble(2);
                                    }
                                    if (!rdr.IsDBNull(3))
                                    {
                                        billObj.DefCharge = rdr.GetDouble(3);
                                    }
                                    if (!rdr.IsDBNull(4))
                                    {
                                        billObj.ElectricityTax = rdr.GetDouble(4);
                                    }
                                    if (!rdr.IsDBNull(5))
                                    {
                                        billObj.SlabSize = rdr.GetString(5);
                                    }
                                    if (!rdr.IsDBNull(6))
                                    {
                                        billObj.SlabPrice = rdr.GetString(6);
                                    }
                                    if (!rdr.IsDBNull(7))
                                    {
                                        billObj.ApplicableDate = rdr.GetDateTime(7);
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
            return billObj;

        }

    
        public static bool InsertConfiguration(BillConfigure billObj)
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
                        sqlQuery = "INSERT INTO bill_settings" +
                               "(fixed_charge,adj_charge,def_charge,electicity_tax,slab_size,slab_price, applicable_date) " +
                               "VALUES(@fixChrg,@adjChrg,@defChrg,@elecTax,@slbSiz,@slbPrc,@appliedDate)";

                        if (parmPrefix != "@")
                        {
                            sqlQuery = sqlQuery.Replace("@", parmPrefix);
                        }
                        cmd.CommandText = sqlQuery;
                        cmd.CommandType = CommandType.Text;



                        DbParameter sFixCharge = provider.CreateParameter();
                        sFixCharge.ParameterName = parmPrefix + "fixChrg";
                        sFixCharge.Value = billObj.FixedCharge;
                        cmd.Parameters.Add(sFixCharge);

                        DbParameter sAdjChrg = provider.CreateParameter();
                        sAdjChrg.ParameterName = parmPrefix + "adjChrg";
                        sAdjChrg.Value = billObj.AdjCharge;
                        cmd.Parameters.Add(sAdjChrg);

                        DbParameter sDefChrg = provider.CreateParameter();
                        sDefChrg.ParameterName = parmPrefix + "defChrg";
                        sDefChrg.Value = billObj.DefCharge;
                        cmd.Parameters.Add(sDefChrg);

                        DbParameter sElecTax = provider.CreateParameter();
                        sElecTax.ParameterName = parmPrefix + "elecTax";
                        sElecTax.Value = billObj.ElectricityTax;
                        cmd.Parameters.Add(sElecTax);

                        DbParameter sSlabSize = provider.CreateParameter();
                        sSlabSize.ParameterName = parmPrefix + "slbSiz";
                        sSlabSize.Value = billObj.SlabSize;
                        cmd.Parameters.Add(sSlabSize);

                        DbParameter sSlabPrc = provider.CreateParameter();
                        sSlabPrc.ParameterName = parmPrefix + "slbPrc";
                        sSlabPrc.Value = billObj.SlabPrice;
                        cmd.Parameters.Add(sSlabPrc);

                        DbParameter sAppliedDate = provider.CreateParameter();
                        sAppliedDate.ParameterName = parmPrefix + "appliedDate";
                        sAppliedDate.Value = billObj.ApplicableDate;
                        cmd.Parameters.Add(sAppliedDate);

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

        public static bool UpdateConfiguration(BillConfigure billObj, int id)
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
                        sqlQuery = "Update bill_settings SET " +
                               "fixed_charge=@fixChrg, adj_charge=@adjChrg, def_charge=@defChrg, electicity_tax=@elecTax, slab_size=@slbSiz, slab_price=@slbPrc, applicable_date=@appliedDate " +
                               "WHERE ID="+id;

                        if (parmPrefix != "@")
                        {
                            sqlQuery = sqlQuery.Replace("@", parmPrefix);
                        }
                        cmd.CommandText = sqlQuery;
                        cmd.CommandType = CommandType.Text;



                        DbParameter sFixCharge = provider.CreateParameter();
                        sFixCharge.ParameterName = parmPrefix + "fixChrg";
                        sFixCharge.Value = billObj.FixedCharge;
                        cmd.Parameters.Add(sFixCharge);

                        DbParameter sAdjChrg = provider.CreateParameter();
                        sAdjChrg.ParameterName = parmPrefix + "adjChrg";
                        sAdjChrg.Value = billObj.AdjCharge;
                        cmd.Parameters.Add(sAdjChrg);

                        DbParameter sDefChrg = provider.CreateParameter();
                        sDefChrg.ParameterName = parmPrefix + "defChrg";
                        sDefChrg.Value = billObj.DefCharge;
                        cmd.Parameters.Add(sDefChrg);

                        DbParameter sElecTax = provider.CreateParameter();
                        sElecTax.ParameterName = parmPrefix + "elecTax";
                        sElecTax.Value = billObj.ElectricityTax;
                        cmd.Parameters.Add(sElecTax);

                        DbParameter sSlabSize = provider.CreateParameter();
                        sSlabSize.ParameterName = parmPrefix + "slbSiz";
                        sSlabSize.Value = billObj.SlabSize;
                        cmd.Parameters.Add(sSlabSize);

                        DbParameter sSlabPrc = provider.CreateParameter();
                        sSlabPrc.ParameterName = parmPrefix + "slbPrc";
                        sSlabPrc.Value = billObj.SlabPrice;
                        cmd.Parameters.Add(sSlabPrc);

                        DbParameter sAppliedDate = provider.CreateParameter();
                        sAppliedDate.ParameterName = parmPrefix + "appliedDate";
                        sAppliedDate.Value = billObj.ApplicableDate;
                        cmd.Parameters.Add(sAppliedDate);

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

    #endregion
}

