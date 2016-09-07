namespace ICalendar.ComponentProperties
{
    /// <summary>
    /// --Purpose: This property provides a more complete description of the
    ///calendar component than that provided by the "SUMMARY" property.
    /// ---Conformance: The property can be specified in the "VEVENT", "VTODO",
    ///"VJOURNAL", or "VALARM" calendar components.The property can be
    ///specified multiple times only within a "VJOURNAL" calendar
    ///component.
    /// </summary>
    public class Description : ComponentProperty<string>
    {
        public override string Name => "DESCRIPTION";
    }
}