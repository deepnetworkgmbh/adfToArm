using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AdfToArm.Models.LinkedServices
{
    [JsonObject]
    public class AzureBatch
    {
        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty("properties", Required = Required.Always)]
        public AzureBatchProperties Properties { get; set; }
    }

    [JsonObject]
    public class AzureBatchProperties
    {
        public AzureBatchProperties()
        {
            Type = LinkedService.AzureBatch;
        }

        [JsonProperty("type", Required = Required.Always)]
        [JsonConverter(typeof(StringEnumConverter))]
        public LinkedService Type { get; }

        [JsonProperty("typeProperties", Required = Required.Always)]
        public AzureBatchTypeProperties TypeProperties { get; set; }
    }

    [JsonObject]
    public class AzureBatchTypeProperties
    {
        /// <summary>
        /// Name of the Azure Batch account.
        /// </summary>
        [JsonProperty("accountName", Required = Required.Always)]
        public string AccountName { get; set; }

        /// <summary>
        /// Access key for the Azure Batch account.
        /// </summary>
        [JsonProperty("accessKey", Required = Required.Always)]
        public string AccessKey { get; set; }

        /// <summary>
        /// Name of the pool of virtual machines.
        /// </summary>
        [JsonProperty("poolName", Required = Required.Always)]
        public string PoolName { get; set; }

        /// <summary>
        /// Name of the Azure Storage linked service associated with this Azure Batch linked service. 
        /// This linked service is used for staging files required to run the activity and storing the activity execution logs.
        /// </summary>
        [JsonProperty("linkedServiceName", Required = Required.Always)]
        public string LinkedServiceName { get; set; }
    }
}
