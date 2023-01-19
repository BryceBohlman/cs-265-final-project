using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace csis265final.DataAccessLayer
{
    public class Car
    {
        protected static readonly ILog logger =
    LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public double Weight { get; set; }
        public int Mpg { get; set; }

        public Car()
        {
            logger.Debug("Car object instantiated using default constructor");
        }

        public Car(int id, string make, string model, string color, double weight, int mpg)
        {
            Id = id;
            Make = make;
            Model = model;
            Color = color;
            Weight = weight;
            Mpg = mpg;

            logger.Debug("Car object instantiated using 6 argument constructor: " + ToString());
        }

        public override string ToString()
        {
            string output = $"CAR: ID: {Id}    MAKE: {Make}    MODEL: {Model}    COLOR: {Color}    WGT: {Weight}    MPG: {Mpg}    ";
            return output;
        }
    }
}
