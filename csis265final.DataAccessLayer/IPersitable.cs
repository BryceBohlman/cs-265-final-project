using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csis265final.DataAccessLayer
{
    public interface IPersistable
    {
        object SelectOneObject(object filter);

        IList<object> SelectManyObjects(object filter);

        object InsertOneObject(object obj);

        object UpdateOneObject(object obj);

        void DeleteOneObject(object obj);
    }
}
