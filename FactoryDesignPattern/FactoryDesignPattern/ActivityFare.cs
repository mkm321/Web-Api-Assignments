using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDesignPattern
{
    class ActivityFare
    {
        public int ProfitOnFare(int cost)
        {
            int profit = (cost * 40) / 100;
            cost += profit;
            return cost;
        }
    }
}
