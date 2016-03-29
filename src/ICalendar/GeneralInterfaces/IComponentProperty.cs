using System.Collections.Generic;
using ICalendar.PropertyParameters;

namespace ICalendar.GeneralInterfaces
{
    /// <summary>
    ///     Contains the definition for the CalendarProperty object.
    ///     IComponentProperty represent the iCalendar properties
    ///     contained in the calendar components.
    /// </summary>
    public interface IComponentProperty : ISerialize, IDeserialize, ICalendarObject
    {
        /// <summary>
        ///     Contains the params of the property.
        /// </summary>
        List<PropertyParameter> PropertyParameters { get; set; }

        /// <summary>
        ///     Contains the string representation of the
        ///     property's value. May be useful for the
        ///     text-match filter of the REPORT method of CalDAV.
        /// </summary>
        string StringValue { get; set; }

      
    }
}