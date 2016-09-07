using ICalendar.ValueTypes;

namespace ICalendar.ComponentProperties
{
    /// <summary>
    /// Calendar Components: VFREEBUSY;
    /// Value Type: PERIOD;
    /// Properties Parameters: iana, non-standard, free/busy time type
    /// </summary>
    public class Freebusy : ComponentProperty<Period>
    {
        public override string Name => "FREEBUSY";
    }
}