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
    /// Calendar Components: VFREEBUSY;
    /// Value Type: PERIOD;
    /// Properties Parameters: iana, non-standard, free/busy time type
    /// </summary>
    public class FreeBusyTime : IComponentProperty, IValue<int>
    {
        public string Name => "FREEBUSY";
        public IList<IPropertyParameter> PropertyParameters { get; set; }

        public void Serialize(TextWriter writer)
        {
            StringBuilder str = new StringBuilder("FREEBUSY:");
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

        //change this to PERIOD type implement
        public int Value { get; set; }
    }
}
