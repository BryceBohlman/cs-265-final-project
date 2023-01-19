using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using csis265final.DataAccessLayer;

namespace csis265final.UnitTests
{
    [TestClass]
    public class CarUnitTests
    {
        [TestMethod]
        public void CarTestNotNull()
        {
            Car temp = new Car();
            Assert.IsNotNull(temp);
        }

        [TestMethod]
        public void CarTestPropertyId()
        {
            Car temp = new Car();
            temp.Id = 1;
            Assert.AreEqual(1, temp.Id);
        }

        [TestMethod]
        public void CarTestPropertyMake()
        {
            Car temp = new Car();
            temp.Make = "Honda";
            Assert.AreEqual("Honda", temp.Make);
        }

        [TestMethod]
        public void CarTestPropertyModel()
        {
            Car temp = new Car();
            temp.Model = "Civic";
            Assert.AreEqual("Civic", temp.Model);
        }

        [TestMethod]
        public void CarTestPropertyColor()
        {
            Car temp = new Car();
            temp.Color = "White";
            Assert.AreEqual("White", temp.Color);
        }

        [TestMethod]
        public void CarTestPropertyWeight()
        {
            Car temp = new Car();
            temp.Weight = 1500;
            Assert.AreEqual(1500, temp.Weight);
        }

        [TestMethod]
        public void CarTestPropertyMpg()
        {
            Car temp = new Car();
            temp.Mpg = 35;
            Assert.AreEqual(35, temp.Mpg);
        }

        [TestMethod]
        public void CarTestToString()
        {
            Car temp = new Car(12, "Honda", "Civic", "White", 1500, 35);

            Assert.IsTrue(temp.ToString().Length > 0);
            Assert.IsTrue(temp.ToString().Contains("Honda"));
        }
    }
}
