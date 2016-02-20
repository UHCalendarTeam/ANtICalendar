﻿using System;
/*using System.CodeDom;*/
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using ICalendar.Calendar;
using ICalendar.ComponentProperties;
using ICalendar.GeneralInterfaces;
using ICalendar.PropertyParameters;

namespace ICalendar.Utils
{
    public static class Utils
    {
        #region string extension methods.
        /// <summary>
        /// Get the index first ':'
        /// </summary>
        /// <param name="str"></param>
        /// <returns>Return the index of the beginning of the values declaration</returns>
        public static int IndexOfValues(this string str)
        {
            var valuesStartIndex = str.IndexOf(':') + 1;
            return valuesStartIndex;
        }

        /// <summary>
        /// Remove the white spaces and the CRLFs
        /// </summary>
        /// <param name="str"></param>
        /// <returns>
        /// Return the substring from where 
        /// the values of a component property start.
        /// </returns>
        public static string ValuesSubString(this string str)
        {
            return str.Substring(IndexOfValues(str)).Replace("\r\n", "");
        }

        /// <summary>
        /// Return a list with the values of a
        /// property component.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static IList<string> ValuesList(this string str)
        {
            return ValuesSubString(str).Split(',').ToList();
        }

        /// <summary>
        /// Remove the white spaces.
        /// </summary>
        /// <param name="str"></param>
        /// <returns>Return the string without white spaces</returns>
        public static string RemoveSpaces(this string str)
        {
            return str.Replace(" ", "");
        }

        /// <summary>
        /// Call this method after the creation of a Component Properties.
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <returns>Return the same string with with the lines brokens after 75 chars</returns>
        public static StringBuilder SplitLines(this StringBuilder str)
        {

            for (int i = 1; i <= str.Length / 75; i++)
            {
                str.Insert(75 * i, "\r\n");
            }
            return str.Append("\r\n");
        }

        /// <summary>
        /// Converts an string in a DateTime if possible, null otherwise.
        /// </summary>
        /// <param name="stringDate">String with date format to convert</param>
        /// <returns></returns>
        public static DateTime ToDateTime(this string stringDate)
        {
            if (string.IsNullOrEmpty(stringDate))
                return DateTime.MinValue;
            else
            {
                DateTimeKind kind;
                if (stringDate.Contains("Z"))
                {
                    kind = DateTimeKind.Utc;
                    stringDate = stringDate.Remove(stringDate.Length - 1);
                }

                else
                    //way may have to put this kind in the DateTimeProperty class i dont know if it holds
                    kind = DateTimeKind.Unspecified;

                bool hasTime = stringDate.Contains("T");

                DateTime resDateTime;
                if (hasTime)
                {
                    if (DateTime.TryParseExact(stringDate, "yyyyMMddTHHmmss", CultureInfo.CurrentCulture,
                        kind == DateTimeKind.Utc ? DateTimeStyles.AssumeUniversal : DateTimeStyles.None, out resDateTime))
                    {
                        return resDateTime;
                    }
                    else
                    {
                        return DateTime.MinValue;
                    }
                }
                else
                {
                    if (DateTime.TryParseExact(stringDate, "yyyyMMdd", CultureInfo.CurrentCulture,
                        kind == DateTimeKind.Utc ? DateTimeStyles.AssumeUniversal : DateTimeStyles.None, out resDateTime))
                    {
                        return resDateTime;
                    }
                    else
                    {
                        return DateTime.MinValue;
                    }

                }

            }
        }

        #endregion

        /// <summary>
        /// Call this the method when u want the representation in string of the 
        /// Components properties classes
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public static string StringRepresentation<T>(this ComponentProperty<T> property)
        {
            var strBuilder = new StringBuilder(property.Name);

            foreach (var proParam in property.PropertyParameters)
            {
                strBuilder.Append(";");
                strBuilder.Append(proParam.Name + "=" + proParam.Value);
            }

            strBuilder.Append(":");

            if (property is IValue<string>)
            {
                strBuilder.Append(((IValue<string>)property).Value);
            }
            else if (property is IValue<IList<string>>)
            {
                var flag = false;
                foreach (var cat in ((IValue<IList<string>>)property).Value)
                {
                    if (flag)
                        strBuilder.Append(',');
                    strBuilder.Append(cat);
                    flag = true;
                }
            }
            else if (property is IValue<ClassificationValues.ClassificationValue>)
            {
                strBuilder.Append(ClassificationValues.ToString(((IValue<ClassificationValues.ClassificationValue>)property).Value));
            }
            else if (property is IValue<int>)
            {
                strBuilder.Append(((IValue<int>)property).Value.ToString());
            }
            else if (property is IValue<StatusValues.Values>)
                strBuilder.Append(StatusValues.ToString(((IValue<StatusValues.Values>)property).Value));
            else if (property is IValue<TransparencyValues.TransparencyValue>)
            {
                strBuilder.Append(TransparencyValues.ToString(((IValue<TransparencyValues.TransparencyValue>)property).Value));
            }
            else if (property is IValue<DateTime>)
            {
                DateTime propValue = ((IValue<DateTime>)property).Value;
                strBuilder.Append(propValue.ToString("yyyyMMddTHHmmss") +
                                  (propValue.Kind == DateTimeKind.Utc ? "Z" : ""));
            }
            else if (property is ComponentProperty<ActionValues.ActionValue>)
            {
                strBuilder.Append(ActionValues.ToString(((IValue<ActionValues.ActionValue>)property).Value));
            }
            
            return strBuilder.SplitLines().ToString();
        }

        


        #region Deserialize extension methods.
        public static ComponentProperty<string> Deserialize(this IValue<string> property, string value, List<PropertyParameter> parameters)
        {
            ((ComponentProperty<string>)property).PropertyParameters = parameters;
            property.Value = value;
            return (ComponentProperty<string>)property;
        }

        public static ComponentProperty<StatusValues.Values> Deserialize(this IValue<StatusValues.Values> property, string value, List<PropertyParameter> parameters)
        {
            ((ComponentProperty<StatusValues.Values>)property).PropertyParameters = parameters;
            property.Value = StatusValues.ConvertValue(value.RemoveSpaces()); ;
            return ((ComponentProperty<StatusValues.Values>)property);
        }

        public  static ComponentProperty<IList<string>> Deserialize(this IValue<IList<string>> property, string value, List<PropertyParameter> parameters)
        {
            ((ComponentProperty<IList<string>>)property).PropertyParameters = parameters;
            property.Value = value.ValuesList();
            return (ComponentProperty<IList<string>>)property;
        }

        public static ComponentProperty<int> Deserialize(this IValue<int> property, string value, List<PropertyParameter> parameters)
        {
            ((ComponentProperty<int>)property).PropertyParameters = parameters;
            try
            {
                property.Value = int.Parse(value.RemoveSpaces());
            }
            catch (ArgumentException e)
            {

                throw e;
            }
            return (ComponentProperty<int>)property;
        }

        public static ComponentProperty<ClassificationValues.ClassificationValue> Deserialize(this IValue<ClassificationValues.ClassificationValue> property, string value, List<PropertyParameter> parameters)
        {
            ((ComponentProperty<DateTime>)property).PropertyParameters = parameters;
            property.Value = ClassificationValues.ConvertValue(value);
            return (ComponentProperty<ClassificationValues.ClassificationValue>)property;
        }

        public static ComponentProperty<System.DateTime> Deserialize(this IValue<DateTime> property, string value, List<PropertyParameter> parameters)
        {
            ((ComponentProperty<DateTime>)property).PropertyParameters = parameters;
            property.Value = value.ToDateTime();
            return (ComponentProperty<DateTime>)property;
        }

        public static ComponentProperty<TransparencyValues.TransparencyValue> Deserialize(this IValue<TransparencyValues.TransparencyValue> property, string value, List<PropertyParameter> parameters)
        {
            ((ComponentProperty<TransparencyValues.TransparencyValue>)property).PropertyParameters = parameters;
            property.Value = TransparencyValues.ContertValue(value);
            return (ComponentProperty<TransparencyValues.TransparencyValue>)property;
        }

        public static ComponentProperty<ActionValues.ActionValue> Deserialize(this IValue<ActionValues.ActionValue> property, string value, List<PropertyParameter> parameters)
        {
            ((ComponentProperty<ActionValues.ActionValue>)property).PropertyParameters = parameters;
            property.Value = ActionValues.ParseValue(value);
            return (ComponentProperty<ActionValues.ActionValue>)property;
        }

        public static ComponentProperty<IList<DateTime>> Deserialize(this IValue<IList<DateTime>> property, string value, List<PropertyParameter> parameters)
        {
            ((ComponentProperty<IList<DateTime>>)property).PropertyParameters = parameters;
            var valList = ValuesList(value);
            foreach (var val in valList)
            {
                property.Value.Add(val.ToDateTime());
            }

            return (ComponentProperty<IList<DateTime>>)property;
        }
        #endregion




    }
}
