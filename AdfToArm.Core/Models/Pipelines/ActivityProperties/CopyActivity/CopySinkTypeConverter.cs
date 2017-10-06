using AdfToArm.Core.Logs;
using AdfToArm.Core.Models.Pipelines.ActivityProperties.CopyActivity;
using AdfToArm.Core.Models.Pipelines.ActivityProperties.CopyActivity.Sinks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace AdfToArm.Core.Models.Pipelines
{
    public class CopySinkTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(ICopySink).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);

            var typeValue = token["type"]?.ToString();

            CopySinkType sinkType = typeValue.ToEnum<CopySinkType>();
            try
            {
                switch (sinkType)
                {
                    case CopySinkType.AzureDataLakeStoreSink:
                        return token.ToObject<CopySinkDataLake>();
                    case CopySinkType.BlobSink:
                        return token.ToObject<CopySinkBlob>();
                    case CopySinkType.SqlSink:
                        return token.ToObject<CopySinkAzureSql>();
                }
            }
            catch (JsonSerializationException ex)
            {
                Logger.Instance.Error($"Sink type {typeValue}. \"{ex.Message}\" was handled processing {token["name"]}");
                throw new AdfParseException($"Sink type {typeValue}", ex);
            }

            return null;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var jt = JToken.FromObject(value);
            jt.WriteTo(writer);
        }
    }
}
