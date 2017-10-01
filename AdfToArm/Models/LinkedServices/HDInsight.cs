using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AdfToArm.Models.LinkedServices
{
    [JsonObject]
    public class HDInsight
    {
        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty("properties", Required = Required.Always)]
        public HDInsightProperties Properties { get; set; }
    }

    [JsonObject]
    public class HDInsightProperties
    {
        public HDInsightProperties()
        {
            Type = LinkedService.HDInsight;
        }

        /// <summary>
        /// The type property should be set to HDInsight.
        /// </summary>
        [JsonProperty("type", Required = Required.Always)]
        [JsonConverter(typeof(StringEnumConverter))]
        public LinkedService Type { get; }

        [JsonProperty("typeProperties", Required = Required.Always)]
        public HDInsightTypeProperties TypeProperties { get; set; }
    }

    [JsonObject]
    public class HDInsightTypeProperties
    {
        /// <summary>
        /// The URI of the HDInsight cluster.
        /// </summary>
        [JsonProperty("clusterUri", Required = Required.Always)]
        public string ClusterUri { get; set; }

        /// <summary>
        /// Specify the name of the user to be used to connect to an existing HDInsight cluster.
        /// </summary>
        [JsonProperty("userName", Required = Required.Always)]
        public string UserName { get; set; }

        /// <summary>
        /// Specify password for the user account.
        /// </summary>
        [JsonProperty("password", Required = Required.Always)]
        public string Password { get; set; }

        /// <summary>
        /// Name of the Azure Storage linked service that refers to the Azure blob storage used by the HDInsight cluster.
        /// 
        /// Currently, you cannot specify an Azure Data Lake Store linked service for this property.
        /// You may access data in the Azure Data Lake Store from Hive/Pig scripts if the HDInsight cluster has access to the Data Lake Store.
        /// </summary>
        [JsonProperty("linkedServiceName", Required = Required.Always)]
        public string LinkedServiceName { get; set; }
    }
}
