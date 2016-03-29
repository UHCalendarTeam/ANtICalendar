using ICalendar.ValueTypes;

namespace ICalendar.ComponentProperties
{
    /// <summary>
    /// Calendar Components: VTODO, VEVENT, VALARM;
    /// Value Type: DURATION;
    /// Properties Parameters: iana, non-standard
    /// </summary>
    public class Duration : ComponentProperty<DurationType>
    {
        public override string Name => "DURATION";
    }
}