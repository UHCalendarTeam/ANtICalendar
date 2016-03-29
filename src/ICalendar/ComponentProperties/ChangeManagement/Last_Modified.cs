using System;

namespace ICalendar.ComponentProperties
{
    /// <summary>
    /// Calendar Components: VEVENT, VTODO, VJOURNAL, VTIMEZONE;
    /// Value Type: DATETIME;
    /// Properties Parameters: iana, non-standard
    /// </summary>
    public class Last_modified : ComponentProperty<DateTime>
    {
        public override string Name => "LAST-MODIFIED";
    }
}