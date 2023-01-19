using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using System.Configuration;

namespace csis265final.DataAccessLayer
{
    public abstract class BaseDao
    {
        protected static readonly ILog logger2 =
            LogManager.GetLogger("MyLogger");

        protected static readonly ILog logger =
            LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected static readonly string DEFAULT_CONNECTION_KEY = "localhost";

        protected SqlConnection conn;
        protected SqlCommand cmd;
        protected SqlDataAdapter adpt;
        protected SqlDataReader rdr;
        protected string connectionString;
        protected string sql;

        public BaseDao()
        {
            logger.Debug($"Getting connection string using key: {DEFAULT_CONNECTION_KEY}");
            SetConnectionString(DEFAULT_CONNECTION_KEY);
        }

        public BaseDao(string connectionKey)
        {
            logger.Debug($"Getting connection string using key: {connectionKey}");
            SetConnectionString(connectionKey);
        }

        public void SetConnectionString(string connectionKey)
        {
            if (connectionKey.Trim().Length == 0)
            {
                logger.Error("Data Access Layer Exception: Connection key is blank");
                throw new DALException("DAL connection key must not be blank"); 
            }

            try
            {
                connectionString = ConfigurationManager.ConnectionStrings[connectionKey].ToString();
                logger.Debug($"Connection string set from key: {connectionKey} String: {connectionString}");
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                throw new DALException("The DAL connection key does not exist in the config file");
            }

            if (connectionString.Trim().Length == 0)
            {
                throw new DALException("DAL connection string must not be blank");
            }

            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                conn.Close();
                conn.Dispose();
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                throw new DALException("Cannot connect to the database");
            }
        }

        public void Cleanup()
        {
            if (rdr != null)
            {
                rdr.Close();
            }

            if (cmd != null)
            {
                cmd.Dispose();
            }

            if (adpt != null)
            {
                adpt.Dispose();
            }

            if (conn != null)
            {
                conn.Close();
                conn.Dispose();
            }
        }
    }
}
