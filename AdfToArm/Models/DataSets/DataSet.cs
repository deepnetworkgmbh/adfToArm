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

        [JsonProperty("$schema", Required = Required.Default)]
        public string Schema { get; set; }

        // TODO: https://docs.microsoft.com/en-us/azure/data-factory/v1/data-factory-naming-rules
        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty("properties", Required = Required.Always)]
        public DataSetProperties Properties { get; set; }
    }

    public class DataSetProperties
    {
        [JsonProperty("type", Required = Required.Always)]
        public DataSetType Type { get; set; }

        /// <summary>
        /// Boolean flag to specify whether a dataset is explicitly produced by a data factory pipeline or not.
        /// </summary>
        [JsonProperty("external", Required = Required.Default)]
        public bool? External { get; set; }

        [JsonProperty("linkedServiceName", Required = Required.Always)]
        public string LinkedServiceName { get; set; }

        [JsonProperty("structure", Required = Required.Default)]
        public StructureItem[] Structure { get; set; }

        //[JsonConverter(typeof(DatasetTypeConverter))]
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
        [JsonProperty("policy", Required = Required.Default)]
        public Policy Policy { get; set; }
    }
}
