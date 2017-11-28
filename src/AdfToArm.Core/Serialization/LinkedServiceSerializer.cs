using AdfToArm.Core.Logs;
using AdfToArm.Core.Models;
using AdfToArm.Core.Models.LinkedServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AdfToArm.Core.Serialization
{
    public class LinkedServiceSerializer : IAdfSerializer
    {
        private readonly string _json;

        public LinkedServiceSerializer(string jsonString)
        {
            _json = jsonString;
        }

        public (AdfItemType type, object value) Deserialize()
        {
            try
            {
                return DeserializeLinkedService();
            }
            catch (JsonReaderException ex)
            {
                Logger.Instance.Error($"JSON parse failed. \"{ex.Message}\" was handled");
                throw new AdfParseException("JSON parse failed", ex);
            }
        }

        private (AdfItemType type, object value) DeserializeLinkedService()
        {
            var jo = JObject.Parse(_json);

            var typeValue = jo["properties"]?["type"]?.Value<string>();
            LinkedServiceType linkedServiceType = typeValue.ToEnum<LinkedServiceType>();
            try
            {
                LinkedService linkedService = null;
                switch (linkedServiceType)
                {
                    case LinkedServiceType.AzureBatch:
                        linkedService = jo.ToObject<AzureBatch>();
                        break;
                    case LinkedServiceType.AzureDataLakeAnalytics:
                        linkedService = jo.ToObject<AzureDataLakeAnalytics>();
                        break;
                    case LinkedServiceType.AzureDataLakeStore:
                        linkedService = jo.ToObject<AzureDataLakeStore>();
                        break;
                    case LinkedServiceType.AzureSqlDatabase:
                        linkedService = jo.ToObject<AzureSqlDatabase>();
                        break;
                    case LinkedServiceType.AzureSqlDW:
                        linkedService = jo.ToObject<AzureSqlDW>();
                        break;
                    case LinkedServiceType.AzureStorage:
                        linkedService = jo.ToObject<AzureStorage>();
                        break;
                    case LinkedServiceType.AzureStorageSas:
                        linkedService = jo.ToObject<AzureStorageSas>();
                        break;
                    case LinkedServiceType.HDInsight:
                        linkedService = jo.ToObject<HDInsight>();
                        break;
                    case LinkedServiceType.HDInsightOnDemand:
                        linkedService = jo.ToObject<HDInsightOnDemand>();
                        break;
                    case LinkedServiceType.AzureCosmosDb:
                        linkedService = jo.ToObject<AzureCosmosDb>();
                        break;
                    case LinkedServiceType.AzureSearch:
                        linkedService = jo.ToObject<AzureSearch>();
                        break;
                    case LinkedServiceType.AzureML:
                        linkedService = jo.ToObject<AzureMachineLearning>();
                        break;
                }

                return (AdfItemType.LinkedService, linkedService);
            }
            catch (JsonSerializationException ex)
            {
                Logger.Instance.Error($"LinkedService {typeValue}. \"{ex.Message}\" was handled");
                throw new AdfParseException($"LinkedService {typeValue}", ex);
            }
        }
    }
}
