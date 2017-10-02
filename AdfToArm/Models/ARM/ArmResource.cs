using Newtonsoft.Json;

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

        [JsonProperty("location", Required = Required.Default)]
        public string Location { get; set; }

        [JsonProperty("name", Required = Required.Default)]
        public string Description { get; set; }

        [JsonProperty("resources", Required = Required.Always)]
        public ArmResource[] Resources { get; set; }

        [JsonProperty("dependsOn", Required = Required.Default)]
        public string[] DependsOn { get; set; }
    }
}
