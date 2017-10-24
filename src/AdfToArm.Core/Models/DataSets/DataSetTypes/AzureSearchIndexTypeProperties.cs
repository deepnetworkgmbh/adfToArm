using Newtonsoft.Json;

namespace AdfToArm.Core.Models.DataSets.DataSetTypes
{
    [JsonObject]
    public class AzureSearchIndexTypeProperties : IDataSetTypeProperties
    {
        /// <summary>
        /// Name of the Azure Search index. Data Factory does not create the index. 
        /// The index must exist in Azure Search.
        /// </summary>
        [ArmParameter]
        [JsonProperty("indexName", Required = Required.Always)]
        public string IndexName { get; set; }
    }
}
