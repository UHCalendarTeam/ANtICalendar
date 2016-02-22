using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICalendar.ComponentProperties;
using ICalendar.GeneralInterfaces;

namespace ICalendar.GeneralInterfaces
{
    /// <summary>
    /// The abstraction of the CalendarComponents implementations.
    /// </summary>
    public interface ICalendarComponent:ISerialize, IComponentPropertiesContainer
    {       

        string Name { get; }
    }
}
