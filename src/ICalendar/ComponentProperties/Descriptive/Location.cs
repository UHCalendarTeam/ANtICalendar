using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICalendar.GeneralInterfaces;
using ICalendar.Utils;

namespace ICalendar.ComponentProperties
{
    /// <summary>
    /// Purpose: This property defines the intended venue for the activity
    /// defined by a calendar component.
    /// Conformance: This property can be specified in "VEVENT" or "VTODO"
    /// calendar component.
    /// </summary>
    public class Location: ComponentProperty<string>
    {
        public override string Name => "LOCATION";
    }
}
