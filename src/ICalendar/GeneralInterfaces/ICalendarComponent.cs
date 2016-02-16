using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICalendar.ComponentProperties;
using ICalendar.GeneralInterfaces;

namespace ICalendar.GeneralInterfaces
{
    public interface ICalendarComponent:ISerialize
    {
        IList<IComponentProperty> Properties { get; set; }

        string Name { get; }
    }
}
