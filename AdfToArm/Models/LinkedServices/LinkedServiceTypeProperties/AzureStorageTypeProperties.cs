using Newtonsoft.Json;

namespace AdfToArm.Models.LinkedServices.LinkedServiceTypeProperties
{
    [JsonObject]
    public class AzureStorageTypeProperties : ILinkedServiceProperties
    {
        [JsonProperty("connectionString", Required = Required.Always)]
        public string ConnectionString { get; set; }
    }
}
