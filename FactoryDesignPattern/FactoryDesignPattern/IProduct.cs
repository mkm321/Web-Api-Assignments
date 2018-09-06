using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDesignPattern
{
    interface IProduct
    {
        string GetTypeOfProduct();
        void Save();
        void Book();
    }
}
