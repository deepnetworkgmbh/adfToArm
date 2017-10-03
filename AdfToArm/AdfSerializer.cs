using AdfToArm.Logs;
using AdfToArm.Models;
using AdfToArm.Models.DataSets;
using AdfToArm.Models.LinkedServices;
using AdfToArm.Models.Pipelines;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System;

namespace AdfToArm
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
                var jo = JObject.Parse(jsonString);
                var pipeline = jo.ToObject<Pipeline>();
                return (AdfItemType.Pipeline, pipeline);
            }
            else if (jsonString.Contains("availability"))
            {
                // DataSet
                return DeserializeDataSet(file, jsonString);
            }
            else if (jsonString.Contains("typeProperties"))
            {
                // Linked Service
                return DeserializeLinkedService(file, jsonString);
            }
            else
            {
                // ???
                Logger.Instance.Info($"Unexpected content in {file}");
            }

            return (AdfItemType.Unknown, null);
        }

        public static JObject GetJsonObject(string file)
        {
            var jsonString = File.ReadAllText(file);
            return JObject.Parse(jsonString);
        }

        private static (AdfItemType type, object value) DeserializeDataSet(string file, string jsonString)
        {
            var jo = JObject.Parse(jsonString);

            var typeValue = jo["properties"]["type"].Value<string>();
            if (Enum.TryParse(typeValue, out DataSetType dataSetType))
            {
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
                    }

                    return (AdfItemType.DataSet, dataset);
                }
                catch (Exception ex)
                {
                    Logger.Instance.Warn($"DataSet {typeValue}. \"{ex.Message}\" was handled processing {file}");
                }
            }

            return (AdfItemType.Unknown, null);
        }

        private static (AdfItemType type, object value) DeserializeLinkedService(string file, string jsonString)
        {
            var jo = JObject.Parse(jsonString);

            var typeValue = jo["properties"]["type"].Value<string>();
            if (Enum.TryParse(typeValue, out LinkedServiceType linkedServiceType))
            {
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
                        case LinkedServiceType.AzureStorage:
                            linkedService = jo.ToObject<AzureStorage>();
                            break;
                        case LinkedServiceType.HDInsight:
                            linkedService = jo.ToObject<HDInsight>();
                            break;
                    }

                    return (AdfItemType.LinkedService, linkedService);
                }
                catch (Exception ex)
                {
                    Logger.Instance.Warn($"LinkedService {typeValue}. \"{ex.Message}\" was handled processing {file}");
                }
            }

            return (AdfItemType.Unknown, null);
        }
    }
}
