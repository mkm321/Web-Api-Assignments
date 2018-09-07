using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDesignPattern
{
    class DatabaseFactory
    {
        public void GetProduct(string databaseOperation, string data, string operation)
        {
            Logger logs = Logger.getInstance();
            databaseOperation = ConfigurationManager.AppSettings[databaseOperation];
            logs.loggingDetails("Moving into :- Database Factory Operation class");
            logs.loggingDetails("Got an instance of class dynamically through reflection");
            Type type = Type.GetType(databaseOperation);
            ConstructorInfo constructor = type.GetConstructor(Type.EmptyTypes);
            object classObj = constructor.Invoke(new object[] { });
            logs.loggingDetails("Invoking the class method");
            MethodInfo method = type.GetMethod("AddProduct");
            method.Invoke(classObj, new object[] { data, operation });
        }
    }
}
