using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DesignPatternAssignmentUI.Models
{
    public class Hotel
    {
        public int HotelId { get; set; }
        public string HotelName { get; set; }
        public string HotelCity { get; set; }
        public int HotelAvailableRooms { get; set; }
        public string IsSaved { get; set; }
        public string IsBooked { get; set; }
        public string HotelRoomType { get; set; }
        public int HotelPrice { get; set; }
    }
}