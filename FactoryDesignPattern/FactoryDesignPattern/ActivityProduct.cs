using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDesignPattern
{
    class ActivityProduct : IProduct
    {
        public void Book()
        {
            Console.WriteLine("Activity Booked");
        }

        public string GetTypeOfProduct()
        {
            return "Activity";
        }

        public void Save()
        {
            Console.WriteLine("Activity saved");
        }
    }
}
