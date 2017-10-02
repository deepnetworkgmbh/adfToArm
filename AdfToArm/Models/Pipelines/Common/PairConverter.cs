using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace AdfToArm.Models.Pipelines.Common
{
    public class PairConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(KeyValuePair<string, string>);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var item = (KeyValuePair<string, string>)value;
            writer.WriteRaw($"\"{item.Key}\" : \"{item.Value}\"");
            writer.Flush();
        }
    }
}
