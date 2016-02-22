﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICalendar.GeneralInterfaces
{
    public interface ICalendarComponentsContainer
    {
         IList<ICalendarComponent> CalendarComponents { get; set; }
    }
}
