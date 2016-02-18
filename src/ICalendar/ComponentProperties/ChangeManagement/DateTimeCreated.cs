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
    public class DateTimeCreated : ComponentProperty<System.DateTime>
    {

        public override string Name => "CREATED";

    }
}
