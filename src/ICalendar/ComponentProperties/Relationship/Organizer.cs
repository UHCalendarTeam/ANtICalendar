namespace ICalendar.ComponentProperties
{
    /// <summary>
    /// Purpose: This property defines the organizer for a calendar component.
    ///Value Type: CAL-ADDRESS
    /// Conformance: This property MUST be specified in an iCalendar object
    /// that specifies a group-scheduled calendar entity.This property
    ///MUST be specified in an iCalendar object that specifies the
    ///publication of a calendar user’s busy time.This property MUST
    ///NOT be specified in an iCalendar object that specifies only a time
    ///zone definition or that defines calendar components that are not
    ///group-scheduled components, but are components only on a single
    ///user’s calendar.
    /// </summary>
    public class Organizer : ComponentProperty<string>
    {
        public override string Name => "ORGANIZER";
    }
}