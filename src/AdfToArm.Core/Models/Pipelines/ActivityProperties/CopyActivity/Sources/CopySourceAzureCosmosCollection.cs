using Newtonsoft.Json;

namespace AdfToArm.Core.Models.Pipelines.ActivityProperties.CopyActivity.Sources
{
    [JsonObject]
    public class CopySourceAzureCosmosCollection : ICopySource
    {
        /// <summary>
        /// The type property of the copy activity source must be set to: DocumentDbCollectionSource
        /// </summary>
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        [JsonProperty("type", Required = Required.Always)]
        public CopySourceType Type { get; set; }

        /// <summary>
        /// Specify the query to read data.
        /// </summary>
        [ArmParameter]
        [JsonProperty("query", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Query { get; set; }

        /// <summary>
        /// Special character to indicate that the document is nested
        /// </summary>
        [ArmParameter]
        [JsonProperty("nestingSeparator", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string NestingSeparator { get; set; }
    }
}
