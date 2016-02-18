﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ICalendar.GeneralInterfaces;

namespace ICalendar.ComponentProperties
{
    /// <summary>
    /// Calendar Components: VEVENT, VTODO, VJOURNAL -- STANDARD, DAYLIGHT subcomponents;
    /// Value Type: DATETIME/DATE;
    /// Properties Parameters: iana, non-standard, value data type, time zone identifier
    /// </summary>
    public class ExceptionDateTime : IComponentProperty, IValue<IList<DateTime>>
    {
        public string Name => "EXDATE";
        public IList<IPropertyParameter> PropertyParameters { get; set; }

        public void Serialize(TextWriter writer)
        {
            StringBuilder str = new StringBuilder("EXDATE:");
            var flag = false;
            foreach (var cat in Value)
            {
                if (flag)
                    str.Append(',');
                str.Append(cat);
                flag = true;
            }
            writer.WriteLine("{0}", str);
        }

        public IComponentProperty Deserialize(string value)
        {
            var valuesStartIndex = value.IndexOf(':') + 1;
            var strValues = value.Substring(valuesStartIndex);
            var values = strValues.Split(',', ':');
            List<DateTime> valuesConv = values.Select(DateTime.Parse).ToList();
            Value = valuesConv;
            return this;
        }

        public IList<DateTime> Value { get; set; }
    }
}
