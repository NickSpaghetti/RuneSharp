using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace RuneSharp.Helpers.EnumHelpers
{
    public static class StringToEnumHelper
    {
        public static T ToEnum<T>(this string value)
        {
            if(IsStringAnEnum<T>(value))
            {

            }
            return (T)Enum.Parse(typeof(T), value,true);
        }

        public static T ToEnumWithSpaces<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value.Replace(" ",string.Empty),true);
        }

        public static T ToEnumNonNumerics<T>(this string value)
        {
            string letters = new string(value.Where(c => char.IsLetter(c)).ToArray());
            return (T)Enum.Parse(typeof(T), letters,true);
        }


        private static Array GetEnumValues<T>()
        {
            Type enumType = typeof(T);
            return Enum.GetValues(enumType);
        }
        private static bool IsStringAnEnum<T>(string testEnum)
        {
            bool isEnumValue = false;
            foreach (var value in GetEnumValues<T>())
            {
                if (testEnum == Enum.GetName(typeof(T), value))
                {
                    isEnumValue = true;
                }
            }
            return isEnumValue;
        }
    }
}
