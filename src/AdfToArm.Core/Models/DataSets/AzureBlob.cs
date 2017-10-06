using AdfToArm.Core.Models.DataSets.DataSetTypes;
using Newtonsoft.Json;

namespace AdfToArm.Core.Models.DataSets
{
    [JsonObject]
    public class AzureBlob : DataSet
    {
        public AzureBlob()
        {
            Properties = new DataSetProperties
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
