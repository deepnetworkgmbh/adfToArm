using Newtonsoft.Json;

namespace AdfToArm.Core.Models.DataSets.DataSetTypes
{
    [JsonObject]
    public class AzureCosmosDbCollectionTypeProperties : IDataSetTypeProperties
    {
        /// <summary>
        /// Name of the Cosmos DB document collection.
        /// </summary>
        [ArmParameter]
        [JsonProperty("collectionName", Required = Required.Always)]
        public string CollectionName { get; set; }
    }
}
