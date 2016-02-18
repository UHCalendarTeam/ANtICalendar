﻿using System;
using System.Collections.Generic;
using System.IO;
using ICalendar.GeneralInterfaces;
using ICalendar.Utils;

namespace ICalendar.ComponentProperties
{
    /// <summary>
    /// Calendar Components: VALARM;
    /// Value Type: INTEGER;
    /// Properties Parameters: iana, non-standard
    /// </summary>
    public class RepeatCount : IComponentProperty, IValue<int>
    {

        public string Name => "REPEAT";
        public IList<IPropertyParameter> PropertyParameters { get; set; }

        public void Serialize(TextWriter writer)
        {
            writer.WriteLine(this.StringRepresentation());
        }

        public IComponentProperty Deserialize(string value)
        {
            try
            {
                Value = int.Parse(value.ValuesSubString().RemoveSpaces());
            }
            catch (ArgumentException e)
            {

                throw e;
            }
            return this;
        }

        public int Value { get; set; }

    }
}
