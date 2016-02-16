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
    /// Calendar Components: VTODO, VEVENT, VALARM;
    /// Value Type: DURATION;
    /// Properties Parameters: iana, non-standard
    /// </summary>
    public class Duration : IComponentProperty
    {

        public string Name => "DURATION";
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


        //change this to duration type implement
        public int Value { get; set; }

    }
}
