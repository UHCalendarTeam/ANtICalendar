using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICalendar.CalendarComponents;

namespace ICalendar.GeneralInterfaces
{
    public interface IAlarmContainer
    {
         List<VAlarm> Alarms { get; set; }
    }
}
