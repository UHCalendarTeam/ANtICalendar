using System;

namespace ICalendar.ComponentProperties
{
    /// <summary>
    /// Calendar Components: VTODO;
    /// Value Type: DATETIME/DATE;
    /// Properties Parameters: iana, non-standard, value data type, time zone identifier
    /// </summary>
    public class Due : ComponentProperty<DateTime>
    {
        public override string Name => "DUE";
    }
}