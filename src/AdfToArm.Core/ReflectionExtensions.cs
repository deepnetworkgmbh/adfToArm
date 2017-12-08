using System;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;

namespace AdfToArm.Core
{
    public static class ReflectionExtensions
    {
        public static string GetNodeName(this object nodeObject)
        {
            var nameProperty = nodeObject.GetType().GetProperty("Name");

            if (nameProperty != null)
                return nameProperty.GetValue(nodeObject).ToString();

            var jsonAttr = nodeObject.GetType().GetCustomAttributes(false).FirstOrDefault(i => i is JsonPropertyAttribute);

            var jsonName = jsonAttr != null
                ? ((JsonPropertyAttribute)jsonAttr).PropertyName
                : nodeObject.GetType().Name;

            return jsonName;
        }

        public static string GetJsonPropertyName(this MemberInfo property)
        {
            var jsonAttr = property.GetCustomAttributes(false).FirstOrDefault(i => i is JsonPropertyAttribute);

            var jsonName = jsonAttr != null
                ? (jsonAttr as JsonPropertyAttribute)?.PropertyName
                : property.GetType().Name;

            return jsonName;
        }

        public static bool IsSimple(this Type type)
        {
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                // nullable type, check if the nested type is simple.
                return IsSimple(type.GetGenericArguments()[0]);
            }

            return type.IsPrimitive
                   || type.IsEnum
                   || type == typeof(string)
                   || type == typeof(decimal)
                   || type == typeof(TimeSpan)
                   || type == typeof(DateTime);
        }

        public static object GetDefaultPropertyValue(this object prop, string type, bool removeBrackets)
        {
            switch (type)
            {
                case "string":
                    if (prop == null)
                        return string.Empty;

                    if (removeBrackets && prop is string stringProp)
                    {
                        stringProp = stringProp.Replace("[", "");
                        stringProp = stringProp.Replace("]", "");
                        return stringProp;
                    }
                    else if (prop is Enum)
                        return prop.ToEnumString();
                    else
                        return prop;
                case "object":
                    return prop ?? new object();
                case "array":
                    return prop ?? new object[0];
                default:
                    return prop;
            }
        }
    }
}
