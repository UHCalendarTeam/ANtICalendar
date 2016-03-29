using System;
using System.Collections.Generic;
using System.IO;
using ICalendar.GeneralInterfaces;
using ICalendar.PropertyParameters;
using ICalendar.Utils;
using ICalendar.ValueTypes;

namespace ICalendar.ComponentProperties
{
    /// <summary>
    ///     Represent the iCalendar component properties.
    ///     Contains the name and the value of the property
    ///     with its .NET type.
    /// </summary>
    /// <typeparam name="T">The Type of the property</typeparam>
    public class ComponentProperty<T> : IComponentProperty, IValue<T>
    {
        public ComponentProperty()
        {
            PropertyParameters = new List<PropertyParameter>();
        }


        public virtual void Serialize(TextWriter writer)
        {
            writer.Write(this.StringRepresentation());
        }

        /// <summary>
        ///     Takes the value and the params of the property, build it and return it.
        /// </summary>
        /// <param name="value">The value of the property</param>
        /// <param name="parameters">THe params of the property</param>
        /// <returns>The IComponentProperty with the value and the params setted.</returns>
        public virtual IComponentProperty Deserialize(string value, List<PropertyParameter> parameters)
        {
            StringValue = value;
            PropertyParameters = parameters;
            if (this is IValue<string>)
            {
                return (this as IValue<string>).Deserialize(value, parameters);
            }
            if (this is IValue<int>)
            {
                return (this as IValue<int>).Deserialize(value, parameters);
            }
            if (this is IValue<DateTime>)
            {
                return (this as IValue<DateTime>).Deserialize(value, parameters);
            }
            if (this is IValue<IList<DateTime>>)
            {
                return (this as IValue<IList<DateTime>>).Deserialize(value, parameters);
            }
            if (this is IValue<StatusValues.Values>)
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
            if (this is IValue<ActionValues.ActionValue>)
            {
                return (this as IValue<ActionValues.ActionValue>).Deserialize(value, parameters);
            }
            if (this is IValue<IList<string>>)
            {
                return (this as IValue<IList<string>>).Deserialize(value, parameters);
            }
            if (this is IValue<DurationType>)
            {
                return (this as IValue<DurationType>).Deserialize(value, parameters);
            }
            if (this is IValue<Period>)
            {
                return (this as IValue<Period>).Deserialize(value, parameters);
            }
            if (this is IValue<TimeSpan>)
            {
                return (this as IValue<TimeSpan>).Deserialize(value, parameters);
            }
            if (this is IValue<Recur>)
            {
                return (this as IValue<Recur>).Deserialize(value, parameters);
            }
            throw new ArgumentException("Don't implemented argument.");
        }


        public override string ToString()
        {
            return this.StringRepresentation();
        }

        #region Properties

        public virtual string Name { get; set; }

        public List<PropertyParameter> PropertyParameters { get; set; }

        public string StringValue { get; set; }

        public T Value { get; set; }

        #endregion
    }
}