using Newtonsoft.Json;

namespace AdfToArm.Core.Models.Pipelines.ActivityProperties
{
    [JsonObject]
    public class HDInsightStreamingTypeProperties :  IActivityTypeProperties
    {
        /// <summary>
        /// The name of mapper executable
        /// </summary>
        [ArmParameter]
        [JsonProperty("mapper", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Mapper { get; set; }

        /// <summary>
        /// The name of reducer executable
        /// </summary>
        [ArmParameter]
        [JsonProperty("reducer", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Reducer { get; set; }

        /// <summary>
        /// The input file (including the location) for the mapper 
        /// </summary>
        [ArmParameter]
        [JsonProperty("input", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Input { get; set; }

        /// <summary>
        /// The output file (including the location) for the reducer.  
        /// </summary>
        [ArmParameter]
        [JsonProperty("output", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Output { get; set; }

        /// <summary>
        /// The paths for the mapper and reducer executables. 
        /// </summary>
        [ArmParameter("array")]
        [JsonProperty("filePaths", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string[] FilePaths { get; set; }

        /// <summary>
        /// Specify the Azure Storage linked service that represents the Azure storage that contains the files specified in the filePaths section.
        /// </summary>
        [ArmParameter]
        [JsonProperty("fileLinkedService", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string FileLinkedService { get; set; }

        /// <summary>
        /// When it is set to Failure, the logs are downloaded only on failure. 
        /// When it is set to Always, logs are always downloaded irrespective of the execution status.
        /// </summary>
        [ArmParameter]
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        [JsonProperty("getDebugInfo", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public GetDebugInfo? GetDebugInfo { get; set; }

        /// <summary>
        /// The arguments for the streaming job
        /// </summary>
        [ArmParameter("array")]
        [JsonProperty("arguments", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string[] Arguments { get; set; }
    }
}
