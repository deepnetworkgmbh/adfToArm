using Newtonsoft.Json;

namespace AdfToArm.Core.Models.DataSets.Common
{
    // TODO: Validate, that format used only for DateTime and TimeSpan
    [JsonObject]
    public class StructureItem
    {
        /// <summary>
        /// Name of the column.
        /// </summary>
        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }

        /// <summary>
        /// Data type of the column
        /// </summary>
        [JsonProperty("type", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        /// <summary>
        /// .NET based culture to be used when type is specified and is .NET type Datetime or Datetimeoffset. Default is en-us.
        /// </summary>
        [JsonProperty("culture", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Culture { get; set; }

        /// <summary>
        /// Format string to be used when type is specified and is .NET type Datetime or TimeSpan.
        /// </summary>
        [JsonProperty("format", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Format { get; set; }
    }
}
