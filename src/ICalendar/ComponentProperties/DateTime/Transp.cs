using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICalendar.GeneralInterfaces;

namespace ICalendar.ComponentProperties
{
    /// <summary>
    /// Calendar Components: VEVENT;
    /// Value Type: TEXT;
    /// Properties Parameters: iana, non-standard
    /// </summary>
    public class Transp : ComponentProperty<TransparencyValues.TransparencyValue>
    {
        public override string Name => "TRANSP";
    }

    /// <summary>
    /// Enclose the necessary for the TimeTransparensy Values.
    /// </summary>
    public  class TransparencyValues
    {
        public enum TransparencyValue
        {
            TRANSPARENT, OPAQUE
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Return a TrasparencyValue.Values 
        /// depending of the given string</returns>
        public static TransparencyValue ContertValue(string value)
        {
            switch (value)
            {
                case "OPAQUE":
                    return TransparencyValue.OPAQUE;
                case "TRANSPARENT":
                    return TransparencyValue.TRANSPARENT;
                default:
                    return TransparencyValue.TRANSPARENT;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Returns the string representation of the Transperancy values</returns>
        public static string ToString(TransparencyValue value)
        {
            switch (value)
            {
                case TransparencyValue.OPAQUE:
                    return "OPAQUE";
                default:
                    return "TRANSPARENT";
            }
        }
    }
}
