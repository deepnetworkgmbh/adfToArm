using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AdfToArm.Models.LinkedServices
{
    [JsonObject]
    public class AzureDataLakeStore
    {
        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty("properties", Required = Required.Always)]
        public AzureDataLakeStoreProperties Properties { get; set; }
    }

    [JsonObject]
    public class AzureDataLakeStoreProperties
    {
        public AzureDataLakeStoreProperties()
        {
            Type = LinkedService.AzureDataLakeStore;
        }

        [JsonProperty("type", Required = Required.Always)]
        [JsonConverter(typeof(StringEnumConverter))]
        public LinkedService Type { get; }

        [JsonProperty("typeProperties", Required = Required.Always)]
        public AzureDataLakeStoreTypeProperties TypeProperties { get; set; }
    }

    // TODO: Custom validation
    [JsonObject]
    public class AzureDataLakeStoreTypeProperties
    {
        /// <summary>
        /// Specify information about the Azure Data Lake Store account. 
        /// It is in the following format: https://[accountname].azuredatalakestore.net/webhdfs/v1 or adl://[accountname].azuredatalakestore.net/.
        /// </summary>
        [JsonProperty("dataLakeStoreUri", Required = Required.Always)]
        public string DataLakeStoreUri { get; set; }

        /// <summary>
        /// Azure subscription Id to which Data Lake Store belongs.
        /// 
        /// Required for sink
        /// </summary>
        [JsonProperty("subscriptionId", Required = Required.AllowNull)]
        public string SubscriptionId { get; set; }

        /// <summary>
        /// Azure resource group name to which Data Lake Store belongs.
        /// 
        /// Required for sink
        /// </summary>
        [JsonProperty("resourceGroupName", Required = Required.AllowNull)]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Specify the application's client ID.
        /// 
        /// Required for service principal authentication
        /// </summary>
        [JsonProperty("servicePrincipalId", Required = Required.AllowNull)]
        public string ServicePrincipalId { get; set; }

        /// <summary>
        /// Specify the application's key.
        /// 
        /// Required for service principal authentication
        /// </summary>
        [JsonProperty("servicePrincipalKey", Required = Required.AllowNull)]
        public string ServicePrincipalKey { get; set; }

        /// <summary>
        /// Specify the tenant information (domain name or tenant ID) under which your application resides. 
        /// You can retrieve it by hovering the mouse in the top-right corner of the Azure portal.
        /// 
        /// Required for service principal authentication
        /// </summary>
        [JsonProperty("tenant", Required = Required.AllowNull)]
        public string Tenant { get; set; }

        /// <summary>
        /// Click Authorize button in the Data Factory Editor and enter your credential that assigns the auto-generated authorization URL to this property.
        /// 
        /// Required for user credential authentication
        /// </summary>
        [JsonProperty("authorization", Required = Required.AllowNull)]
        public string Authorization { get; set; }

        /// <summary>
        /// OAuth session id from the OAuth authorization session. 
        /// Each session id is unique and may only be used once. 
        /// This setting is automatically generated when you use Data Factory Editor.
        /// 
        /// Required for user credential authentication
        /// </summary>
        [JsonProperty("sessionId", Required = Required.AllowNull)]
        public string SessionId { get; set; }
    }
}
