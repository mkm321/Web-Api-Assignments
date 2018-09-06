using System;
using System.Linq;
using System.Configuration;

namespace FactoryDesignPattern
{
    class FactoryOperations
    {
        public IProduct GetProduct(string product)
        {
            //aConsole.WriteLine(product);
            product = ConfigurationManager.AppSettings[product];
            Type type = Type.GetType(product, true);
            IProduct productInstance = (IProduct)Activator.CreateInstance(type);
            return productInstance;
        }
    }
}
