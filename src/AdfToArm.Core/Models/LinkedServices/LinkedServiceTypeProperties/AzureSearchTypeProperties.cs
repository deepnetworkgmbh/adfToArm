using Newtonsoft.Json;

namespace AdfToArm.Core.Models.LinkedServices.LinkedServiceTypeProperties
{
    [JsonObject]
    public class AzureSearchTypeProperties : ILinkedServiceProperties
    {
        /// <summary>
        /// URL for the Azure Search service.
        /// </summary>
        [ArmParameter]
        [JsonProperty("url", Required = Required.Always)]
        public string Url { get; set; }

        /// <summary>
        /// Admin key for the Azure Search service.
        /// </summary>
        [ArmParameter]
        [JsonProperty("key", Required = Required.Always)]
        public string Key { get; set; }
    }
}
