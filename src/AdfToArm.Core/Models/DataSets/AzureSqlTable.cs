using AdfToArm.Core.Models.DataSets.DataSetTypes;
using Newtonsoft.Json;

namespace AdfToArm.Core.Models.DataSets
{
    [JsonObject]
    public class AzureSqlTable : DataSet
    {
        public AzureSqlTable()
        {
            Properties = new DataSetProperties
            {
                Type = DataSetType.AzureSqlTable,
                TypeProperties = new AzureSqlTableTypeProperties()
            };
        }

        public AzureSqlTable(string name) : this()
        {
            Name = name;
        }
    }
}
