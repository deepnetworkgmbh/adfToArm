using Newtonsoft.Json;
using System;

namespace AdfToArm.Core.Models.Pipelines.ActivityProperties.CopyActivity.Sinks
{
    [JsonObject]
    public class CopySinkAzureSql : ICopySink
    {
        /// <summary>
        /// The type property of the copy activity sink must be set to: SqlSink
        /// </summary>
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        [JsonProperty("type", Required = Required.Always)]
        public CopySinkType Type { get; set; }

        /// <summary>
        /// Inserts data into the SQL table when the buffer size reaches writeBatchSize.
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
        /// Specify a column name for Copy Activity to fill with auto generated slice identifier, which is used to clean up data of a specific slice when rerun. 
        /// </summary>
        [ArmParameter]
        [JsonProperty("sliceIdentifierColumnName", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string SliceIdentifierColumnName { get; set; }

        /// <summary>
        /// Name of the stored procedure that upserts (updates/inserts) data into the target table.
        /// </summary>
        [ArmParameter]
        [JsonProperty("sqlWriterStoredProcedureName", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string SqlWriterStoredProcedureName { get; set; }

        /// <summary>
        /// Parameters for the stored procedure.
        /// Allowed values are: name/value pairs.Names and casing of parameters must match the names and casing of the stored procedure parameters.
        /// </summary>
        [ArmParameter("object")]
        [JsonProperty("storedProcedureParameters", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public object StoredProcedureParameters { get; set; }

        /// <summary>
        /// Specify a table type name to be used in the stored procedure. 
        /// Copy activity makes the data being moved available in a temp table with this table type. 
        /// Stored procedure code can then merge the data being copied with existing data.
        /// </summary>
        [ArmParameter]
        [JsonProperty("sqlWriterTableType", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string SqlWriterTableType { get; set; }
    }
}
