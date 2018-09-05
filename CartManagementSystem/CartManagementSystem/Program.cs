using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Cart cart = new Cart();
            Item item = new Item();
            CardPayment cardPayment = new CardPayment();
            CashPayment cashPayment = new CashPayment();
            item.ItemID = 1;
            item.ItemName = "Product1";
            item.ItemPrice = 40.5;
            item.ItemQuantity = 1;
            string query="";
            do
            {
                Console.WriteLine("Enter Add to Add an Item\nRemove to Remove an Item\nShow to show a cart\nAmount to Calculate Total Amount\nPay to Purchase items");
                Console.WriteLine();
                query = Console.ReadLine();
                switch (query)
                {
                    case "Add":
                        cart.AddItems(item);
                        break;
                    case "Remove":
                        Console.WriteLine();
                        cart.RemoveItems(item);
                        break;
                    case "Show":
                        Console.WriteLine();
                        cart.ShowCart();
                        break;
                    case "Amount":
                        Console.WriteLine();
                        Console.WriteLine(cart.TotalAmount());
                        Console.WriteLine();
                        break;
                    case "Pay":
                        Console.WriteLine("Enter Cash for Cash Payment\nCard for Card Payment");
                        string paymentMode = Console.ReadLine();
                        Console.WriteLine();
                        if (paymentMode == "Cash")
                        {
                            cart.PaymentDetails(cashPayment);
                        }
                        else
                        {
                            cart.PaymentDetails(cardPayment);
                        }
                        break;
                    default: Console.WriteLine("You have Entered Wrong Values!");
                        break;
                }
            } while (query != "Pay");
            Console.ReadKey();
        }
    }
}
