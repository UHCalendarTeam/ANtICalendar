using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICalendar.ComponentProperties.DateTime
{
    public abstract class DateTimeProperty: IComponentProperty, ISerialize
    {
        public abstract string Name { get; }
        public abstract void Serialize();
        public abstract IComponentProperty Deserialize();

        public abstract System.DateTime Value { get; }

    }
}
