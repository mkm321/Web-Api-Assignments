using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDesignPattern
{
    class AirProduct : IProduct
    {
        readonly int ticketNumber = 2044;
        readonly string airline = "Air India";
        readonly int seats = 2;
        int fare = 10000;
        string data = "";
        bool isBook = false;
        DatabaseFactory databaseFactory = new DatabaseFactory();
        Logger logs = Logger.getInstance();
        public AirProduct()
        {
            AirFare airFare = new AirFare();
            fare = airFare.ProfitOnFare(fare);
        }
        public void Book(string databaseOperations)
        {
            logs.loggingDetails("Moving into :- Book method of air class");
            logs.loggingDetails("Performing booking operation into " + databaseOperations);
            Console.WriteLine("Booking...");
            isBook = true;
            data = "ticketNumber:" + ticketNumber + ",airline:" + airline + ",seats:" + seats + ",fare:" + fare + ",isBook:" + isBook;
            databaseFactory.GetProduct(databaseOperations, data, "AirProduct");
            Console.WriteLine("..");
            Console.WriteLine("Successfully booked");
            logs.loggingDetails("Successfully booked");
        }
        public void Save(string databaseOperations)
        {
            logs.loggingDetails("Moving into :- Save method of air class");
            logs.loggingDetails("Performing save operation into " + databaseOperations);
            Console.WriteLine("Saving...");
            data = "ticketNumber:" + ticketNumber + ",airline:" + airline + ",seats:" + seats + ",fare:" + fare + ",isBook:" + isBook;
            databaseFactory.GetProduct(databaseOperations, data, "AirProduct");
            Console.WriteLine("..");
            Console.WriteLine("Successfully saved");
            logs.loggingDetails("Successfully saved");
        }
    }
}
