using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace ICalendar.ValueTypes
{
    public class DurationType
    {
        public DurationType(bool isPos, int weeks)
        {
            IsPositive = isPos;
            Weeks = weeks;
        }

        public DurationType(bool isPos, int days, bool hasTime, int hours = 0, int minutes = 0, int seconds = 0)
        {
            IsPositive = isPos;
            Days = days;

            if (hasTime)
            {
                Hours = hours;
                Minutes = minutes;
                Seconds = seconds;
            }
        }

        public DurationType(bool isPos, int hours, int minutes, int seconds)
        {
            IsPositive = isPos;
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
        }

        public int? Days { get; set; }

        public int? Hours { get; set; }

        public int? Minutes { get; set; }

        public int? Seconds { get; set; }

        public int? Weeks { get; set; }

        public bool IsPositive { get; set; }

        public override string ToString()
        {
            StringBuilder strbuilder = new StringBuilder();
            strbuilder.Append(IsPositive ? "" : "-");
            strbuilder.Append("P");
            if (Weeks != null)
            {
                strbuilder.AppendLine(Weeks.ToString() + "W");
            }
            else if (Days != null)
            {
                strbuilder.Append(Days.ToString() + "D");
                if (Hours != null)
                {
                    strbuilder.Append(Hours.ToString() + "H");
                }
                if (Minutes != null)
                {
                    strbuilder.Append(Minutes.ToString() + "M");
                }
                if (Seconds != null)
                {
                    strbuilder.Append(Seconds.ToString() + "S");
                }
            }
            else if (Hours != null)
            {
                strbuilder.Append(Hours.ToString() + "H");

                if (Minutes != null)
                {
                    strbuilder.Append(Minutes.ToString() + "M");
                }
                if (Seconds != null)
                {
                    strbuilder.Append(Seconds.ToString() + "S");
                }
            }
            else if (Minutes != null)
            {
                strbuilder.Append(Minutes.ToString() + "M");
                if (Seconds != null)
                {
                    strbuilder.Append(Seconds.ToString() + "S");
                }
            }
            else if (Seconds != null)
            {
                strbuilder.Append(Seconds.ToString() + "S");
            }
            else
            {
                throw new NullReferenceException();
            }




            return strbuilder.ToString();
        }
    }
}
