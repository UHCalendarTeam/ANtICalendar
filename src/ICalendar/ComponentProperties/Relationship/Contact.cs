using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICalendar.ComponentProperties
{
    /// <summary>
    /// Purpose: This property is used to represent contact information or
    ///alternately a reference to contact information associated with the
    ///calendar component.
    ///Conformance: This property can be specified in a "VEVENT", "VTODO",
    ///"VJOURNAL", or "VFREEBUSY" calendar component.
    /// </summary>
    public class Contact : ComponentProperty<string>
    {
        public override string Name => "CONTACT";
    }
}
