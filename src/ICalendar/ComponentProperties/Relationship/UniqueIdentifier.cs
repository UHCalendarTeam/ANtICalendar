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
    /// Purpose: This property defines the persistent, globally unique
    ///identifier for the calendar component.
    /// Conformance: The property MUST be specified in the "VEVENT",
    ///"VTODO", "VJOURNAL", or "VFREEBUSY" calendar components.
    /// </summary>
    public class UniqueIdentifier:ComponentProperty<string>
    {
        public override string Name => "UID";

        /// <summary>
        /// Generete the UID for a CalendarComponent.
        /// This identifier is globally unique.
        /// </summary>
        public void Generate()
        {
            var str = new StringBuilder(DateTime.Now.ToString("yyyyMMddhhmmss")).
                Append(DateTime.Now.Millisecond).Append('@');
            
            //TODO: Add the right side( the domain of the current computer)
            Value = str.ToString();
        }
    }
}
