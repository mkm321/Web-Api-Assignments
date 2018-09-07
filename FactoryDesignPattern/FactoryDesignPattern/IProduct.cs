using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDesignPattern
{
    interface IProduct
    {
        void Save(string databaseOperations);
        void Book(string databaseOperations);
    }
}
