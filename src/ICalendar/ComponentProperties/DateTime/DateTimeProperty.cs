using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICalendar.ComponentProperties.DateTime
{
    /// <summary>
    /// Abstract Class That Cluster DateTime Functionalities
    /// </summary>
    public abstract class DateTimeProperty: IComponentProperty, ISerialize
    {
        public abstract string Name { get; }
        public abstract void Serialize();
        public abstract IComponentProperty Deserialize();

        public abstract System.DateTime Value { get; }

    }
}
