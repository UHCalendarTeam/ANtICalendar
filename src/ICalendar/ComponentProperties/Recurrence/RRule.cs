using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICalendar.GeneralInterfaces;
using ICalendar.ValueTypes;

namespace ICalendar.ComponentProperties
{
    /// <summary>
    /// Calendar Components: VEVENT, VTODO, VJOURNAL -- STANDARD, DAYLIGHT subcomponents;
    /// Value Type: RECUR;
    /// Properties Parameters: iana, non-standard
    /// </summary>
    public class Rrule : ComponentProperty<Recur>
    {
        public override string Name => "RRULE";
    }
}
