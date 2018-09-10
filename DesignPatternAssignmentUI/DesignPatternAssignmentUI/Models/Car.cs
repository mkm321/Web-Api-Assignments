using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DesignPatternAssignmentUI.Models
{
    public class Car
    {
        public int CarId { get; set; }
        public string CarName { get; set; }
        public string CarModel { get; set; }
        public string IsSaved { get; set; }
        public string IsBooked { get; set; }
        public string CarColour { get; set; }
        public int CarPrice { get; set; }
        public string CarType { get; set; }
        public string CarBrandName { get; set; }
    }
}