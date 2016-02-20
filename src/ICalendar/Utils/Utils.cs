using System;
/*using System.CodeDom;*/
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using ICalendar.Calendar;
using ICalendar.ComponentProperties;
using ICalendar.GeneralInterfaces;

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
        public static StringBuilder StringRepresentation<T>(this ComponentProperty<T> property, StringBuilder strBuilder)
        {
            strBuilder.Append(property.Name);

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

            return strBuilder.SplitLines();
        }

        public static string StringRepresentation(this VCalendar calendar, StringBuilder strBuilder)
        {
            throw new NotImplementedException();
        }

        public static StringBuilder  StringRepresentation(this ICalendarComponent component, StringBuilder strBuilder)
        {
            strBuilder.AppendLine("BEGIN:" + component.Name);

            return strBuilder;

        }


        #region Deserialize extension methods.
        public static ComponentProperty<string> Deserialize(this ComponentProperty<string> property, string value, IList<IPropertyParameter> parameters)
        {
            property.PropertyParameters = parameters;
            property.Value = value.ValuesSubString();
            return property;
        }

        public static ComponentProperty<StatusValues.Values> Deserialize(this ComponentProperty<StatusValues.Values> property, string value, IList<IPropertyParameter> parameters)
        {
            property.PropertyParameters = parameters;
            property.Value = StatusValues.ConvertValue(value.ValuesSubString().RemoveSpaces()); ;
            return property;
        }

        public static ComponentProperty<IList<string>> Deserialize(this ComponentProperty<IList<string>> property, string value, IList<IPropertyParameter> parameters)
        {
            property.PropertyParameters = parameters;
            property.Value = value.ValuesList();
            return property;
        }

        public static ComponentProperty<int> Deserialize(this ComponentProperty<int> property, string value, IList<IPropertyParameter> parameters)
        {
            property.PropertyParameters = parameters;
            try
            {
                property.Value = int.Parse(value.ValuesSubString().RemoveSpaces());
            }
            catch (ArgumentException e)
            {

                throw e;
            }
            return property;
        }

        public static ComponentProperty<ClassificationValues.ClassificationValue> Deserialize(this ComponentProperty<ClassificationValues.ClassificationValue> property, string value, IList<IPropertyParameter> parameters)
        {
            property.PropertyParameters = parameters;
            property.Value = ClassificationValues.ConvertValue(value);
            return property;
        }

        public static ComponentProperty<System.DateTime> Deserialize(this ComponentProperty<DateTime> property, string value, IList<IPropertyParameter> parameters)
        {
            property.PropertyParameters = parameters;
            property.Value = value.ToDateTime();
            return property;
        }

        public static ComponentProperty<TransparencyValues.TransparencyValue> Deserialize(this ComponentProperty<TransparencyValues.TransparencyValue> property, string value, IList<IPropertyParameter> parameters)
        {
            property.PropertyParameters = parameters;
            property.Value = TransparencyValues.ContertValue(value);
            return property;
        }

        public static ComponentProperty<ActionValues.ActionValue> Deserialize(this ComponentProperty<ActionValues.ActionValue> property, string value, IList<IPropertyParameter> parameters)
        {
            property.PropertyParameters = parameters;
            property.Value = ActionValues.ParseValue(value);
            return property;
        }

        public static ComponentProperty<IList<DateTime>> Deserialize(this ComponentProperty<IList<DateTime>> property, string value, IList<IPropertyParameter> parameters)
        {
            property.PropertyParameters = parameters;
            var valList = ValuesList(value);
            foreach (var val in valList)
            {
                property.Value.Add(val.ToDateTime());
            }

            return property;
        }
        #endregion




    }
}
