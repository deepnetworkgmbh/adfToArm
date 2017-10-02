using Newtonsoft.Json;

namespace AdfToArm.Models.Pipelines.ActivityProperties
{
    // TODO: each property should be an object
    [JsonObject]
    public class CopyTypeProperties : IActivityTypeProperties
    {
        [JsonProperty("source", Required = Required.Always)]
        public string Source { get; set; }

        [JsonProperty("sink", Required = Required.Always)]
        public string Sink { get; set; }

        [JsonProperty("translator", Required = Required.Always)]
        public string Translator { get; set; }

        [JsonProperty("type", Required = Required.Always)]
        public string Type { get; set; }
    }
}
