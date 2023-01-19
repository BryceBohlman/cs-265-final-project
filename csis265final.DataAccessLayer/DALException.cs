using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csis265final.DataAccessLayer
{
    public class DALException : Exception
    {
        public DALException() : base("A Data Access Layer exception occurred")
        {

        }

        public DALException(string message) : base(message)
        {

        }
    }
}