using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using csis265final.DataAccessLayer;

namespace csis265final.UnitTests
{
    [TestClass]
    public class CarDaoUnitTests
    {
        private string connectionString
            = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\vsprojects\\csis265final\\csis265final\\App_Data\\csis265final.mdf;Integrated Security=True";

        private string connectionKey = "localhost";

        [TestMethod]
        public void TestCarDaoNotNullConnKeyPassed()
        {
            try
            {
                CarDao dao = new CarDao(connectionKey);
                Assert.IsNotNull(dao);
            }
            catch (DALException ex)
            {
                System.Console.WriteLine(ex.Message);
                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void TestCarDaoNotNullDefaultConnKey()
        {
            try
            {
                CarDao dao = new CarDao();
                Assert.IsNotNull(dao);
            }
            catch (DALException ex)
            {
               System.Console.WriteLine(ex.Message);
               Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void TestCarDaoSelectOne()
        {
            try
            {
                CarDao dao = new CarDao();
                Car filter = new Car(1, "", "", "", -3.14, -1);
                Car rtnObj = (Car)dao.SelectOneObject(filter);
                Assert.IsNotNull(rtnObj);
            }
            catch (DALException ex)
            {
                System.Console.WriteLine(ex.Message);
                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void TestCarDaoInsertOne()
        {
            try
            {
                CarDao dao = new CarDao();
                Car obj = new Car(-1, "Toyota", "Carolla", "Beige", 1950.87, 17);
                Car rtnObj = (Car)dao.InsertOneObject(obj);
                Assert.IsTrue(rtnObj.Id > 0);
            }
            catch (DALException ex)
            {
                System.Console.WriteLine(ex.Message);
                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void TestCarDaoUpdateAndSelectOne()
        {
            try
            {
                CarDao dao = new CarDao();
                Car filter = new Car(1, "FordZZ", "RaptorZZ", "Red", 3200, 14);
                Car rtnObj = (Car)dao.UpdateOneObject(filter);

                filter = new Car(1, "", "", "", -3.14, -1);
                rtnObj = (Car)dao.SelectOneObject(filter);

                Assert.IsTrue(rtnObj.Make.Contains("ZZ"));
                Assert.IsTrue(rtnObj.Model.Contains("ZZ"));
            }
            catch (DALException ex)
            {
                System.Console.WriteLine(ex.Message);
                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void TestCarDaoDeleteAndSelectOne()
        {
            try
            {
                CarDao dao = new CarDao();
                Car filter = new Car(4, "", "", "", -3.14, -1);
                dao.DeleteOneObject(filter);

                filter = new Car(4, "", "", "", -3.14, -1);
                Car rtnObj = (Car)dao.SelectOneObject(filter);

                Assert.IsNull(rtnObj);
            }
            catch (DALException ex)
            {
                System.Console.WriteLine(ex.Message);
                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void TestCarDaoSelectMany()
        {
            try
            {
                CarDao dao = new CarDao();
                Car filter = new Car(3, "", "", "", -3.14, -1);
                IList<object> objList = (IList<object>)dao.SelectManyObjects(filter);
                Assert.IsNotNull(objList);
                Assert.IsTrue(objList.Count > 0);
            }
            catch (DALException ex)
            {
                System.Console.WriteLine(ex.Message);
                Assert.IsTrue(false);
            }
        }
    }
}
