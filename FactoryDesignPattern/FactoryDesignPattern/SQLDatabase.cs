using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDesignPattern
{
    class SQLDatabase : IRepository
    {
        Logger logs = Logger.getInstance();
        public void AddProduct(string data, string operation)
        {
            logs.loggingDetails("Saving into database");

        }
    }
}
