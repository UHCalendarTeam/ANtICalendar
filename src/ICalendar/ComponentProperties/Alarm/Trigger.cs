using ICalendar.ValueTypes;

namespace ICalendar.ComponentProperties
{
    /// <summary>
    /// Calendar Components: VALARM;
    /// Value Type: DURATION/DATETIME;
    /// Properties Parameters: iana, non-standard, value data type, time zone identifier, trigger relationship
    /// </summary>
    public class Trigger : ComponentProperty<DurationType>
    {
        public override string Name => "TRIGGER";
    }
}