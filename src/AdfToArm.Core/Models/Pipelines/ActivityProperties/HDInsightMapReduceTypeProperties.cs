using Newtonsoft.Json;

namespace AdfToArm.Core.Models.Pipelines.ActivityProperties
{
    [JsonObject]
    public class HDInsightMapReduceTypeProperties :  IActivityTypeProperties
    {
        /// <summary>
        /// Name of the class
        /// </summary>
        [ArmParameter]
        [JsonProperty("className", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string ClassName { get; set; }

        /// <summary>
        /// Path to the jar file containing the class.
        /// </summary>
        [ArmParameter]
        [JsonProperty("jarFilePath", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string JarFilePath { get; set; }

        /// <summary>
        /// Azure Storage linked service that contains the jar file. 
        /// This linked service refers to the storage that is associated with the HDInsight cluster.
        /// </summary>
        [ArmParameter]
        [JsonProperty("jarLinkedService", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string JarLinkedService { get; set; }
        
        [ArmParameter("array")]
        [JsonProperty("arguments", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string[] Arguments { get; set; }
    }
}
