using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDesignPattern
{
    interface IFareCalculator
    {
        int ProfitOnFare(int cost);
    }
}
