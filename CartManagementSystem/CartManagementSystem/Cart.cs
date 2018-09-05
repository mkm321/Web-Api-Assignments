using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartManagementSystem
{
    class Cart : ICartInterface
    {
        Database database = new Database();
        double totalAmount = 0;
        public void AddItems(Item item)
        {
            database.Items.Add(item);
            Console.WriteLine("Item Added");
            Console.WriteLine();
        }

        public void PaymentDetails(IPayment payment)
        {
            payment.SaveBankingDetails();
        }

        public void RemoveItems(Item item)
        {
            database.Items.Remove(item);
            Console.WriteLine("Item Removed");
            Console.WriteLine();
        }

        public void ShowCart()
        {
            Console.WriteLine("Fetching Items...");
            Console.WriteLine();
            for (int iterator = 0; iterator < database.Items.Count; iterator++)
            {
                Console.WriteLine("Item Id " + database.Items[iterator].ItemID);
                Console.WriteLine("Item Name " + database.Items[iterator].ItemName);
                Console.WriteLine("Item Price " + database.Items[iterator].ItemPrice);
                Console.WriteLine("Item Quantity " + database.Items[iterator].ItemQuantity);
                Console.WriteLine("------------------------------------------");
            }
            Console.WriteLine();
        }

        public double TotalAmount()
        {
            for (int iterator = 0; iterator < database.Items.Count; iterator++)
            {
                totalAmount += (database.Items[iterator].ItemPrice * database.Items[iterator].ItemQuantity);
            }
            Console.WriteLine("Total amount is :-");
            return totalAmount;
        }
    }
}
