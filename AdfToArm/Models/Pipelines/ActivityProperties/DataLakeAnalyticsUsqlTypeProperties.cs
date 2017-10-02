using AdfToArm.Common;
using AdfToArm.Models.Pipelines.Common;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace AdfToArm.Models.Pipelines.ActivityProperties
{
    [JsonObject]
    public class DataLakeAnalyticsUsqlTypeProperties : IActivityTypeProperties
    {
        /// <summary>
        /// Path to folder that contains the U-SQL script. Name of the file is case-sensitive.
        /// 
        /// Not required if script is used
        /// </summary>
        [JsonProperty("scriptPath", Required = Required.Default)]
        public string ScriptPath { get; set; }

        /// <summary>
        /// Linked service that links the storage that contains the script to the data factory
        /// 
        /// Not required if script is used
        /// </summary>
        [JsonProperty("scriptLinkedService", Required = Required.Default)]
        public string ScriptLinkedService { get; set; }

        /// <summary>
        /// Specify inline script instead of specifying scriptPath and scriptLinkedService. For example: "script": "CREATE DATABASE test".
        /// 
        /// Not required if scriptPath and scriptLinkedService are used
        /// </summary>
        [JsonProperty("script", Required = Required.Default)]
        public string Script { get; set; }

        /// <summary>
        /// The maximum number of nodes simultaneously used to run the job.
        /// </summary>
        [JsonProperty("degreeOfParallelism", Required = Required.Default)]
        public int? DegreeOfParallelism { get; set; }

        /// <summary>
        /// Determines which jobs out of all that are queued should be selected to run first. The lower the number, the higher the priority.
        /// </summary>
        [JsonProperty("priority", Required = Required.Default)]
        public int? Priority { get; set; }

        /// <summary>
        /// Parameters for the U-SQL script
        /// </summary>
        [JsonConverter(typeof(PairConverter))]
        [JsonProperty("parameters", Required = Required.Default)]
        public KeyValuePair<string, string>[] Parameters { get; set; }
    }
}
