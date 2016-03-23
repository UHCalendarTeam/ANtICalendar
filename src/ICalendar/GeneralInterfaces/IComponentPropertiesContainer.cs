using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICalendar.GeneralInterfaces
{
    public interface IComponentPropertiesContainer
    {
        /// <summary>
        /// Contains the name and the value of the ICalendarComponent's properties.
        /// </summary>
        IDictionary<string, IComponentProperty> Properties { get;  }
    }
}
