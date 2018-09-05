using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartManagementSystem
{
    interface ICartInterface
    {
        void AddItems(Item item);
        void RemoveItems(Item item);
        double TotalAmount();
        void ShowCart();
        void PaymentDetails(IPayment payment);
    }
}
