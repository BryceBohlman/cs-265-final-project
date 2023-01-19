using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using csis265final.DataAccessLayer;
using System.Data.SqlClient;

namespace csis265final.UnitTests
{
    [TestClass]
    public class CarMapperUnitTests
    {
        private string connectionString
            = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\vsprojects\\csis265final\\csis265final\\App_Data\\csis265final.mdf;Integrated Security=True";

        private string connectionKey = "localhost";

        protected SqlConnection conn;
        protected SqlCommand cmd;
        protected SqlDataReader rdr;
        private string sql = "SELECT ID, MAKE, MODEL, COLOR, WEIGHT, MPG " +
                                                              " FROM CAR " +
                                                    " WHERE ID = 1; ";

        [TestMethod]
        public void TestCarMapperNotNull()
        {
            Car mappingObject = new Car(-1, "", "", "", -3.14, -1);
            conn = new SqlConnection(connectionString);
            conn.Open();

            cmd = new SqlCommand(sql, conn);

            SqlDataReader rdr = cmd.ExecuteReader();
            CarMapper mapper = new CarMapper(rdr);

            Assert.IsNotNull(mapper);
        }
    }
}
