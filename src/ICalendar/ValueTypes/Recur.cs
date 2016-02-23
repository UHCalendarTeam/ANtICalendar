using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace ICalendar.ValueTypes
{
    public enum Frequencies
    {
        Minutely, Hourly, Daily, Weekly, Monthly, Yearly
    }
    public class Recur
    {
        public Frequencies Frequency { get; set; }

        public DateTime Until { get; set; }

        public int Count { get; set; }

        public int Interval { get; set; }

        public int [] BySeconds { get; set; }

        public int [] ByMinutes { get; set; }

        public int [] ByHours { get; set; }

        public int [] ByDays { get; set; }


    }
}
