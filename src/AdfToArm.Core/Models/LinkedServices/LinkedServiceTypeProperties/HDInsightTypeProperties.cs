using Newtonsoft.Json;

namespace AdfToArm.Core.Models.LinkedServices.LinkedServiceTypeProperties
{
    [JsonObject]
    public class HDInsightTypeProperties : ILinkedServiceProperties
    {
        /// <summary>
        /// The URI of the HDInsight cluster.
        /// </summary>
        [ArmParameter]
        [JsonProperty("clusterUri", Required = Required.Always)]
        public string ClusterUri { get; set; }

        /// <summary>
        /// Specify the name of the user to be used to connect to an existing HDInsight cluster.
        /// </summary>
        [ArmParameter]
        [JsonProperty("userName", Required = Required.Always)]
        public string UserName { get; set; }

        /// <summary>
        /// Specify password for the user account.
        /// </summary>
        [ArmParameter]
        [JsonProperty("password", Required = Required.Always)]
        public string Password { get; set; }

        /// <summary>
        /// Name of the Azure Storage linked service that refers to the Azure blob storage used by the HDInsight cluster.
        /// 
        /// Currently, you cannot specify an Azure Data Lake Store linked service for this property.
        /// You may access data in the Azure Data Lake Store from Hive/Pig scripts if the HDInsight cluster has access to the Data Lake Store.
        /// </summary>
        [ArmParameter]
        [JsonProperty("linkedServiceName", Required = Required.Always)]
        public string LinkedServiceName { get; set; }
    }
}
