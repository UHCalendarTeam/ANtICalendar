using ICalendar.CalendarComponents;
using System.Collections.Generic;

namespace ICalendar.GeneralInterfaces
{
    public interface IAlarmContainer
    {
        List<VAlarm> Alarms { get; set; }
    }
}