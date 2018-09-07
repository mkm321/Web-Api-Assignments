using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDesignPattern
{
    class AirFare
    {
        public int ProfitOnFare(int cost)
        {
            int profit = (cost * 30) / 100;
            cost += profit;
            return cost;
        }
    }
}
