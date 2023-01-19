using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csis265final.DataAccessLayer
{
    public class CarMapper : BaseMapper
    {
        public CarMapper(SqlDataReader rdr) : base(rdr)
        {
            logger.Debug("CarMapper object instantiated");
        }

        public override object DoMapping()
        {
            Car rtnObj = new Car();

            rtnObj.Id = GetValidInt("Id");
            rtnObj.Make = GetValidString("make");
            rtnObj.Model = GetValidString("model");
            rtnObj.Color = GetValidString("color");
            rtnObj.Weight = GetValidDouble("weight");
            rtnObj.Mpg = GetValidInt("mpg");

            logger.Debug($"Mapping: " + ToString());
            return rtnObj;
        }
    }
}
