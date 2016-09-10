using ICalendar.GeneralInterfaces;
using System.Collections.Generic;

namespace ICalendar.CalendarComponents
{
    public class VTodo : CalendarComponent, ICalendarComponentsContainer
    {
        public VTodo()
        {
            CalendarComponents = new Dictionary<string, List<ICalendarComponent>>();
        }

        public override string Name => "VTODO";
        public Dictionary<string, List<ICalendarComponent>> CalendarComponents { get; }

        /// <summary>
        /// If component is VAlarm type the add it to Alarms
        /// if not is a property and call the base
        /// </summary>
        /// <param name="component"></param>
        public override void AddItem(ICalendarObject component)
        {
            var item = component as ICalendarComponent;
            if (item != null)
                if (CalendarComponents.ContainsKey(component.Name))
                    CalendarComponents[component.Name].Add(item);
                else
                    CalendarComponents.Add(item.Name, new List<ICalendarComponent>() { item });
            else
                base.AddItem(component);
        }
    }
}