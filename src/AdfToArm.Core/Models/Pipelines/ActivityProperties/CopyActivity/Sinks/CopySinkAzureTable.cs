using Newtonsoft.Json;
using System;

namespace AdfToArm.Core.Models.Pipelines.ActivityProperties.CopyActivity.Sinks
{
    [JsonObject]
    public class CopySinkAzureTable : ICopySink
    {
        /// <summary>
        /// The type property of the copy activity sink must be set to: AzureTableSink
        /// </summary>
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        [JsonProperty("type", Required = Required.Always)]
        public CopySinkType Type { get; set; }

        /// <summary>
        /// Inserts data into the Azure table when the writeBatchSize or writeBatchTimeout is hit.
        /// 
        /// Default is 10000
        /// </summary>
        [ArmParameter("int")]
        [JsonProperty("writeBatchSize", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? WriteBatchSize { get; set; }

        /// <summary>
        /// Inserts data into the Azure table when the writeBatchSize or writeBatchTimeout is hit
        /// Default is “00:01:30” (90 sec).
        /// </summary>
        [ArmParameter]
        [JsonProperty("writeBatchTimeout", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public TimeSpan? WriteBatchTimeout { get; set; }

        /// <summary>
        /// Default partition key value that can be used by the sink.
        /// </summary>
        [ArmParameter]
        [JsonProperty("azureTableDefaultPartitionKeyValue", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string AzureTableDefaultPartitionKeyValue { get; set; }

        /// <summary>
        /// Specify name of the column whose values are used as partition keys. 
        /// If not specified, AzureTableDefaultPartitionKeyValue is used as the partition key.
        /// </summary>
        [ArmParameter]
        [JsonProperty("azureTablePartitionKeyName", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string AzureTablePartitionKeyName { get; set; }

        /// <summary>
        /// Specify name of the column whose column values are used as row key. If not specified, use a GUID for each row.
        /// </summary>
        [ArmParameter]
        [JsonProperty("azureTableRowKeyName", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string AzureTableRowKeyName { get; set; }

        /// <summary>
        /// The mode to insert data into Azure table.
        /// 
        /// This property controls whether existing rows in the output table with matching partition and row keys have their values "replaced" or "merged".
        /// 
        /// This setting applies at the row level, not the table level, and neither option deletes rows in the output table that do not exist in the input.
        /// </summary>
        [ArmParameter]
        [JsonProperty("azureTableInsertType", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string AzureTableInsertType { get; set; }
    }
}
