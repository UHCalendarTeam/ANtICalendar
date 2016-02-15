using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICalendar.ComponentProperties
{
    public interface IComponentProperty<T>:ISerialize<T>
    {
        string Name { get; }

        T Value { get; set; }

        IEnumerable<IPropertyParameter> PropertyParameters { get; set; }
    }
}
