using AdfToArm.Core.Models.DataSets.DataSetTypes;
using Newtonsoft.Json;

namespace AdfToArm.Core.Models.DataSets
{
    [JsonObject]
    public class AzureCosmosDbCollection : DataSet
    {
        public AzureCosmosDbCollection()
        {
            Properties = new DataSetProperties
            {
                Type = DataSetType.CosmosDbCollection,
                TypeProperties = new AzureCosmosDbCollectionTypeProperties()
            };
        }

        public AzureCosmosDbCollection(string name) : this()
        {
            Name = name;
        }
    }
}
