using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICalendar.GeneralInterfaces;

namespace ICalendar.GeneralInterfaces
{
    public interface IComponentProperty
    {
        string Name { get; }
       

        IList<IPropertyParameter> PropertyParameters { get; set; }
    }
}
