using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDesignPattern
{
    class ExitProduct : IProduct
    {
        public void Book()
        {
        }

        public string GetTypeOfProduct()
        {
            return "";
        }

        public void Save()
        {
        }
    }
}
