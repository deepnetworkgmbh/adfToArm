using AdfToArm.Logs;
using AdfToArm.Models.Pipelines.ActivityProperties.CopyActivity.Sources;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace AdfToArm.Models.Pipelines.ActivityProperties.CopyActivity
{
    public class CopySourceTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(ICopySource).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);

            var typeValue = token["type"]?.ToString();

            if (Enum.TryParse(typeValue, out CopySourceType sourceType))
            {
                try
                {
                    switch (sourceType)
                    {
                        case CopySourceType.AzureDataLakeStoreSource:
                            return token.ToObject<CopySourceDataLake>();
                        case CopySourceType.BlobSource:
                            return token.ToObject<CopySourceBlob>();
                        case CopySourceType.SqlSource:
                            return token.ToObject<CopySourceAzureSql>();
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
