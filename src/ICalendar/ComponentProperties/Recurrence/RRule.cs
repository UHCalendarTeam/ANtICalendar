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
    /// Calendar Components: VEVENT, VTODO, VJOURNAL -- STANDARD, DAYLIGHT subcomponents;
    /// Value Type: RECUR;
    /// Properties Parameters: iana, non-standard
    /// </summary>
    public class Rrule : ComponentProperty<int>
    {

        public override string Name => "RRULE";
    }
}
