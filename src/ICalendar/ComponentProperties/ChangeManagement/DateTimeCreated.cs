using System;

namespace ICalendar.ComponentProperties
{
    /// <summary>
    /// Calendar Components: VEVENT, VTODO, VJOURNAL;
    /// Value Type: DATETIME;
    /// Properties Parameters: iana, non-standard
    /// </summary>
    public class DateTimeCreated : ComponentProperty<DateTime>
    {

        public override string Name => "CREATED";

    }
}
