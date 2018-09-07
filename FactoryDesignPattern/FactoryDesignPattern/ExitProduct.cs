using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDesignPattern
{
    class ExitProduct : IProduct
    {
        public void Book(string databaseOperations)
        {
            Console.WriteLine("exit book");
        }

        public void Save(string databaseOperations)
        {
            Console.WriteLine("exit save");
        }
    }
}
