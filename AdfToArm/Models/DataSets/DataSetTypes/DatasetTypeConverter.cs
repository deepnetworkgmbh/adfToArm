using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AdfToArm.Models.DataSets.DataSetTypes
{
    public class DatasetTypeConverter : JsonConverter
    {
        public override bool CanRead => true;
        public override bool CanWrite => true;

        public override bool CanConvert(Type objectType)
        {
            return
                objectType == typeof(AzureBlobTypeProperties) ||
                objectType == typeof(AzureDataLakeStoreTypeProperties) ||
                objectType == typeof(AzureSqlTableTypeProperties);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            if (token.Type != JTokenType.Object)
                return null;

            var typeValue = token["properties"]["type"].Value<string>();
            if (Enum.TryParse(typeValue, out DataSetType dataSetType))
            {
                switch (dataSetType)
                {
                    case DataSetType.AzureBlob:
                        break;
                    case DataSetType.AzureDataLakeStore:
                        break;
                    case DataSetType.AzureSqlTable:
                        break;
                }

                return null;
            }
            else
                return null;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            JToken t = JToken.FromObject(value);
            t.WriteTo(writer);
        }
    }
}
