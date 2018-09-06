using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDesignPattern
{
    class CarProduct : IProduct
    {
        public void Book()
        {
            Console.WriteLine("Car Booked");
        }

        public string GetTypeOfProduct()
        {
            return "Car";
        }

        public void Save()
        {
            Console.WriteLine("Car saved");
        }
    }
}
