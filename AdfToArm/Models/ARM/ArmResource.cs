using Newtonsoft.Json;
using System.Collections.Generic;

namespace AdfToArm.Models.ARM
{
    public abstract class ArmResource
    {
        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty("apiVersion", Required = Required.Always)]
        public string ApiVersion { get; set; }

        [JsonProperty("type", Required = Required.Always)]
        public string Type { get; set; }

        [JsonProperty("location", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Location { get; set; }

        [JsonProperty("description", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        [JsonProperty("resources", Required = Required.AllowNull)]
        public List<ArmResource> Resources { get; set; }

        [JsonProperty("dependsOn", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string[] DependsOn { get; set; }
    }
}
