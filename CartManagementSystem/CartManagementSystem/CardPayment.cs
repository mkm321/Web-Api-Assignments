using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartManagementSystem
{
    class CardPayment : IPayment, ICardPayment
    {
        public void SaveBankingDetails()
        {
            Console.WriteLine("Inside Card Payment");
            Console.WriteLine();
        }

        public void SaveCardDetails()
        {
            Console.WriteLine("Saving card details...");
            Console.WriteLine();
        }
    }
}
