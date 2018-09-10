using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DesignPatternAssignmentUI.Models
{
    public class Air
    {
        public int AirId { get; set; }
        public string AirName { get; set; }
        public string AirFromCity { get; set; }
        public string AirToCity { get; set; }
        public string AirClass { get; set; }
        public string IsSaved { get; set; }
        public string IsBooked { get; set; }
        public int AirPrice { get; set; }
    }
}