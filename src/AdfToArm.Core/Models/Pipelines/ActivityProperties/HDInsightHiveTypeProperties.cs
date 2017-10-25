using AdfToArm.Core.Models.Common;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace AdfToArm.Core.Models.Pipelines.ActivityProperties
{
    [JsonObject]
    public class HDInsightHiveTypeProperties :  IActivityTypeProperties
    {
        /// <summary>
        /// Specify the Hive script inline
        /// </summary>
        [ArmParameter]
        [JsonProperty("script", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Script { get; set; }

        /// <summary>
        /// Store the Hive script in an Azure blob storage and provide the path to the file. 
        /// Use 'script' or 'scriptPath' property. Both cannot be used together. 
        /// The file name is case-sensitive.
        /// </summary>
        [ArmParameter]
        [JsonProperty("scriptPath", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string ScriptPath { get; set; }

        /// <summary>
        /// Azure Storage account with saved Hive script
        /// </summary>
        [ArmParameter]
        [JsonProperty("scriptLinkedService", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string ScriptLinkedService { get; set; }

        /// <summary>
        /// Specify parameters as key/value pairs for referencing within the Hive script using 'hiveconf'
        /// </summary>
        [ArmParameter("object")]
        [JsonConverter(typeof(PairConverter))]
        [JsonProperty("defines", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public KeyValuePair<string, string>[] Defines { get; set; }
    }
}
