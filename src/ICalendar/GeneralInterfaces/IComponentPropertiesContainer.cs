using System.Collections.Generic;

namespace ICalendar.GeneralInterfaces
{
    /// <summary>
    ///     Define the container of the properties of
    ///     a calendar component;
    /// </summary>
    public interface IComponentPropertiesContainer
    {
        /// <summary>
        ///     Contains the name and the value of the ICalendarComponent's properties.
        /// </summary>
        IDictionary<string, IComponentProperty> Properties { get; }
    }
}