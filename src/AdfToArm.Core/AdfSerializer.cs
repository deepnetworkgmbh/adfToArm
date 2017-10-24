using AdfToArm.Core.Logs;
using AdfToArm.Core.Models;
using AdfToArm.Core.Models.DataSets;
using AdfToArm.Core.Models.LinkedServices;
using AdfToArm.Core.Models.Pipelines;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System;

namespace AdfToArm.Core
{
    public class AdfSerializer
    {
        private static readonly JsonSerializerSettings settings = new JsonSerializerSettings
        {
            Formatting = Formatting.Indented
        };

        public static string Serialize<T>(T value)
        {
            return JsonConvert.SerializeObject(value, settings);
        }

        public static (AdfItemType type, object value) Deserialize(string file)
        {
            var jsonString = File.ReadAllText(file);

            if (jsonString.Contains("activities"))
            {
                // Pipeline
                try
                {
                    var jo = JObject.Parse(jsonString);
                    var pipeline = jo.ToObject<Pipeline>();
                    return (AdfItemType.Pipeline, pipeline);
                }
                catch (JsonReaderException ex)
                {
                    Logger.Instance.Error($"JSON parse failed. \"{ex.Message}\" was handled processing {file}");
                    throw new AdfParseException("JSON parse failed", ex, file);
                }
                catch (JsonSerializationException ex)
                {
                    Logger.Instance.Error($"Pipeline parsing failed. \"{ex.Message}\" was handled processing {file}");
                    throw new AdfParseException("Pipeline parsing failed", ex, file);
                }
            }
            else if (jsonString.Contains("availability"))
            {
                // DataSet
                try
                {
                    return DeserializeDataSet(file, jsonString);
                }
                catch (JsonReaderException ex)
                {
                    Logger.Instance.Error($"JSON parse failed. \"{ex.Message}\" was handled processing {file}");
                    throw new AdfParseException("JSON parse failed", ex, file);
                }
            }
            else if (jsonString.Contains("typeProperties"))
            {
                // Linked Service
                try
                {
                    return DeserializeLinkedService(file, jsonString);
                }
                catch (JsonReaderException ex)
                {
                    Logger.Instance.Error($"JSON parse failed. \"{ex.Message}\" was handled processing {file}");
                    throw new AdfParseException("JSON parse failed", ex, file);
                }
            }
            else
            {
                // ???
                Logger.Instance.Info($"Unexpected content in {file}");
                throw new AdfParseException("File contains unexpected content", file);
            }
        }

        public static JObject GetJsonObject(string file)
        {
            var jsonString = File.ReadAllText(file);
            return JObject.Parse(jsonString);
        }

        private static (AdfItemType type, object value) DeserializeDataSet(string file, string jsonString)
        {
            var jo = JObject.Parse(jsonString);

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
                        dataset = jo.ToObject<Models.DataSets.AzureDataLakeStore>();
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
                Logger.Instance.Error($"DataSet {typeValue}. \"{ex.Message}\" was handled processing {file}");
                throw new AdfParseException($"DataSet {typeValue}", ex, file);
            }
        }

        private static (AdfItemType type, object value) DeserializeLinkedService(string file, string jsonString)
        {
            var jo = JObject.Parse(jsonString);

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
                        linkedService = jo.ToObject<Models.LinkedServices.AzureDataLakeStore>();
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
                Logger.Instance.Error($"LinkedService {typeValue}. \"{ex.Message}\" was handled processing {file}");
                throw new AdfParseException($"LinkedService {typeValue}", ex, file);
            }
        }
    }
}
