using Newtonsoft.Json;

namespace AdfToArm.Core.Models.LinkedServices.LinkedServiceTypeProperties
{
    [JsonObject]
    public class AzureCosmosDbTypeProperties : ILinkedServiceProperties
    {
        [ArmParameter]
        [JsonProperty("connectionString", Required = Required.Always)]
        public string ConnectionString { get; set; }
    }
}
