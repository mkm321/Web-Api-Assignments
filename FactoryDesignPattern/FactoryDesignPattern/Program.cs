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
            string productOperations = "";
            Logger logs = Logger.getInstance();
            string databaseOperations = "";
            do
            {
                Console.WriteLine("Choose a Product :- \nCar for Operations on Car,\nAir for operations on Air,\nActivity for operations on Activity,\nHotel for Operations on Hotel\nExit to Exit");
                product = Console.ReadLine();
                Console.WriteLine();
                logs.loggingDetails("Moving into :- Main Program");
                logs.loggingDetails("Fetching Product From user...");
                logs.loggingDetails("Fetched " + product + " From user");
                FactoryOperations factoryMethod = new FactoryOperations();
                if (product != "Exit")
                {
                    do
                    {
                        Console.WriteLine("Choose an Operation :- \nSave to Save Item, \nBook to Book Item, \nExit to Exit");
                        productOperations = Console.ReadLine();
                        logs.loggingDetails("Fetching an Operation");
                        logs.loggingDetails("Fetched " + productOperations + " From user");
                        Console.WriteLine();
                        if (productOperations != "Exit")
                        {
                            Console.WriteLine("Choose a Database :- \nSQL, \nFile");
                            databaseOperations = Console.ReadLine();
                            logs.loggingDetails("Fetching a datbase");
                            logs.loggingDetails("Fetched " + databaseOperations + " From user");
                            Console.WriteLine();
                            factoryMethod.GetProduct(product, productOperations, databaseOperations);
                        }
                    }
                    while (productOperations != "Exit");
                }
            }
            while (product!="Exit");
            Console.WriteLine("Exited");
            logs.loggingDetails("Exiting From the program!!!");
            Console.ReadKey();
        }
    }
}
