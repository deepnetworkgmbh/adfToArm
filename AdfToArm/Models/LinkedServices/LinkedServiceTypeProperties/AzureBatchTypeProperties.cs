using Newtonsoft.Json;

namespace AdfToArm.Models.LinkedServices.LinkedServiceTypeProperties
{
    [JsonObject]
    public class AzureBatchTypeProperties : ILinkedServiceProperties
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
