using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICalendar.ComponentProperties;
using ICalendar.GeneralInterfaces;

namespace ICalendar.Utils
{
    public static class Utils
    {
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
        public static string SplitLines(this StringBuilder str)
        {
            
            for (int i = 1; i <= str.Length/75; i++)
            {
                str.Insert(75*i, "\r\n");
            }
            return str.Append("\r\n").ToString();
        }

        /// <summary>
        /// Call this the method when u want the representation in string of the 
        /// COmponents properties classes
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public static string stringRepresentation(this IComponentProperty property)
        {
            var strBuilder = new StringBuilder(property.Name).Append(':');
            if (property is IValue<string>)
            {
                strBuilder.Append(((IValue<string>) property).Value);
            }
            else if (property is IValue<IList<string>> )
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
            else if (property is IValue<ClassificationValues.Values>)
            {
                strBuilder.Append(ClassificationValues.ToString(((IValue<ClassificationValues.Values>) property).Value));
            }
            else if (property is IValue<int>)
            {
                strBuilder.Append(((IValue<int>) property).Value.ToString());
            }
            else if (property is IValue<StatusValues.Values>)
                strBuilder.Append(StatusValues.ToString(((IValue<StatusValues.Values>) property).Value));
            else if (property is IValue<string>)
            {
                
            }
           
            return strBuilder.SplitLines();
        }
    }
}
