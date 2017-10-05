using Newtonsoft.Json;

namespace AdfToArm.Models.Pipelines.ActivityProperties.CopyActivity.Sources
{
    [JsonObject]
    public class CopySourceAzureSql : ICopySource
    {
        /// <summary>
        /// The type property of the copy activity source must be set to: SqlSource
        /// </summary>
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        [JsonProperty("type", Required = Required.Always)]
        public CopySourceType Type { get; set; }

        /// <summary>
        /// Use the custom SQL query to read data. Example: "select * from MyTable"
        /// </summary>
        [ArmParameter]
        [JsonProperty("sqlReaderQuery", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string SqlReaderQuery { get; set; }

        /// <summary>
        /// Name of the stored procedure that reads data from the source table. The last SQL statement must be a SELECT statement in the stored procedure.
        /// </summary>
        [ArmParameter]
        [JsonProperty("sqlReaderStoredProcedureName", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string SqlReaderStoredProcedureName { get; set; }

        /// <summary>
        /// Parameters for the stored procedure. 
        /// <example>
        /// "storedProcedureParameters": {
        ///         "stringData": { "value": "str3" },
        ///         "identifier": { "value": "$$Text.Format('{0:yyyy}', <datetime parameter>)", "type": "Int"}
        ///     }
        /// </example>
        /// </summary>
        [ArmParameter]
        [JsonProperty("storedProcedureParameters", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public object StoredProcedureParameters { get; set; }
    }
}
