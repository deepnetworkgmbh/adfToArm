using AdfToArm.Models.DataSets;
using AdfToArm.Models.LinkedServices;
using AdfToArm.Models.Pipelines;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace AdfToArm
{
    public class Program
    {
        private static readonly JsonSerializerSettings settings = new JsonSerializerSettings
        {
            Formatting = Formatting.Indented
        };

        public static void Main(string[] args)
        {
            string[] allFiles = Directory.GetFiles(@"C:\Users\igork\Desktop\Daimler.VAN.SPP.DataHub.ADF", "*.json", SearchOption.AllDirectories);

            foreach (var file in allFiles)
            {
                DeserializeFile(file);
            }

            Console.ReadLine();
        }

        private static void DeserializeFile(string file)
        {
            var jsonString = File.ReadAllText(file);

            if (jsonString.Contains("activities"))
            {
                // Pipeline
                var jo = JObject.Parse(jsonString);
                var pipeline = jo.ToObject<Pipeline>();
                var serialized = JsonConvert.SerializeObject(pipeline, settings);
            }
            else if (jsonString.Contains("availability"))
            {
                // DataSet
                DeserializeDataSet(file, jsonString);
            }
            else if (jsonString.Contains("typeProperties"))
            {
                // Linked Service
                DeserializeLinkedService(file, jsonString);
            }
            else
            {
                // ???
                Console.WriteLine($"????? {file}");
            }
        }

        private static void DeserializeDataSet(string file, string jsonString)
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

                    var serialized = JsonConvert.SerializeObject(dataset, settings);
                }
                catch (Exception ex)
                {
                    Console.WriteLine();
                    Console.WriteLine($"DataSet {typeValue}. \"{ex.Message}\" was handled processing {file}");
                }
            }
        }

        private static void DeserializeLinkedService(string file, string jsonString)
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

                    var serialized = JsonConvert.SerializeObject(linkedService, settings);
                }
                catch (Exception ex)
                {
                    Console.WriteLine();
                    Console.WriteLine($"LinkedService {typeValue}. \"{ex.Message}\" was handled processing {file}");
                }
            }
        }
    }
}
