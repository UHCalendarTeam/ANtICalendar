﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICalendar.GeneralInterfaces;
using ICalendar.PropertyParameters;

namespace ICalendar.GeneralInterfaces
{
    public interface IComponentProperty:ISerialize, ICalendarObject
    { 
        List<PropertyParameter> PropertyParameters { get; set; }

        /// <summary>
        /// Contain the string representation of the value
        /// </summary>
        string StringValue { get; set; }

       

    }
}
