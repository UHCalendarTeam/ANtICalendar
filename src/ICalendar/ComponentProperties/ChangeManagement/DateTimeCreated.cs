using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ICalendar.GeneralInterfaces;
using ICalendar.Utils;

namespace ICalendar.ComponentProperties
{
    /// <summary>
    /// Calendar Components: VEVENT, VTODO, VJOURNAL;
    /// Value Type: DATETIME;
    /// Properties Parameters: iana, non-standard
    /// </summary>
    public class DateTimeCreated : IComponentProperty, IValue<DateTime>
    {

        public string Name => "CREATED";
        public IList<IPropertyParameter> PropertyParameters { get; set; }


        public void Serialize(TextWriter writer)
        {
            writer.WriteLine(this.StringRepresentation());
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
