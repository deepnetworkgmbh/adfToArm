using Newtonsoft.Json;

namespace AdfToArm.Core.Models.LinkedServices.LinkedServiceTypeProperties
{
    // TODO: Validate that User and Service Authentication can't be used together.
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
        [JsonProperty("resourceGroupName", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Authorization code is automatically retrieved after clicking Authorize button in the Data Factory Editor and completing the OAuth login.
        /// 
        /// Together with SessionId required for User credential authentication.
        /// </summary>
        [ArmParameter]
        [JsonProperty("authorization", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Authorization { get; set; }

        /// <summary>
        /// OAuth session ID from the OAuth authorization session. 
        /// Each session ID is unique and can be used only once. 
        /// This setting is automatically generated when you use the Data Factory Editor.
        /// 
        /// Together with Authorization required for User credential authentication.
        /// </summary>
        [ArmParameter]
        [JsonProperty("sessionId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string SessionId { get; set; }

        /// <summary>
        /// Specify the application's client ID.
        /// 
        /// Together with ServicePrincipalKey and Tenant required for Service credential authentication.
        /// </summary>
        [ArmParameter]
        [JsonProperty("servicePrincipalId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string ServicePrincipalId { get; set; }

        /// <summary>
        /// Specify the application's key.
        /// 
        /// Together with ServicePrincipalId and Tenant required for Service credential authentication.
        /// </summary>
        [ArmParameter]
        [JsonProperty("servicePrincipalKey", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string ServicePrincipalKey { get; set; }

        /// <summary>
        /// Specify the tenant information (domain name or tenant ID) under which your application resides. 
        /// You can retrieve it by hovering the mouse in the upper-right corner of the Azure portal.
        /// 
        /// Together with ServicePrincipalKey and ServicePrincipalId required for Service credential authentication.
        /// </summary>
        [ArmParameter]
        [JsonProperty("tenant", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Tenant { get; set; }
    }
}
