using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace CECRunningChart.Common
{
    public class StringValueAttribute : Attribute
    {
        private string stringValue;

        public StringValueAttribute(string value)
        {
            stringValue = value;
        }

        public string Value
        {
            get { return stringValue; }
        }
    }

    public static class StringEnum
    {
        public static string GetEnumStringValue(Enum enumValue)
        {
            Type type = enumValue.GetType();
            FieldInfo info = type.GetField(enumValue.ToString());
            var attributes = info.GetCustomAttributes(typeof(StringValueAttribute), false) as StringValueAttribute[];
            if (attributes.Length > 0)
            {
                return attributes[0].Value;
            }

            return null;
        }
    }
}
