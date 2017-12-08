using AdfToArm.Core.Logs;
using AdfToArm.Core.Models;
using AdfToArm.Core.Models.DataSets;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AdfToArm.Core.Serialization
{
    public class DataSetSerializer : IAdfSerializer
    {
        private readonly string _json;

        public DataSetSerializer(string jsonString)
        {
            _json = jsonString;
        }

        public (AdfItemType type, object value) Deserialize()
        {
            try
            {
                return DeserializeDataSet();
            }
            catch (JsonReaderException ex)
            {
                Logger.Instance.Error($"JSON parse failed. \"{ex.Message}\" was handled");
                throw new AdfParseException("JSON parse failed", ex);
            }
        }

        private (AdfItemType type, object value) DeserializeDataSet()
        {
            var jo = JObject.Parse(_json);

            var typeValue = jo["properties"]?["type"]?.Value<string>();

            DataSetType dataSetType = typeValue.ToEnum<DataSetType>();
            DataSet dataset = null;
            try
            {
                switch (dataSetType)
                {
                    case DataSetType.AzureBlob:
                        dataset = jo.ToObject<AzureBlob>();
                        break;
                    case DataSetType.AzureDataLakeStore:
                        dataset = jo.ToObject<AzureDataLakeStore>();
                        break;
                    case DataSetType.AzureSqlTable:
                        dataset = jo.ToObject<AzureSqlTable>();
                        break;
                    case DataSetType.AzureSqlDwTable:
                        dataset = jo.ToObject<AzureSqlDwTable>();
                        break;
                    case DataSetType.CosmosDbCollection:
                        dataset = jo.ToObject<AzureCosmosDbCollection>();
                        break;
                    case DataSetType.AzureTable:
                        dataset = jo.ToObject<AzureTable>();
                        break;
                    case DataSetType.AzureSearchIndex:
                        dataset = jo.ToObject<AzureSearchIndex>();
                        break;
                }

                return (AdfItemType.DataSet, dataset);
            }
            catch (JsonSerializationException ex)
            {
                Logger.Instance.Error($"DataSet {typeValue}. \"{ex.Message}\" was handled");
                throw new AdfParseException($"DataSet {typeValue}", ex);
            }
        }

    }
}
