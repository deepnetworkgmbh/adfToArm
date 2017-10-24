using Newtonsoft.Json;

namespace AdfToArm.Core.Models.Pipelines.ActivityProperties.CopyActivity.Sources
{
    [JsonObject]
    public class CopySourceAzureTable : ICopySource
    {
        /// <summary>
        /// The type property of the copy activity source must be set to: AzureTableSource
        /// </summary>
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        [JsonProperty("type", Required = Required.Always)]
        public CopySourceType Type { get; set; }

        /// <summary>
        /// Use the custom query to read data.
        /// 
        /// When a tableName is specified without an azureTableSourceQuery, all records from the table are copied to the destination. 
        /// If an azureTableSourceQuery is also specified, records from the table that satisfies the query are copied to the destination.
        /// </summary>
        [ArmParameter]
        [JsonProperty("azureTableSourceQuery", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string AzureTableSourceQuery { get; set; }

        /// <summary>
        /// Indicate whether swallow the exception of table not exist.
        /// </summary>
        [ArmParameter]
        [JsonProperty("azureTableSourceIgnoreTableNotFound", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool? AzureTableSourceIgnoreTableNotFound { get; set; }
    }
}
