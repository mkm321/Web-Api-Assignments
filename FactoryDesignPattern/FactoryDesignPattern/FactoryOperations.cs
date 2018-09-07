using System;
using System.Linq;
using System.Configuration;
using System.Reflection;

namespace FactoryDesignPattern
{
    class FactoryOperations
    {
        public void GetProduct(string product,string productOperations, string databaseOperations)
        {
            Logger logs = Logger.getInstance();
            product = ConfigurationManager.AppSettings[product];
            logs.loggingDetails("Moving into :- Factory Operation class");
            logs.loggingDetails("Got an instance of class dynamically through reflection");
            Type type = Type.GetType(product);
            ConstructorInfo constructor = type.GetConstructor(Type.EmptyTypes);
            logs.loggingDetails("Invoking the class method");
            object classObj = constructor.Invoke(new object[] { });
            MethodInfo method = type.GetMethod(productOperations);
            method.Invoke(classObj,new object[] { databaseOperations});
        }
    }
}
