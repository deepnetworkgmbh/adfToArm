using AdfToArm.Logs;
using AdfToArm.Models.Pipelines.ActivityProperties.CopyActivity;
using AdfToArm.Models.Pipelines.ActivityProperties.CopyActivity.Sinks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace AdfToArm.Models.Pipelines
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

            if (Enum.TryParse(typeValue, out CopySinkType sinkType))
            {
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
            }
            else
            {
                Logger.Instance.Error($"Unable to get Sink type {typeValue}");
                throw new AdfParseException($"Unable to get Sink type {typeValue}");
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
