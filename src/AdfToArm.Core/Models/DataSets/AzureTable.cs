using AdfToArm.Core.Models.DataSets.DataSetTypes;
using Newtonsoft.Json;

namespace AdfToArm.Core.Models.DataSets
{
    [JsonObject]
    public class AzureTable : DataSet
    {
        public AzureTable()
        {
            Properties = new DataSetProperties
            {
                Type = DataSetType.AzureTable,
                TypeProperties = new AzureTableTypeProperties()
            };
        }

        public AzureTable(string name) : this()
        {
            Name = name;
        }
    }
}
