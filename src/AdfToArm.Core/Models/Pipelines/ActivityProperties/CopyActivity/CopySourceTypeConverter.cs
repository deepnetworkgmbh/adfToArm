using AdfToArm.Core.Logs;
using AdfToArm.Core.Models.Pipelines.ActivityProperties.CopyActivity.Sources;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace AdfToArm.Core.Models.Pipelines.ActivityProperties.CopyActivity
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

            CopySourceType sourceType = typeValue.ToEnum<CopySourceType>();
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

            return null;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var jt = JToken.FromObject(value);
            jt.WriteTo(writer);
        }
    }
}
