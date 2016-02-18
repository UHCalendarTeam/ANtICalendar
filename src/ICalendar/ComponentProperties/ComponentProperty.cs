using System.Collections.Generic;
using ICalendar.GeneralInterfaces;

namespace ICalendar.ComponentProperties
{
    public class ComponentProperty<T>:IComponentProperty, IValue<T>
    {
        public virtual string Name { get; }

        public IList<IPropertyParameter> PropertyParameters { get; set; }

        public T Value { get; set; }
    }
}
