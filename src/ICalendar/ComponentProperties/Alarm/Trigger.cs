using System;
using System.Collections.Generic;
using System.IO;
using ICalendar.GeneralInterfaces;
using ICalendar.Utils;

namespace ICalendar.ComponentProperties
{
    /// <summary>
    /// Calendar Components: VALARM;
    /// Value Type: DURATION/DATETIME;
    /// Properties Parameters: iana, non-standard, value data type, time zone identifier, trigger relationship
    /// </summary>
    public class Trigger : ComponentProperty<DateTime>
    {
        public override string Name => "TRIGGER";
    }
}
