using AdfToArm.Models.DataSets.DataSetTypes;
using Newtonsoft.Json;

namespace AdfToArm.Models.DataSets
{
    [JsonObject]
    public class AzureDataLakeStore : DataSet<AzureDataLakeStoreTypeProperties>
    {
        public AzureDataLakeStore()
        {
            Properties = new DataSetProperties<AzureDataLakeStoreTypeProperties>
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
