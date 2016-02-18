using System;
using System.IO;
using System.Text;
using ICalendar.GeneralInterfaces;

namespace ICalendar.ComponentProperties
{
    /// <summary>
    /// Calendar Components: VEVENT, VFREEBUSY;
    /// Value Type: UTC;
    /// Properties Parameters: iana, non-standard, value data type, time zone identifier
    /// </summary>
    public class DateTimeEnd : DateTimeProperty
    {
        public override string Name => "DTEND";

        public override void Serialize(TextWriter writer)
        {
            StringBuilder str = new StringBuilder("DTEND:");
            str.Append(Value);
            writer.WriteLine("{0}", str);
        }

        public override IComponentProperty Deserialize(string value)
        {
            var valueStartIndex = value.IndexOf(':') + 1;
            var strValue = DateTime.Parse(value.Substring(valueStartIndex));
            Value = strValue;
            return this;
        }

        public override DateTime Value { get; set; }
    }
}
