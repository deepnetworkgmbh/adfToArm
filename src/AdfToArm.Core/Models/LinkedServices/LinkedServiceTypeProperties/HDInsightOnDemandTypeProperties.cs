using Newtonsoft.Json;
using System;

namespace AdfToArm.Core.Models.LinkedServices.LinkedServiceTypeProperties
{
    [JsonObject]
    public class HDInsightOnDemandTypeProperties : ILinkedServiceProperties
    {
        /// <summary>
        /// Number of worker/data nodes in the cluster. 
        /// The HDInsight cluster is created with 2 head nodes along with the number of worker nodes you specify for this property. 
        /// The nodes are of size Standard_D3 that has 4 cores, so a 4 worker node cluster takes 24 cores (4*4 = 16 cores for worker nodes, plus 2*4 = 8 cores for head nodes). 
        /// </summary>
        [ArmParameter("int")]
        [JsonProperty("clusterSize", Required = Required.Always)]
        public int ClusterSize { get; set; }

        /// <summary>
        /// The allowed idle time for the on-demand HDInsight cluster. 
        /// Specifies how long the on-demand HDInsight cluster stays alive after completion of an activity run if there are no other active jobs in the cluster.
        /// </summary>
        [ArmParameter]
        [JsonProperty("timetolive", Required = Required.Always)]
        public TimeSpan TimeToLive { get; set; }

        /// <summary>
        /// Version of the HDInsight cluster. The default value is 3.1 for Windows cluster and 3.2 for Linux cluster.
        /// </summary>
        [ArmParameter]
        [JsonProperty("version", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Version { get; set; }

        /// <summary>
        /// Azure Storage linked service to be used by the on-demand cluster for storing and processing data. 
        /// The HDInsight cluster is created in the same region as this Azure Storage account.
        /// </summary>
        [ArmParameter]
        [JsonProperty("linkedServiceName", Required = Required.Always)]
        public string LinkedServiceName { get; set; }

        /// <summary>
        /// Specifies additional storage accounts for the HDInsight linked service so that the Data Factory service can register them on your behalf. 
        /// These storage accounts must be in the same region as the HDInsight cluster, which is created in the same region as the storage account specified by linkedServiceName.
        /// </summary>
        [ArmParameter("array")]
        [JsonProperty("additionalLinkedServiceNames", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string[] AdditionalLinkedServiceNames { get; set; }

        /// <summary>
        /// Type of operating system. Allowed values are: Windows (default) and Linux
        /// </summary>
        [ArmParameter]
        [JsonProperty("osType", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string OsType { get; set; }

        /// <summary>
        /// The name of Azure SQL linked service that point to the HCatalog database. 
        /// The on-demand HDInsight cluster is created by using the Azure SQL database as the metastore.
        /// </summary>
        [ArmParameter]
        [JsonProperty("hcatalogLinkedServiceName", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string HcatalogLinkedServiceName { get; set; }

        /// <summary>
        /// Specifies the core configuration parameters (as in core-site.xml) for the HDInsight cluster to be created.
        /// </summary>
        [ArmParameter("object")]
        [JsonProperty("coreConfiguration", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public object CoreConfiguration { get; set; }

        /// <summary>
        /// Specifies the HBase configuration parameters (hbase-site.xml) for the HDInsight cluster.
        /// </summary>
        [ArmParameter("object")]
        [JsonProperty("hBaseConfiguration", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public object HBaseConfiguration { get; set; }

        /// <summary>
        /// Specifies the HDFS configuration parameters (hdfs-site.xml) for the HDInsight cluster.
        /// </summary>
        [ArmParameter("object")]
        [JsonProperty("hdfsConfiguration", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public object HdfsConfiguration { get; set; }

        /// <summary>
        /// Specifies the hive configuration parameters (hive-site.xml) for the HDInsight cluster.
        /// </summary>
        [ArmParameter("object")]
        [JsonProperty("hiveConfiguration", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public object HiveConfiguration { get; set; }

        /// <summary>
        /// Specifies the MapReduce configuration parameters (mapred-site.xml) for the HDInsight cluster.
        /// </summary>
        [ArmParameter("object")]
        [JsonProperty("mapReduceConfiguration", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public object MapReduceConfiguration { get; set; }

        /// <summary>
        /// Specifies the Oozie configuration parameters (oozie-site.xml) for the HDInsight cluster.
        /// </summary>
        [ArmParameter("object")]
        [JsonProperty("oozieConfiguration", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public object OozieConfiguration { get; set; }

        /// <summary>
        /// Specifies the Storm configuration parameters (storm-site.xml) for the HDInsight cluster.
        /// </summary>
        [ArmParameter("object")]
        [JsonProperty("stormConfiguration", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public object StormConfiguration { get; set; }

        /// <summary>
        /// Specifies the Yarn configuration parameters (yarn-site.xml) for the HDInsight cluster.
        /// </summary>
        [ArmParameter("object")]
        [JsonProperty("yarnConfiguration", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public object YarnConfiguration { get; set; }

        /// <summary>
        /// Specifies the size of the head node. The default value is: Standard_D3.
        /// </summary>
        [ArmParameter]
        [JsonProperty("headNodeSize", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string HeadNodeSize { get; set; }

        /// <summary>
        /// Specifies the size of the data node. The default value is: Standard_D3.
        /// </summary>
        [ArmParameter]
        [JsonProperty("dataNodeSize", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string DataNodeSize { get; set; }

        /// <summary>
        /// Specifies the size of the Zoo Keeper node. The default value is: Standard_D3.
        /// </summary>
        [ArmParameter]
        [JsonProperty("zookeeperNodeSize", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string ZookeeperNodeSize { get; set; }
    }
}
