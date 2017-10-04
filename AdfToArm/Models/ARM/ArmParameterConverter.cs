using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AdfToArm.Models.ARM
{
    public class ArmParameterConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(ArmParameter);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var parameter = value as ArmParameter;

            if (parameter == null)
                return;

            JObject jo = new JObject();
            var propertiesToken = JToken.FromObject(parameter.Properties);
            jo.Add(parameter.Name, propertiesToken);

            jo.WriteTo(writer);
        }
    }
}
