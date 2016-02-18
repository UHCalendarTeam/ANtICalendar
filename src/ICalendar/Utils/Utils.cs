﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
        public static string SplitLines(this StringBuilder str)
        {
            
            for (int i = 1; i <= str.Length/75; i++)
            {
                str.Insert(75*i, "\r\n");
            }
            return str.Append("\r\n").ToString();
        }

        #endregion

        /// <summary>
        /// Call this the method when u want the representation in string of the 
        /// COmponents properties classes
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public static string StringRepresentation<T>(this ComponentProperty<T> property)
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
            else if (property is IValue<ClassificationValues.ClassificationValue>)
            {
                strBuilder.Append(ClassificationValues.ToString(((IValue<ClassificationValues.ClassificationValue>) property).Value));
            }
            else if (property is IValue<int>)
            {
                strBuilder.Append(((IValue<int>) property).Value.ToString());
            }
            else if (property is IValue<StatusValues.Values>)
                strBuilder.Append(StatusValues.ToString(((IValue<StatusValues.Values>) property).Value));
            else if (property is IValue<TransparencyValues.TransparencyValue>)
            {
                strBuilder.Append(TransparencyValues.ToString(((IValue<TransparencyValues.TransparencyValue>)property).Value));
            }
            else if (property is IValue<System.DateTime>)
            {
                //TODO: Nacho aqui escribes como se representa un datetime a string
                //despus le haces strBuilder.Append(#aqui el string del datetime#);
            }
            else if (property is ComponentProperty<ActionValues.ActionValue>)
            {
                strBuilder.Append(ActionValues.ToString(((IValue<ActionValues.ActionValue>)property).Value));
            }
           
            return strBuilder.SplitLines();
        }

        #region Deserialize extension methods.
        public static ComponentProperty<string> Deserialize(this ComponentProperty<string> property, string value)
        {
            property.Value = value.ValuesSubString();
            return property;
        }

        public static ComponentProperty<StatusValues.Values> Deserialize(this ComponentProperty<StatusValues.Values> property, string value)
        {
            property.Value = StatusValues.ConvertValue(value.ValuesSubString().RemoveSpaces()); ;
            return property;
        }
        
         public static ComponentProperty<IList<string>> Deserialize(this ComponentProperty<IList<string>> property, string value)
        {
            property.Value = value.ValuesList();
            return property;
        }

        public static ComponentProperty<int> Deserialize(this ComponentProperty<int> property, string value)
        {
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

        public static ComponentProperty<ClassificationValues.ClassificationValue> Deserialize(this ComponentProperty<ClassificationValues.ClassificationValue> property, string value)
        {
            property.Value = ClassificationValues.ConvertValue(value);
            return property;
        }

        public static ComponentProperty<System.DateTime> Deserialize(this ComponentProperty<System.DateTime> property, string value)
        {
            property.Value = System.DateTime.Parse(value);
            return property;
        }

        public static ComponentProperty<TransparencyValues.TransparencyValue> Deserialize(this ComponentProperty<TransparencyValues.TransparencyValue> property, string value)
        {
            property.Value = TransparencyValues.ContertValue(value);
            return property;
        }

        public static ComponentProperty<ActionValues.ActionValue> Serialize(this ComponentProperty<ActionValues.ActionValue> property, string value)
        {
            property.Value = ActionValues.ParseValue(value);
            return property;
        }

        //TODO: Nacho mira a ver si esto esta bien!
        public static ComponentProperty<IList<System.DateTime>> Deserialize(this ComponentProperty<IList<System.DateTime>> property, string value)
        {
            var valuesStartIndex = value.IndexOf(':') + 1;
            var strValues = value.Substring(valuesStartIndex);
            var values = strValues.Split(',', ':');
            List<System.DateTime> valuesConv = new List<System.DateTime>();
            foreach (var strval in values)
            {
                valuesConv.Add(System.DateTime.Parse(strval));
            }
            property.Value = valuesConv;
            return property;
        }
        #endregion
    }
}