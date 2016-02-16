using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ICalendar.GeneralInterfaces;

namespace ICalendar.ComponentProperties
{
    /// <summary>
    /// Abstract Class That Cluster DateTime Functionalities
    /// </summary>
    public abstract class DateTimeProperty : IComponentProperty
    {
        public abstract string Name { get; }
        public IList<IPropertyParameter> PropertyParameters { get; set; }

        public abstract void Serialize(TextWriter writer);


        public abstract IComponentProperty Deserialize(string value);

        public abstract System.DateTime Value { get; set; }

    }
}
