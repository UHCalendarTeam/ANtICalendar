using System;
using System.Collections.Generic;
using ICalendar.GeneralInterfaces;
using ICalendar.PropertyParameters;
using ICalendar.Utils;

namespace ICalendar.ComponentProperties
{
    public class ComponentProperty<T>:IComponentProperty, IValue<T>, IDeserialize
    {
        public ComponentProperty()
        {
            PropertyParameters = new List<PropertyParameter>();
        }
        public virtual string Name { get; }

        public List<PropertyParameter> PropertyParameters { get; set; }
        

        public virtual IComponentProperty Deserialize(string value, List<PropertyParameter> parameters)
        {
            PropertyParameters = parameters;
            if (this is IValue<string>)
            {
                return (this as IValue<string>).Deserialize(value, parameters);
            }
            else if (this is IValue<int>)
            {
                return (this as IValue<int>).Deserialize(value, parameters);
            }
            else if (this is IValue<DateTime>)
            {
                return (this as IValue<DateTime>).Deserialize(value, parameters);
            }
            else if (this is IValue<StatusValues.Values>)
            {
                return (this as IValue<StatusValues.Values>).Deserialize(value, parameters);
            }
            if (this is IValue<ClassificationValues.ClassificationValue>)
            {
                return (this as IValue<ClassificationValues.ClassificationValue>).Deserialize(value, parameters);
            }
            if (this is IValue<TransparencyValues.TransparencyValue>)
            {
                return (this as IValue<TransparencyValues.TransparencyValue>).Deserialize(value, parameters);
            }
            throw new ArgumentException("Don't implemented argument.");
        }

        public T Value { get; set; }

        
       
    }
    
}
