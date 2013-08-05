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

namespace App_Code.UserRegisterationProcess
{
    #region Users Object

    public class UserRegisteration
    {
        #region Constructer

        public UserRegisteration()
        {
         
        }
        #endregion

        #region Fields & Properties


        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string name = "";
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string apartment = "";
        public string Apartment
        {
            get { return apartment; }
            set { apartment = value; }
        }

        private string email = "";
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string building = "";
        public string Building
        {
            get { return building; }
            set { building = value; }
        }

        private string contactNo = "";
        public string ContactNo
        {
            get { return contactNo; }
            set { contactNo = value; }
        }

        private string status = "pending";
        public string Status
        {
            get { return status; }
            set { status = value; }
        }
      

        #endregion

    }

    public static class User_Registration
    {
        #region Feilds

        private static string connString = ConfigurationManager.ConnectionStrings["BillingAppConnectionString"].ConnectionString;

        private static DbProviderFactory provider = DbProviderFactories.GetFactory(ConfigurationManager.ConnectionStrings["BillingAppConnectionString"].ProviderName);
        private static string parmPrefix = "@";

        #endregion


        #region Methods

        public static bool InsertRequest(UserRegisteration insertUser)
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
                        sqlQuery = "INSERT INTO Register_Requests" +
                               "(Building,Apartment,Name,ContactNo,EMail, Status) " +
                               "VALUES(@build,@apartment,@fullName,@mobile,@email, 'pending')";

                        if (parmPrefix != "@")
                        {
                            sqlQuery = sqlQuery.Replace("@", parmPrefix);
                        }
                        cmd.CommandText = sqlQuery;
                        cmd.CommandType = CommandType.Text;

                        DbParameter sNewId = provider.CreateParameter();
                        sNewId.ParameterName = parmPrefix + "build";
                        sNewId.Value = insertUser.Building;
                        cmd.Parameters.Add(sNewId);

                        DbParameter sUserName = provider.CreateParameter();
                        sUserName.ParameterName = parmPrefix + "apartment";
                        sUserName.Value = insertUser.Apartment;
                        cmd.Parameters.Add(sUserName);


                        DbParameter sFullName = provider.CreateParameter();
                        sFullName.ParameterName = parmPrefix + "fullName";
                        sFullName.Value = insertUser.Name;
                        cmd.Parameters.Add(sFullName);

                        DbParameter sMobile = provider.CreateParameter();
                        sMobile.ParameterName = parmPrefix + "mobile";
                        sMobile.Value = insertUser.ContactNo;
                        cmd.Parameters.Add(sMobile);

                        DbParameter sAddress = provider.CreateParameter();
                        sAddress.ParameterName = parmPrefix + "email";
                        sAddress.Value = insertUser.Email;
                        cmd.Parameters.Add(sAddress);


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

        public static bool UpdateRequest(UserRegisteration insertUser)
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
                        sqlQuery = "UPDATE Register_Requests SET " +
                               "Status = @stat WHERE Building = @build AND Apartment = @apartment";

                        if (parmPrefix != "@")
                        {
                            sqlQuery = sqlQuery.Replace("@", parmPrefix);
                        }
                        cmd.CommandText = sqlQuery;
                        cmd.CommandType = CommandType.Text;

                        DbParameter sNewId = provider.CreateParameter();
                        sNewId.ParameterName = parmPrefix + "build";
                        sNewId.Value = insertUser.Building;
                        cmd.Parameters.Add(sNewId);

                        DbParameter sUserName = provider.CreateParameter();
                        sUserName.ParameterName = parmPrefix + "apartment";
                        sUserName.Value = insertUser.Apartment;
                        cmd.Parameters.Add(sUserName);


                        DbParameter sStatus = provider.CreateParameter();
                        sStatus.ParameterName = parmPrefix + "stat";
                        sStatus.Value = insertUser.Status;
                        cmd.Parameters.Add(sStatus);



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