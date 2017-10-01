using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AdfToArm.Models.LinkedServices
{
    [JsonObject]
    public class AzureStorage
    {
        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty("properties", Required = Required.Always)]
        public AzureStorageProperties Properties { get; set; }
    }

    [JsonObject]
    public class AzureStorageProperties
    {
        public AzureStorageProperties()
        {
            Type = LinkedService.AzureStorage;
        }

        [JsonProperty("type", Required = Required.Always)]
        [JsonConverter(typeof(StringEnumConverter))]
        public LinkedService Type { get; }

        [JsonProperty("typeProperties", Required = Required.Always)]
        public AzureStorageTypeProperties TypeProperties { get; set; }
    }

    [JsonObject]
    public class AzureStorageTypeProperties
    {
        [JsonProperty("connectionString", Required = Required.Always)]
        public string ConnectionString { get; set; }
    }
}
