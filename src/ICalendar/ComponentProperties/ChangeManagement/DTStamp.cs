using System;

namespace ICalendar.ComponentProperties
{
    /// <summary>
    /// Calendar Components: VEVENT, VTODO, VJOURNAL, VFREEBUSY (MUST BE INCLUDED IN ALL);
    /// Value Type: DATETIME;
    /// Properties Parameters: iana, non-standard
    /// </summary>
    public class Dtstamp : ComponentProperty<DateTime>
    {
        public override string Name => "DTSTAMP";
    }
}