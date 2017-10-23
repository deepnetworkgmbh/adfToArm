using AdfToArm.Core.Models.Common;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace AdfToArm.Core.Models.Pipelines.ActivityProperties
{
    [JsonObject]
    public class DataLakeAnalyticsUsqlTypeProperties : IActivityTypeProperties
    {
        /// <summary>
        /// Path to folder that contains the U-SQL script. Name of the file is case-sensitive.
        /// 
        /// Not required if script is used
        /// </summary>
        [ArmParameter]
        [JsonProperty("scriptPath", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string ScriptPath { get; set; }

        /// <summary>
        /// Linked service that links the storage that contains the script to the data factory
        /// 
        /// Not required if script is used
        /// </summary>
        [ArmParameter]
        [JsonProperty("scriptLinkedService", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string ScriptLinkedService { get; set; }

        /// <summary>
        /// Specify inline script instead of specifying scriptPath and scriptLinkedService. For example: "script": "CREATE DATABASE test".
        /// 
        /// Not required if scriptPath and scriptLinkedService are used
        /// </summary>
        [ArmParameter]
        [JsonProperty("script", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Script { get; set; }

        /// <summary>
        /// The maximum number of nodes simultaneously used to run the job.
        /// </summary>
        [ArmParameter("int")]
        [JsonProperty("degreeOfParallelism", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? DegreeOfParallelism { get; set; }

        /// <summary>
        /// Determines which jobs out of all that are queued should be selected to run first. The lower the number, the higher the priority.
        /// </summary>
        [ArmParameter("int")]
        [JsonProperty("priority", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? Priority { get; set; }

        /// <summary>
        /// Parameters for the U-SQL script
        /// </summary>
        [ArmParameter("object")]
        [JsonConverter(typeof(PairConverter))]
        [JsonProperty("parameters", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public KeyValuePair<string, string>[] Parameters { get; set; }

        /// <summary>
        /// Runtime version of the U-SQL engine to use
        /// </summary>
        [ArmParameter]
        [JsonProperty("runtimeVersion", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string RuntimeVersion { get; set; }

        /// <summary>
        /// Compilation mode of U-SQL. Must be one of these values:
        /// * Semantic: Only perform semantic checks and necessary sanity checks.
        /// * Full: Perform the full compilation, including syntax check, optimization, code generation, etc.
        /// * SingleBox: Perform the full compilation, with TargetType setting to SingleBox.
        /// 
        /// If you don't specify a value for this property, the server determines the optimal compilation mode.
        /// </summary>
        [ArmParameter]
        [JsonProperty("compilationMode", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string CompilationMode { get; set; }
    }
}
