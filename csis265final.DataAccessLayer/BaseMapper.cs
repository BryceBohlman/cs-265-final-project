using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace csis265final.DataAccessLayer
{
    public abstract class BaseMapper
    {
        protected log4net.ILog logger
            = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected SqlDataReader rdr;

        public BaseMapper(SqlDataReader rdr)
        {
            this.rdr = rdr;
        }

        public abstract object DoMapping();

        public int GetValidInt(string columnName)
        {
            try
            {
                return Convert.ToInt32(rdr[columnName].ToString());
            }
            catch (Exception ex)
            {
                logger.Error($"{columnName} had invalid data {ex.Message}");
                return -1;
            }
        }
        public double GetValidDouble(string columnName)
        {
            try
            {
                return Convert.ToDouble(rdr[columnName].ToString());
            }
            catch (Exception ex)
            {
                logger.Error($"{columnName} had invalid data {ex.Message}");
                return -1;
            }
        }
        public bool GetValidBool(string columnName)
        {
            try
            {
                return Convert.ToBoolean(rdr[columnName].ToString());
            }
            catch (Exception ex)
            {
                logger.Error($"{columnName} had invalid data {ex.Message}");
                return false;
            }
        }
        public string GetValidString(string columnName)
        {
            try
            {
                return Convert.ToString(rdr[columnName].ToString());
            }
            catch (Exception ex)
            {
                logger.Error($"{columnName} had invalid data {ex.Message}");
                return string.Empty;
            }
        }
    }
}
