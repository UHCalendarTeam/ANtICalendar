using System.Collections.Generic;

namespace ICalendar.ComponentProperties
{
    /// <summary>
    /// ---Purpose: This property defines the categories for a calendar
    ///component.
    /// ---Conformance: The property can be specified within "VEVENT", "VTODO",
    ///or "VJOURNAL" calendar components.
    ///
    ///
    /// </summary>
    /// ////
    public class Categories : ComponentProperty<IList<string>>
    {
        public override string Name => "CATEGORIES";
    }
}