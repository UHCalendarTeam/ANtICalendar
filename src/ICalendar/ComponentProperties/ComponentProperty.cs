﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ICalendar.GeneralInterfaces;
using ICalendar.Utils;

namespace ICalendar.ComponentProperties
{
    public class ComponentProperty<T>:IComponentProperty, IValue<T>
    {
       

        public virtual string Name { get; }
        public IList<IPropertyParameter> PropertyParameters { get; set; }
        public T Value { get; set; }
    }
}
