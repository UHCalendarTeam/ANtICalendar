namespace ICalendar.ComponentProperties
{
    /// <summary>
    /// Purpose: This property defines a Uniform Resource Locator (URL)
    ///associated with the iCalendar object.
    ///Conformance: This property can be specified once in the "VEVENT",
    ///"VTODO", "VJOURNAL", or "VFREEBUSY" calendar components.
    /// </summary>
    public class Url : ComponentProperty<string>
    {
        public override string Name => "URL";
    }
}