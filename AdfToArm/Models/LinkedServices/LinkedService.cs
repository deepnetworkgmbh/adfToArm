using AdfToArm.Models.LinkedServices.LinkedServiceTypeProperties;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AdfToArm.Models.LinkedServices
{
    public abstract class LinkedService
    {
        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty("properties", Required = Required.Always)]
        public LinkedServiceProperties Properties { get; set; }
    }

    [JsonObject]
    public class LinkedServiceProperties
    {
        [JsonProperty("type", Required = Required.Always)]
        [JsonConverter(typeof(StringEnumConverter))]
        public LinkedServiceType Type { get; set; }

        [JsonProperty("typeProperties", Required = Required.Always)]
        public ILinkedServiceProperties TypeProperties { get; set; }
    }
}
