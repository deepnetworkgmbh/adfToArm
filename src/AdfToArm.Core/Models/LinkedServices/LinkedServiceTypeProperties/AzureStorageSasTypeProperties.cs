using Newtonsoft.Json;

namespace AdfToArm.Core.Models.LinkedServices.LinkedServiceTypeProperties
{
    [JsonObject]
    public class AzureStorageSasTypeProperties : ILinkedServiceProperties
    {
        /// <summary>
        /// Specify Shared Access Signature URI to the Azure Storage resources such as blob, container, or table.
        /// </summary>
        [ArmParameter]
        [JsonProperty("sasUri", Required = Required.Always)]
        public string SasUri { get; set; }
    }
}
