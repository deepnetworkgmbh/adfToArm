using Newtonsoft.Json;

namespace AdfToArm.Core.Models.Pipelines.ActivityProperties.CopyActivity.Sinks
{
    [JsonObject]
    public class CopySinkAzureSearchIndex : ICopySink
    {
        /// <summary>
        /// The type property of the copy activity sink must be set to: AzureSearchIndexSink
        /// </summary>
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        [JsonProperty("type", Required = Required.Always)]
        public CopySinkType Type { get; set; }

        /// <summary>
        /// Uploads data into the Azure Search index when the buffer size reaches writeBatchSize.
        /// 
        /// Allowed values: 1 to 1000. Default is 1000
        /// </summary>
        [ArmParameter("int")]
        [JsonProperty("WriteBatchSize", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? WriteBatchSize { get; set; }


        /// <summary>
        /// Specifies whether to merge or replace when a document already exists in the index.
        /// 
        /// Allowed values: Merge (default) and Upload
        /// </summary>
        [ArmParameter]
        [JsonProperty("WriteBehavior", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string WriteBehavior { get; set; }
    }
}
