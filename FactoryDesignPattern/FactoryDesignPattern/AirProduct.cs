using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDesignPattern
{
    class AirProduct : IProduct
    {
        public void Book()
        {
            Console.WriteLine("Air Booked");
        }

        public string GetTypeOfProduct()
        {
            return "Air";
        }

        public void Save()
        {
            Console.WriteLine("Air saved");
        }
    }
}
