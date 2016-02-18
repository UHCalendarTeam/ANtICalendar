using System;
using System.Collections.Generic;
using System.IO;
using ICalendar.GeneralInterfaces;

namespace ICalendar.ComponentProperties
{
    /// <summary>
    /// Abstract Class That Cluster DateTime Functionalities
    /// </summary>
    public abstract class DateTimeProperty : IComponentProperty, IValue<DateTime>
    {
        public abstract string Name { get; }
        public IList<IPropertyParameter> PropertyParameters { get; set; }

        public abstract void Serialize(TextWriter writer);


        public abstract IComponentProperty Deserialize(string value);

        public abstract DateTime Value { get; set; }

    }
}
