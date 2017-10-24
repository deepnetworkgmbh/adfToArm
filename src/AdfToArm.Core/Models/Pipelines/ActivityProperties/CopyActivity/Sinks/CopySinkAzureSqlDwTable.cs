using Newtonsoft.Json;
using System;

namespace AdfToArm.Core.Models.Pipelines.ActivityProperties.CopyActivity.Sinks
{
    [JsonObject]
    public class CopySinkAzureSqlDwTable : ICopySink
    {
        /// <summary>
        /// The type property of the copy activity sink must be set to: SqlDWSink
        /// </summary>
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        [JsonProperty("type", Required = Required.Always)]
        public CopySinkType Type { get; set; }

        /// <summary>
        /// Inserts data into the SQL table when the buffer size reaches writeBatchSize.
        /// 
        /// Default is 10000
        /// </summary>
        [ArmParameter("int")]
        [JsonProperty("writeBatchSize", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? WriteBatchSize { get; set; }

        /// <summary>
        /// Wait time for the batch insert operation to complete before it times out.
        /// Example: “00:30:00” (30 minutes).
        /// </summary>
        [ArmParameter]
        [JsonProperty("writeBatchTimeout", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public TimeSpan? WriteBatchTimeout { get; set; }

        /// <summary>
        /// Specify a query for Copy Activity to execute such that data of a specific slice is cleaned up.
        /// </summary>
        [ArmParameter]
        [JsonProperty("sqlWriterCleanupScript", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string SqlWriterCleanupScript { get; set; }

        /// <summary>
        /// Indicates whether to use PolyBase (when applicable) instead of BULKINSERT mechanism. 
        /// 
        /// Using PolyBase is the recommended way to load data into SQL Data Warehouse.
        /// </summary>
        [ArmParameter]
        [JsonProperty("allowPolyBase", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool? AllowPolyBase { get; set; }

        /// <summary>
        /// A group of properties that can be specified when the allowPolybase property is set to true.
        /// </summary>
        [ArmParameter("object")]
        [JsonProperty("polyBaseSettings", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public PolyBaseSettings PolyBaseSettings { get; set; }
    }

    [JsonObject]
    public class PolyBaseSettings
    {
        /// <summary>
        /// Specifies the number or percentage of rows that can be rejected before the query fails. 
        /// </summary>
        [JsonProperty("rejectValue", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? RejectValue { get; set; }

        /// <summary>
        /// Specifies whether the rejectValue option is specified as a literal value or a percentage.
        /// 
        /// Allowed values: Value (default), Percentage
        /// </summary>
        [JsonProperty("rejectType", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string RejectType { get; set; }

        /// <summary>
        /// Determines the number of rows to retrieve before the PolyBase recalculates the percentage of rejected rows.
        /// 
        /// Required if RejectType is Percentage
        /// </summary>
        [JsonProperty("rejectSampleValue", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? RejectSampleValue { get; set; }

        /// <summary>
        /// Specifies how to handle missing values in delimited text files when PolyBase retrieves data from the text file.
        /// </summary>
        [JsonProperty("useTypeDefault", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool? UseTypeDefault { get; set; }
    }
}
