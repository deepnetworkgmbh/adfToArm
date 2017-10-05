using Newtonsoft.Json;

namespace AdfToArm.Models.Pipelines.ActivityProperties.CopyActivity.Sources
{
    [JsonObject]
    public class CopySourceBlob : ICopySource
    {
        /// <summary>
        /// The type property of the copy activity source must be set to: BlobSource
        /// </summary>
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        [JsonProperty("type", Required = Required.Always)]
        public CopySourceType Type { get; set; }

        /// <summary>
        /// Indicates whether the data is read recursively from the sub folders or only from the specified folder.
        /// </summary>
        [JsonProperty("recursive", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool? Recursive { get; set; }
    }
}
