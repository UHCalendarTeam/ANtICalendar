using System.Collections.Generic;
using System.IO;
using ICalendar.GeneralInterfaces;
using ICalendar.Utils;

namespace ICalendar.ComponentProperties
{
    public class ComponentProperty<T>:IComponentProperty, IValue<T>
    {
        public ComponentProperty()
        {
            PropertyParameters = new List<IPropertyParameter>();
        }
        public virtual string Name { get; }

        public IList<IPropertyParameter> PropertyParameters { get; set; }

        public T Value { get; set; }

        public virtual void Serialize(TextWriter writer)
        {
           writer.Write(this.StringRepresentation());
        }
    }
    
}
