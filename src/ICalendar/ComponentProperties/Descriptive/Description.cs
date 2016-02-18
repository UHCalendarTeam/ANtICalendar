using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using ICalendar.ComponentProperties;
using ICalendar.GeneralInterfaces;
using static ICalendar.Utils.Utils;

namespace ICalendar.ComponentProperties
{
    /// <summary>
    /// --Purpose: This property provides a more complete description of the
    ///calendar component than that provided by the "SUMMARY" property.
    /// ---Conformance: The property can be specified in the "VEVENT", "VTODO",
    ///"VJOURNAL", or "VALARM" calendar components.The property can be
    ///specified multiple times only within a "VJOURNAL" calendar
    ///component.
    /// </summary>
    public class Description: IComponentProperty,  IValue<string>
    {
       
        public void Serialize(TextWriter writer)
        {
            writer.WriteLine(this.StringRepresentation());
        }

        public IComponentProperty Deserialize(string value)
        {
            Value = value.ValuesSubString();
            return this;
        }

        public string Name => "DESCRIPTION";
        public IList<IPropertyParameter> PropertyParameters { get; set; }
        public string Value { get; set; }
    }
}
