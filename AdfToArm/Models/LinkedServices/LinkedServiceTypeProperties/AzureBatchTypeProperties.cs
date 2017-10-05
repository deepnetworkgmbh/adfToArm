using Newtonsoft.Json;

namespace AdfToArm.Models.LinkedServices.LinkedServiceTypeProperties
{
    [JsonObject]
    public class AzureBatchTypeProperties : ILinkedServiceProperties
    {
        /// <summary>
        /// Name of the Azure Batch account.
        /// </summary>
        [ArmParameter]
        [JsonProperty("accountName", Required = Required.Always)]
        public string AccountName { get; set; }

        /// <summary>
        /// Access key for the Azure Batch account.
        /// </summary>
        [ArmParameter]
        [JsonProperty("accessKey", Required = Required.Always)]
        public string AccessKey { get; set; }

        /// <summary>
        /// Name of the pool of virtual machines.
        /// </summary>
        [ArmParameter]
        [JsonProperty("poolName", Required = Required.Always)]
        public string PoolName { get; set; }

        /// <summary>
        /// Name of the Azure Storage linked service associated with this Azure Batch linked service. 
        /// This linked service is used for staging files required to run the activity and storing the activity execution logs.
        /// </summary>
        [ArmParameter]
        [JsonProperty("linkedServiceName", Required = Required.Always)]
        public string LinkedServiceName { get; set; }
    }
}
