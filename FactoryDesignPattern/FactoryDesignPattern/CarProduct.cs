using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDesignPattern
{
    class CarProduct : IProduct
    {
        readonly int carId = 1;
        readonly string carName = "F1 Car";
        readonly int model = 2018;
        int cost = 1000;
        string data = "";
        bool isBook = false;
        DatabaseFactory databaseFactory = new DatabaseFactory();
        Logger logs = Logger.getInstance();
        public CarProduct()
        {
            CarFare carFare = new CarFare();
            cost = carFare.ProfitOnFare(cost);
        }
        public void Book(string databaseOperations)
        {
            logs.loggingDetails("Moving into :- Book method of car class");
            logs.loggingDetails("Performing booking operation into " + databaseOperations);
            Console.WriteLine("Booking...");
            isBook = true;;
            data = "carId:" + carId + ",carName:" + carName + ",model:" + model + ",cost:" + cost + ",isBook:" + isBook;
            databaseFactory.GetProduct(databaseOperations, data, "CarProduct");
            Console.WriteLine("..");
            Console.WriteLine("Successfully booked");
            logs.loggingDetails("Successfully booked");
        }
        public void Save(string databaseOperations)
        {
            logs.loggingDetails("Moving into :- Save method of car class");
            logs.loggingDetails("Performing save operation into " + databaseOperations);
            Console.WriteLine("Saving...");
            data = "carId:" + carId + ",carName:" + carName + ",model:" + model + ",cost:" + cost + ",isBook:" + isBook;
            databaseFactory.GetProduct(databaseOperations, data, "CarProduct");
            Console.WriteLine("..");
            Console.WriteLine("Successfully saved");
            logs.loggingDetails("Successfully saved");
        }
    }
}
