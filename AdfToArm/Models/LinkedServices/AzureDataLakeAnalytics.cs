using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AdfToArm.Models.LinkedServices
{
    [JsonObject]
    public class AzureDataLakeAnalytics
    {
        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty("properties", Required = Required.Always)]
        public AzureDataLakeAnalyticsProperties Properties { get; set; }
    }

    [JsonObject]
    public class AzureDataLakeAnalyticsProperties
    {
        public AzureDataLakeAnalyticsProperties()
        {
            Type = LinkedService.AzureDataLakeAnalytics;
        }

        /// <summary>
        /// The type property should be set to: AzureDataLakeAnalytics.
        /// </summary>
        [JsonProperty("type", Required = Required.Always)]
        [JsonConverter(typeof(StringEnumConverter))]
        public LinkedService Type { get; }

        [JsonProperty("typeProperties", Required = Required.Always)]
        public AzureDataLakeAnalyticsTypeProperties TypeProperties { get; set; }
    }

    [JsonObject]
    public class AzureDataLakeAnalyticsTypeProperties
    {
        /// <summary>
        /// Azure Data Lake Analytics Account Name.
        /// </summary>
        [JsonProperty("accountName", Required = Required.Always)]
        public string AccountName { get; set; }

        /// <summary>
        /// Azure Data Lake Analytics URI.
        /// </summary>
        [JsonProperty("dataLakeAnalyticsUri", Required = Required.AllowNull)]
        public string DataLakeAnalyticsUri { get; set; }

        /// <summary>
        /// Authorization code is automatically retrieved after clicking Authorize button in the Data Factory Editor and completing the OAuth login.
        /// </summary>
        [JsonProperty("authorization", Required = Required.Always)]
        public string Authorization { get; set; }

        /// <summary>
        /// Azure subscription id
        /// 
        /// If not specified, subscription of the data factory is used
        /// </summary>
        [JsonProperty("sessionId", Required = Required.AllowNull)]
        public string SessionId { get; set; }

        /// <summary>
        /// Azure resource group name
        /// 
        /// If not specified, resource group of the data factory is used
        /// </summary>
        [JsonProperty("subscriptionId", Required = Required.AllowNull)]
        public string SubscriptionId { get; set; }

        /// <summary>
        /// Session id from the OAuth authorization session. 
        /// Each session id is unique and may only be used once. 
        /// When you use the Data Factory Editor, this ID is auto-generated.
        /// </summary>
        [JsonProperty("resourceGroupName", Required = Required.Always)]
        public string ResourceGroupName { get; set; }
    }
}
