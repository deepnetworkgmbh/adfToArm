using Newtonsoft.Json;

namespace AdfToArm.Core.Models.Pipelines.ActivityProperties.CopyActivity
{
    [JsonObject]
    public class CopyTranslator
    {
        [JsonProperty("type", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("ColumnMappings", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string ColumnMappings { get; set; }
    }
}
