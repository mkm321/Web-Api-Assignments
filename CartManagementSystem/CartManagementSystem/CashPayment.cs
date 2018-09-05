using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartManagementSystem
{
    class CashPayment : IPayment
    {
        public void SaveBankingDetails()
        {
            Console.WriteLine("Inside Cash Payment");
            Console.WriteLine();
        }
    }
}
