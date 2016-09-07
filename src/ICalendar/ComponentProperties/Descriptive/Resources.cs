using System.Collections.Generic;

namespace ICalendar.ComponentProperties
{
    /// <summary>
    /// Purpose: This property defines the equipment or resources
    ///anticipated for an activity specified by a calendar component.
    /// Conformance: This property can be specified once in "VEVENT" or
    ///"VTODO" calendar component.
    /// </summary>
    public class Resources : ComponentProperty<IList<string>>
    {
        public override string Name => "RESOURCES";
    }
}