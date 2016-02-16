using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICalendar.GeneralInterfaces;



namespace ICalendar.ComponentProperties
{
    /// <summary>
    /// Calendar Components: VALARM;
    /// Value Type: TEXT;
    /// Properties Parameters: iana, non-standard
    /// </summary>
    public class Action : IComponentProperty, IValue<Action.ActionValue>
    {
        public enum ActionValue
        {
            AUDIO, DISPLAY, EMAIL
        }

        public string Name => "ACTION";
        public IList<IPropertyParameter> PropertyParameters { get; set; }

        public void Serialize(TextWriter writer)
        {
            StringBuilder str = new StringBuilder("ACTION:");
            str.Append(Value);
            writer.WriteLine("{0}", str);
        }

        public IComponentProperty Deserialize(string value)
        {
            var valueStartIndex = value.IndexOf(':') + 1;
            var strValue = value.Substring(valueStartIndex);
            switch (strValue)
            {
                case "AUDIO":
                    Value = ActionValue.AUDIO;
                    break;
                case "DISPLAY":
                    Value = ActionValue.DISPLAY;
                    break;
                case "EMAIL":
                    Value = ActionValue.EMAIL;
                    break;
                default:
                    Value = ActionValue.DISPLAY;
                    break;

            }


            return this;
        }

        public ActionValue Value { get; set; }
        
    }
}
