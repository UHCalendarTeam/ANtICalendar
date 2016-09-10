using System.Collections.Generic;

namespace ICalendar.GeneralInterfaces
{
    /// <summary>
    ///     Define the container of the properties in
    ///     a calendar component object.
    /// </summary>
    public interface IComponentPropertiesContainer
    {
        /// <summary>
        ///     Contains the name and the value of the ICalendarComponent's properties.
        /// </summary>
        Dictionary<string, IComponentProperty> Properties { get; }
    }
}