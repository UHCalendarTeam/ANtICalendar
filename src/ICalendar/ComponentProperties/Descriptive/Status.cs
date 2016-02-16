using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICalendar.GeneralInterfaces;
using ICalendar.Utils;

namespace ICalendar.ComponentProperties
{
    /// <summary>
    /// Purpose: This property defines the overall status or confirmation
    ///for the calendar component.
    /// Conformance: This property can be specified once in "VEVENT",
    ///"VTODO", or "VJOURNAL" calendar components.
    /// </summary>
    public class Status:IComponentProperty,IValue<StatusValues.Values>, ISerialize
    {
        public string Name => "STATUS";
        public IList<IPropertyParameter> PropertyParameters { get; set; }
        public StatusValues.Values Value { get;  set; }
        public void Serialize(TextWriter writer)
        {
            writer.WriteLine(this.stringRepresentation());
        }

        public IComponentProperty Deserialize(string value)
        {
            Value = StatusValues.ConvertValue(value.ValuesSubString().RemoveSpaces());
            return this;
        }

       
    }


    public class StatusValues
    {
        public enum Values
        {
            Tentative,//Indicates event is tentative.
            Confirmed,//Indicates event is confirmed
            Cancelled,//Indicates event or to-do was cancelled,
            NeedsAction,// Indicates to-do needs action.
            Completed,// Indicates to-do completed.
            InProcess,//;Indicates to-do in process of.
            Unknown
        }

        public Values Value { get; private set; }

        public static Values ConvertValue(string str)
        {
            switch (str)
            {
                case "TENTATIVE":
                    return Values.Tentative;
                case "CONFIRMED":
                    return Values.Confirmed;
                case "CANCELLED":
                    return Values.Cancelled;
                case "NEEDS-ACTION":
                    return Values.NeedsAction;
                case "COMPLETED":
                    return Values.Completed;
                case "IN-PROCESS":
                    return Values.Completed;
                default:
                    return Values.Unknown;
            }
        }

        public static string ToString(Values value)
        {
            switch (value)
            {
                case Values.Tentative:
                    return "TENTATIVE";
                case Values.Cancelled:
                    return "CANCELLED";
                case Values.Completed:
                    return "COMPLETED";
                case Values.Confirmed:
                    return "CONFIRMED";
                case Values.InProcess:
                    return "IN-PROCESS";
                case Values.NeedsAction:
                    return "NEED-ACTION";
                default:
                    return "UNKNOWN";
            }
        }
    }
}
