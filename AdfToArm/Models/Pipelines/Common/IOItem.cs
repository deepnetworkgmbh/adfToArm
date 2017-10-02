using Newtonsoft.Json;

namespace AdfToArm.Models.Pipelines.Common
{
    [JsonObject]
    public class IOItem
    {
        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }
    }
}
