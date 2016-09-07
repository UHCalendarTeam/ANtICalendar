using System;
using System.Text;

namespace ICalendar.ValueTypes
{
    public class Period
    {
        public Period(DateTime? start, DateTime? end)
        {
            Start = start;
            End = end;
        }

        public Period(DateTime? start, DurationType duration)
        {
            Start = start;
            Duration = duration;
        }

        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public DurationType Duration { get; set; }

        public override string ToString()
        {
            StringBuilder strBuilder = new StringBuilder();
            if (Start != null)
                strBuilder.Append(Start.Value.ToString("yyyyMMddTHHmmss") + (Start.Value.Kind == DateTimeKind.Utc ? "Z" : ""));
            strBuilder.Append("/");
            strBuilder.Append(End?.ToString() ?? Duration.ToString());
            return strBuilder.ToString();
        }
    }
}