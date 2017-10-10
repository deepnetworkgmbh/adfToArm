using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace AdfToArm.Core.Models.ARM
{
    class ArmTemplateParametersConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(List<ArmTemplateParameterItem>);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var parameters = value as List<ArmTemplateParameterItem>;

            if (parameters == null)
                return;

            JObject jo = new JObject();

            foreach (var param in parameters)
                jo.Add(param.Name, JObject.FromObject(param));

            jo.WriteTo(writer);
        }
    }
}
