using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ICalendar.GeneralInterfaces;

namespace ICalendar.CalendarComponents
{
    public class CalendarComponent:ICalendarComponent
    {
        public CalendarComponent()
        {
            Properties = new List<IComponentProperty>();
        }

        public void Serialize(TextWriter writer)
        {
            throw new NotImplementedException();
        }

        public IComponentProperty Deserialize(string value)
        {
            throw new NotImplementedException();
        }

        public IList<IComponentProperty> Properties { get; set; }
        public virtual string Name { get; }


        public void AddItem(object component)
        {
            
            Properties.Add((IComponentProperty)component);
        }
    }
}
