using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using AdfToArm.Core.Models.Common;

namespace AdfToArm.Core.Models.ARM
{
    public class DefaultValueConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value is KeyValuePair<string, string>[])
            {
                var pairConverter = new PairConverter();
                pairConverter.WriteJson(writer, value, serializer);
            }
            else if(value.GetType().IsArray)
            {
                var ja = new JArray(value);
                ja.WriteTo(writer);
            }
            else if(value.GetType().IsSimple())
            {
                var jv = new JValue(value);
                jv.WriteTo(writer);
            }
            else
            {
                var jo = JObject.FromObject(value);
                jo.WriteTo(writer);
            }
        }
    }
}
