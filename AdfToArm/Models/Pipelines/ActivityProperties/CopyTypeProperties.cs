using Newtonsoft.Json;

namespace AdfToArm.Models.Pipelines.ActivityProperties
{
    // TODO: each property should be an object
    [JsonObject]
    public class CopyTypeProperties : IActivityTypeProperties
    {
        [JsonProperty("source", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public object Source { get; set; }

        [JsonProperty("sink", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public object Sink { get; set; }

        [JsonProperty("translator", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public object Translator { get; set; }

        [JsonProperty("type", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public object Type { get; set; }
    }
}
