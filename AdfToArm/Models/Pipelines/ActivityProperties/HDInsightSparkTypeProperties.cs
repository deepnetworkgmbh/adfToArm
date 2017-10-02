using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace AdfToArm.Models.Pipelines.ActivityProperties
{
    [JsonObject]
    public class HDInsightSparkTypeProperties :  IActivityTypeProperties
    {
        /// <summary>
        /// The Azure Blob container and folder that contains the Spark file. The file name is case-sensitive.
        /// </summary>
        [JsonProperty("rootPath", Required = Required.Always)]
        public string RootPath { get; set; }

        /// <summary>
        /// Relative path to the root folder of the Spark code/package.
        /// </summary>
        [JsonProperty("entryFilePath", Required = Required.Always)]
        public string EntryFilePath { get; set; }

        /// <summary>
        /// Application's Java/Spark main class
        /// </summary>
        [JsonProperty("className", Required = Required.AllowNull)]
        public string ClassName { get; set; }

        /// <summary>
        /// A list of command-line arguments to the Spark program.
        /// </summary>
        [JsonProperty("arguments", Required = Required.AllowNull)]
        public string[] Arguments { get; set; }

        /// <summary>
        /// The user account to impersonate to execute the Spark program
        /// </summary>
        [JsonProperty("proxyUser", Required = Required.AllowNull)]
        public string ProxyUser { get; set; }

        /// <summary>
        /// Spark configuration properties.
        /// </summary>
        [JsonProperty("sparkConfig", Required = Required.AllowNull)]
        public string SparkConfig { get; set; }

        /// <summary>
        /// Specifies when the Spark log files are copied to the Azure storage used by HDInsight cluster (or) specified by sparkJobLinkedService. 
        /// Allowed values: None, Always, or Failure. Default value: None.
        /// </summary>
        [JsonProperty("getDebugInfo", Required = Required.AllowNull)]
        public GetDebugInfo GetDebugInfo { get; set; }

        /// <summary>
        /// The Azure Storage linked service that holds the Spark job file, dependencies, and logs. 
        /// If you do not specify a value for this property, the storage associated with HDInsight cluster is used.
        /// </summary>
        [JsonProperty("sparkJobLinkedService", Required = Required.AllowNull)]
        public string SparkJobLinkedService { get; set; }
    }

    public enum GetDebugInfo
    {
        [EnumMember(Value = "None")]
        None,
        [EnumMember(Value = "Always")]
        Always,
        [EnumMember(Value = "Failure")]
        Failure
    }
}
