using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DesignPatternAssignmentUI.Models
{
    public class Activity
    {
        public int ActivityId { get; set; }
        public string ActivityName { get; set; }
        public int ActivityPrice { get; set; }
        public string ActivityType { get; set; }
        public string IsSaved { get; set; }
        public string IsBooked { get; set; }
    }
}