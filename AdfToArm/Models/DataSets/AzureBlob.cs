using AdfToArm.Models.DataSets.DataSetTypes;
using Newtonsoft.Json;

namespace AdfToArm.Models.DataSets
{
    [JsonObject]
    public class AzureBlob : DataSet<AzureBlobTypeProperties>
    {
        public AzureBlob()
        {
            Properties = new DataSetProperties<AzureBlobTypeProperties>
            {
                Type = DataSetType.AzureBlob,
                TypeProperties = new AzureBlobTypeProperties()
            };
        }

        public AzureBlob(string name) : this()
        {
            Name = name;
        }
    }
}
