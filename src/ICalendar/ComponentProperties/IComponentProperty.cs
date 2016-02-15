using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICalendar.GeneralInterfaces;

namespace ICalendar.ComponentProperties
{
    public interface IComponentProperty:ISerialize
    {
        string Name { get; }
       

        IEnumerable<IPropertyParameter> PropertyParameters { get; set; }
    }
}
