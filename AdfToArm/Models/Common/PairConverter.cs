using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace AdfToArm.Models.Common
{
    public class PairConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(KeyValuePair<string, string>);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            if (token.Type != JTokenType.Object || !token.HasValues)
                return null;

            var result = new List<KeyValuePair<string, string>>();

            foreach(var item in token.Values())
            {
                var key = item.Path;
                var value = item.Value<string>();

                result.Add(new KeyValuePair<string, string>(key, value));
            }

            return result.ToArray();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var dict = (KeyValuePair<string, string>[])value;

            if (dict == null)
                return;

            JObject jo = new JObject();

            foreach(var item in dict)
                jo.Add(item.Key, item.Value);

            jo.WriteTo(writer);
        }
    }
}
