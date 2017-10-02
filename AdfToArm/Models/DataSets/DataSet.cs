using AdfToArm.Models.DataSets.Common;
using AdfToArm.Models.DataSets.DataSetTypes;
using Newtonsoft.Json;

namespace AdfToArm.Models.DataSets
{
    public abstract class DataSet
    {
        public DataSet()
        {
            Schema = @"http://datafactories.schema.management.azure.com/internalschemas/2015-09-01/Microsoft.DataFactory.Table.json";
        }

        [JsonProperty("$schema", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Schema { get; set; }

        // TODO: https://docs.microsoft.com/en-us/azure/data-factory/v1/data-factory-naming-rules
        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty("properties", Required = Required.Always)]
        public DataSetProperties Properties { get; set; }
    }

    public class DataSetProperties
    {
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        [JsonProperty("type", Required = Required.Always)]
        public DataSetType Type { get; set; }

        /// <summary>
        /// Legacy Boolean flag.
        /// 
        /// Microsoft employee comment:
        /// "At this point, it is not used for anything and doesn't impact anything in ADF.  
        /// We will either retire it in a future rev, or consider lighting it up as a future feature to publish data to Azure Data Catalog or other services."
        /// </summary>
        [JsonProperty("published", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool? Published { get; set; }

        /// <summary>
        /// Boolean flag to specify whether a dataset is explicitly produced by a data factory pipeline or not.
        /// </summary>
        [JsonProperty("external", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool? External { get; set; }

        [JsonProperty("linkedServiceName", Required = Required.Always)]
        public string LinkedServiceName { get; set; }

        [JsonProperty("structure", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public StructureItem[] Structure { get; set; }

        [JsonProperty("typeProperties", Required = Required.Always)]
        public IDataSetTypeProperties TypeProperties { get; set; }

        /// <summary>
        /// Defines the processing window or the slicing model for the dataset production. 
        /// For details on the dataset slicing model, see <see href="https://docs.microsoft.com/en-us/azure/data-factory/v1/data-factory-scheduling-and-execution">Scheduling and Execution</see> article.
        /// </summary>
        [JsonProperty("availability", Required = Required.Always)]
        public Availability Availability { get; set; }

        /// <summary>
        /// Defines the criteria or the condition that the dataset slices must fulfill. 
        /// </summary>
        [JsonProperty("policy", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public Policy Policy { get; set; }
    }
}
