using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDesignPattern
{
    class FactoryMethod
    {
        public IProduct GetProduct(string product)
        {
            switch (product)
            {
                case "car": return new CarProduct();
                    break;
                case "hotel": return new HotelProduct();
                    break;
                case "activity": return new ActivityProduct();
                    break;
                default: return new AirProduct();
                    break;
            }
        }
    }
}
