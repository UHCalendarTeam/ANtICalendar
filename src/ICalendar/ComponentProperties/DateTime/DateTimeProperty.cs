using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ICalendar.ComponentProperties.DateTime
{
    /// <summary>
    /// Abstract Class That Cluster DateTime Functionalities
    /// </summary>
    public abstract class DateTimeProperty : IComponentProperty<System.DateTime>
    {
        public abstract string Name { get; }
        public IEnumerable<IPropertyParameter> PropertyParameters { get; set; }

        public abstract void Serialize(TextWriter writer);


        public abstract IComponentProperty<System.DateTime> Deserialize(string value);

        public abstract System.DateTime Value { get; set; }

    }
}
