using System.Collections.Generic;
using ICalendar.ComponentProperties;
using ICalendar.GeneralInterfaces;
using static ICalendar.Utils.Utils;

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
