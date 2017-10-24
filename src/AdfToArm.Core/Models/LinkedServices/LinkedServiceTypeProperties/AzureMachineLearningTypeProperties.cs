using Newtonsoft.Json;

namespace AdfToArm.Core.Models.LinkedServices.LinkedServiceTypeProperties
{
    [JsonObject]
    public class AzureMachineLearningTypeProperties : ILinkedServiceProperties
    {
        /// <summary>
        /// The batch scoring URL.
        /// </summary>
        [ArmParameter]
        [JsonProperty("mlEndpoint", Required = Required.Always)]
        public string MlEndpoint { get; set; }

        /// <summary>
        /// The published workspace model’s API.
        /// </summary>
        [ArmParameter]
        [JsonProperty("apiKey", Required = Required.Always)]
        public string ApiKey { get; set; }
    }
}
