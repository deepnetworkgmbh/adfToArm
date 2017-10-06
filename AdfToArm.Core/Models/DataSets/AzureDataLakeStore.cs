using AdfToArm.Core.Models.DataSets.DataSetTypes;
using Newtonsoft.Json;

namespace AdfToArm.Core.Models.DataSets
{
    [JsonObject]
    public class AzureDataLakeStore : DataSet
    {
        public AzureDataLakeStore()
        {
            Properties = new DataSetProperties
            {
                Type = DataSetType.AzureDataLakeStore,
                TypeProperties = new AzureDataLakeStoreTypeProperties()
            };
        }

        public AzureDataLakeStore(string name) : this()
        {
            Name = name;
        }
    }
}
