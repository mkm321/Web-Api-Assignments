using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDesignPattern
{
    class HotelProduct : IProduct
    {
        readonly int hotelId = 2;
        readonly string hotelName = "Hyatt";
        readonly int availableRooms = 5;
        int fare = 100;
        string data = "";
        bool isBook = false;
        DatabaseFactory databaseFactory = new DatabaseFactory();
        Logger logs = Logger.getInstance();
        public HotelProduct()
        {
            HotelFare hotelFare = new HotelFare();
            fare = hotelFare.ProfitOnFare(fare);
        }
        public void Book(string databaseOperations)
        {
            logs.loggingDetails("Moving into :- Book method of hotel class");
            logs.loggingDetails("Performing booking operation into " + databaseOperations);
            Console.WriteLine("Booking...");
            isBook = true;
            data = "hotelId:" + hotelId + ",hotelName:" + hotelName + ",availableRooms:" + availableRooms + ",fare:" + fare + ",isBook:" + isBook;
            databaseFactory.GetProduct(databaseOperations, data, "HotelProduct");
            Console.WriteLine("..");
            Console.WriteLine("Successfully booked");
            logs.loggingDetails("Successfully booked");
        }
        
        public void Save(string databaseOperations)
        {
            logs.loggingDetails("Moving into :- Save method of hotel class");
            logs.loggingDetails("Performing save operation into " + databaseOperations);
            Console.WriteLine("Saving...");
            data = "hotelId:" + hotelId + ",hotelName:" + hotelName + ",availableRooms:" + availableRooms + ",fare:" + fare + ",isBook:" + isBook;
            databaseFactory.GetProduct(databaseOperations, data, "HotelProduct");
            Console.WriteLine("..");
            Console.WriteLine("Successfully saved");
            logs.loggingDetails("Successfully saved");
        }
    }
}
