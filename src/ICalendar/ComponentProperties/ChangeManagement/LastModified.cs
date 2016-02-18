using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ICalendar.GeneralInterfaces;

namespace ICalendar.ComponentProperties
{
    /// <summary>
    /// Calendar Components: VEVENT, VTODO, VJOURNAL, VTIMEZONE;
    /// Value Type: DATETIME;
    /// Properties Parameters: iana, non-standard
    /// </summary>
    public class LastModified : ComponentProperty<System.DateTime>
    {
        public override string Name => "LAST-MODIFIED";
    }
}
