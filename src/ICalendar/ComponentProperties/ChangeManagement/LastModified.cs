using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ICalendar.GeneralInterfaces;

namespace ICalendar.ComponentProperties
{
    /// <summary>
    /// Calendar Components: VEVENT, VTODO, VJOURNAL, VTIMEZONE;
    /// Value Type: DATETIME;
    /// Properties Parameters: iana, non-standard
    /// </summary>
    public class LastModified : IComponentProperty, IValue<DateTime>
    {
        public string Name => "LAST-MODIFIED";
        public IList<IPropertyParameter> PropertyParameters { get; set; }

        public void Serialize(TextWriter writer)
        {
            StringBuilder str = new StringBuilder("LAST-MODIFIED:");
            str.Append(Value);
            writer.WriteLine("{0}", str);
        }

        public IComponentProperty Deserialize(string value)
        {
            var valueStartIndex = value.IndexOf(':') + 1;
            var strValue = System.DateTime.Parse(value.Substring(valueStartIndex));
            Value = strValue;
            return this;
        }

        public DateTime Value { get; set; }
    }
}
