using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = "";
            do
            {
                Console.WriteLine("Choose a Product :- \nCar for Operations on Car,\nAir for operations on Air,\nActivity for operations on Activity,\nHotel for Operations on Hotel\nExit to Exit");
                product = Console.ReadLine();
                FactoryOperations factoryMethod = new FactoryOperations();
                IProduct iProduct = factoryMethod.GetProduct(product);
                string productOperations="";
                do
                {
                    Console.WriteLine("Choose an Operation :- \nSave to Save Item, \nBook to Book Item, \nExit to Exit");
                    productOperations = Console.ReadLine();
                    switch (productOperations)
                    {
                        case "Save": iProduct.Save();
                            break;
                        case "Book": iProduct.Book();
                            break;
                        case "Exit": Console.WriteLine("Exiting...");
                            break;
                        default: Console.WriteLine("Wrong Operation!!!");
                            break;
                    }
                }
                while (productOperations!="Exit");
                iProduct.Book();
                iProduct.Save();
            }
            while (product!="Exit");
            Console.ReadKey();
        }
    }
}
