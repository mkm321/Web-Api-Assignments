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
            string product = Console.ReadLine();
            FactoryMethod factoryMethod = new FactoryMethod();
            IProduct iProduct = factoryMethod.GetProduct(product);
            Console.WriteLine(iProduct.GetTypeOfProduct());
            iProduct.Book();
            iProduct.Save();
            Console.ReadKey();
        }
    }
}
