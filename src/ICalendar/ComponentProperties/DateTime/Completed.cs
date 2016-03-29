using System;

namespace ICalendar.ComponentProperties
{
    /// <summary>
    /// Calendar Components: VTODO;
    /// Value Type: UTC;
    /// Properties Parameters: iana, non-standard
    /// </summary>
    public class Completed : ComponentProperty<DateTime>
    {
        public override string Name => "COMPLETED";
    }
}