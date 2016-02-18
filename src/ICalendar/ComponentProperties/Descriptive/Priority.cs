using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICalendar.GeneralInterfaces;
using static ICalendar.Utils.Utils;

namespace ICalendar.ComponentProperties
{
    /// <summary>
    /// Purpose: This property defines the relative priority for a calendar
    ///component.
    /// Conformance: This property can be specified in "VEVENT" and "VTODO"
    /// calendar components.
    /// </summary>
    public class Priority : ComponentProperty<int>
    {
        public override string Name => "PRIORITY";
    }
}
