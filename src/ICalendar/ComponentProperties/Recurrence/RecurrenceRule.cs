using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICalendar.GeneralInterfaces;

namespace ICalendar.ComponentProperties
{
    /// <summary>
    /// Calendar Components: VEVENT, VTODO, VJOURNAL -- STANDARD, DAYLIGHT subcomponents;
    /// Value Type: RECUR;
    /// Properties Parameters: iana, non-standard
    /// </summary>
    public class RecurrenceRule : IComponentProperty, IValue<int>
    {

        public string Name => "RRULE";
        public IList<IPropertyParameter> PropertyParameters { get; set; }

        public void Serialize(TextWriter writer)
        {
            StringBuilder str = new StringBuilder("DURATION:");
            str.Append(Value);
            writer.WriteLine("{0}", str);
        }

        public IComponentProperty Deserialize(string value)
        {
            var valueStartIndex = value.IndexOf(':') + 1;
            var strValue = int.Parse(value.Substring(valueStartIndex));
            Value = strValue;
            return this;
        }

        //fix this impllement value type recur
        public int Value { get; set; }
    }
}
