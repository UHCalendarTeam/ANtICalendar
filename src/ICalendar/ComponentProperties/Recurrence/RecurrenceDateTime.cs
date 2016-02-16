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
    /// Value Type: DATETIME/DATE/PERIOD;
    /// Properties Parameters: iana, non-standard, value data type, time zone identifier
    /// </summary>
    public class RecurrenceDateTime : IComponentProperty
    {
        public string Name => "RDATE";
        public IList<IPropertyParameter> PropertyParameters { get; set; }

        public void Serialize(TextWriter writer)
        {
            StringBuilder str = new StringBuilder("RDATE:");
            var flag = false;
            foreach (var cat in Value)
            {
                if (flag)
                    str.Append(',');
                str.Append(cat);
                flag = true;
            }
            writer.WriteLine("{0}", str);
        }

        public IComponentProperty Deserialize(string value)
        {
            var valuesStartIndex = value.IndexOf(':') + 1;
            var strValues = value.Substring(valuesStartIndex);
            var values = strValues.Split(',', ':');
            List<System.DateTime> valuesConv = new List<System.DateTime>();
            foreach (var strval in values)
            {
                valuesConv.Add(System.DateTime.Parse(strval));
            }
            Value = valuesConv;
            return this;
        }

        public IList<System.DateTime> Value { get; set; }
    }
}
