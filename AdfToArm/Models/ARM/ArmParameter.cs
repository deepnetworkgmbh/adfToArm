using Newtonsoft.Json;

namespace AdfToArm.Models.ARM
{
    [JsonConverter(typeof(ArmParameterConverter))]
    [JsonObject]
    public class ArmParameter
    {
        public string Name { get; set; }

        public ArmParameterProperties Properties { get; set; }
    }

    [JsonObject]
    public class ArmParameterProperties
    {
        [JsonProperty("type", Required = Required.Always)]
        public string Type { get; set; }

        [JsonProperty("defaultValue", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public object DefaultValue { get; set; }

        [JsonProperty("allowedValues", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public object[] AllowedValues { get; set; }

        [JsonProperty("metadata", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public ParameterMetadata Metadata { get; set; }
    }

    [JsonObject]
    public class ParameterMetadata
    {
        [JsonProperty("description", Required = Required.Always)]
        public string Description { get; set; }
    }
}
