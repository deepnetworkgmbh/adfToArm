using Newtonsoft.Json;

namespace AdfToArm.Core.Models.LinkedServices.LinkedServiceTypeProperties
{
    [JsonObject]
    public class AzureDataLakeAnalyticsTypeProperties : ILinkedServiceProperties
    {
        /// <summary>
        /// Azure Data Lake Analytics Account Name.
        /// </summary>
        [ArmParameter]
        [JsonProperty("accountName", Required = Required.Always)]
        public string AccountName { get; set; }

        /// <summary>
        /// Azure Data Lake Analytics URI.
        /// </summary>
        [ArmParameter]
        [JsonProperty("dataLakeAnalyticsUri", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string DataLakeAnalyticsUri { get; set; }

        /// <summary>
        /// Authorization code is automatically retrieved after clicking Authorize button in the Data Factory Editor and completing the OAuth login.
        /// </summary>
        [ArmParameter]
        [JsonProperty("authorization", Required = Required.Always)]
        public string Authorization { get; set; }

        /// <summary>
        /// Azure subscription id
        /// 
        /// If not specified, subscription of the data factory is used
        /// </summary>
        [ArmParameter]
        [JsonProperty("sessionId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string SessionId { get; set; }

        /// <summary>
        /// Azure resource group name
        /// 
        /// If not specified, resource group of the data factory is used
        /// </summary>
        [ArmParameter]
        [JsonProperty("subscriptionId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string SubscriptionId { get; set; }

        /// <summary>
        /// Session id from the OAuth authorization session. 
        /// Each session id is unique and may only be used once. 
        /// When you use the Data Factory Editor, this ID is auto-generated.
        /// </summary>
        [ArmParameter]
        [JsonProperty("resourceGroupName", Required = Required.Always)]
        public string ResourceGroupName { get; set; }
    }
}
