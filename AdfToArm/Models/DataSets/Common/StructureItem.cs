using Newtonsoft.Json;

namespace AdfToArm.Models.DataSets.Common
{
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
        [JsonProperty("type", Required = Required.AllowNull)]
        public string Type { get; set; }

        /// <summary>
        /// .NET based culture to be used when type is specified and is .NET type Datetime or Datetimeoffset. Default is en-us.
        /// </summary>
        [JsonProperty("culture", Required = Required.AllowNull)]
        public string Culture { get; set; }

        /// <summary>
        /// Format string to be used when type is specified and is .NET type Datetime or Datetimeoffset.
        /// </summary>
        [JsonProperty("format", Required = Required.AllowNull)]
        public string Format { get; set; }
    }
}
