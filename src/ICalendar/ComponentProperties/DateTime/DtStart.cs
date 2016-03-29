using System;

namespace ICalendar.ComponentProperties
{
    /// <summary>
    /// Calendar Components: VTODO, VEVENT, VFREBUSY -- STANDARD, DAYLIGHT subcomponents;
    /// Value Type: DATETIME/DATE;
    /// Properties Parameters: iana, non-standard, value data type, time zone identifier
    /// </summary>
    public class Dtstart : ComponentProperty<DateTime>
    {
        public override string Name => "DTSTART";
    }
}