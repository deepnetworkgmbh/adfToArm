using AdfToArm.Core.Models.DataSets.DataSetTypes;
using Newtonsoft.Json;

namespace AdfToArm.Core.Models.DataSets
{
    [JsonObject]
    public class AzureSearchIndex : DataSet
    {
        public AzureSearchIndex()
        {
            Properties = new DataSetProperties
            {
                Type = DataSetType.AzureSearchIndex,
                TypeProperties = new AzureSearchIndexTypeProperties()
            };
        }

        public AzureSearchIndex(string name) : this()
        {
            Name = name;
        }
    }
}
