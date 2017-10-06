using Newtonsoft.Json;

namespace AdfToArm.Core.Models.DataSets.Common
{
    [JsonObject]
    public class PartitionedBy
    {
        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty("value", Required = Required.Always)]
        public ValueDescription Value { get; set; }
    }

    [JsonObject]
    public class ValueDescription
    {
        [JsonProperty("type", Required = Required.Always)]
        public string Type { get; set; }

        [JsonProperty("date", Required = Required.Always)]
        public string Date { get; set; }

        [JsonProperty("format", Required = Required.Always)]
        public string Format { get; set; }
    }
}
