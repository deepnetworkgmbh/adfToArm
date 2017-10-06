using Newtonsoft.Json;

namespace AdfToArm.Core.Models.LinkedServices.LinkedServiceTypeProperties
{
    [JsonObject]
    public class AzureDataLakeStoreTypeProperties : ILinkedServiceProperties
    {
        /// <summary>
        /// Specify information about the Azure Data Lake Store account. 
        /// It is in the following format: https://[accountname].azuredatalakestore.net/webhdfs/v1 or adl://[accountname].azuredatalakestore.net/.
        /// </summary>
        [ArmParameter]
        [JsonProperty("dataLakeStoreUri", Required = Required.Always)]
        public string DataLakeStoreUri { get; set; }

        /// <summary>
        /// Azure subscription Id to which Data Lake Store belongs.
        /// 
        /// Required for sink
        /// </summary>
        [ArmParameter]
        [JsonProperty("subscriptionId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string SubscriptionId { get; set; }

        /// <summary>
        /// Azure resource group name to which Data Lake Store belongs.
        /// 
        /// Required for sink
        /// </summary>
        [ArmParameter]
        [JsonProperty("resourceGroupName", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Specify the application's client ID.
        /// 
        /// Required for service principal authentication
        /// </summary>
        [ArmParameter]
        [JsonProperty("servicePrincipalId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string ServicePrincipalId { get; set; }

        /// <summary>
        /// Specify the application's key.
        /// 
        /// Required for service principal authentication
        /// </summary>
        [ArmParameter]
        [JsonProperty("servicePrincipalKey", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string ServicePrincipalKey { get; set; }

        /// <summary>
        /// Specify the tenant information (domain name or tenant ID) under which your application resides. 
        /// You can retrieve it by hovering the mouse in the top-right corner of the Azure portal.
        /// 
        /// Required for service principal authentication
        /// </summary>
        [ArmParameter]
        [JsonProperty("tenant", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Tenant { get; set; }

        /// <summary>
        /// Click Authorize button in the Data Factory Editor and enter your credential that assigns the auto-generated authorization URL to this property.
        /// 
        /// Required for user credential authentication
        /// </summary>
        [ArmParameter]
        [JsonProperty("authorization", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Authorization { get; set; }

        /// <summary>
        /// OAuth session id from the OAuth authorization session. 
        /// Each session id is unique and may only be used once. 
        /// This setting is automatically generated when you use Data Factory Editor.
        /// 
        /// Required for user credential authentication
        /// </summary>
        [ArmParameter]
        [JsonProperty("sessionId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string SessionId { get; set; }
    }
}
