using Newtonsoft.Json;
using System;

namespace AdfToArm.Core.Models.Pipelines.ActivityProperties.CopyActivity.Sinks
{
    [JsonObject]
    public class CopySinkAzureCosmosCollection : ICopySink
    {
        /// <summary>
        /// The type property of the copy activity sink must be set to: DocumentDbCollectionSink
        /// </summary>
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        [JsonProperty("type", Required = Required.Always)]
        public CopySinkType Type { get; set; }

        /// <summary>
        /// Inserts data into the Azure table when the writeBatchSize or writeBatchTimeout is hit.
        /// 
        /// Default is 5
        /// </summary>
        [ArmParameter("int")]
        [JsonProperty("writeBatchSize", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? WriteBatchSize { get; set; }

        /// <summary>
        /// Inserts data into the Azure table when the writeBatchSize or writeBatchTimeout is hit
        /// </summary>
        [ArmParameter]
        [JsonProperty("writeBatchTimeout", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public TimeSpan? WriteBatchTimeout { get; set; }

        /// <summary>
        /// A special character in the source column name to indicate that nested document is needed. 
        /// For example: Name.First
        /// </summary>
        [ArmParameter]
        [JsonProperty("nestingSeparator", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string NestingSeparator { get; set; }
    }
}
