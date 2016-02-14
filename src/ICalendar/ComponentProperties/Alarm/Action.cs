using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ICalendar.ComponentProperties.Alarm.Action.ActionValue;


namespace ICalendar.ComponentProperties.Alarm
{
    /// <summary>
    /// Calendar Components: VALARM;
    /// Value Type: TEXT;
    /// Properties Parameters: iana, non-standard
    /// </summary>
    public class Action : IComponentProperty<Action.ActionValue>
    {
        public enum ActionValue
        {
            AUDIO, DISPLAY, EMAIL
        }

        public string Name => "ACTION";
        public IEnumerable<IPropertyParameter> PropertyParameters { get; set; }

        public void Serialize(TextWriter writer)
        {
            StringBuilder str = new StringBuilder("ACTION:");
            str.Append(Value);
            writer.WriteLine("{0}", str);
        }

        public IComponentProperty<ActionValue> Deserialize(string value)
        {
            var valueStartIndex = value.IndexOf(':') + 1;
            var strValue = value.Substring(valueStartIndex);
            switch (strValue)
            {
                case "AUDIO":
                    Value = AUDIO;
                    break;
                case "DISPLAY":
                    Value = DISPLAY;
                    break;
                case "EMAIL":
                    Value = EMAIL;
                    break;
                default:
                    Value = DISPLAY;
                    break;

            }


            return this;
        }

        public ActionValue Value { get; set; }
    }
}
