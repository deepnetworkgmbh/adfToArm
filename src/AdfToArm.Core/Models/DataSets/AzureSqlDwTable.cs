using AdfToArm.Core.Models.DataSets.DataSetTypes;
using Newtonsoft.Json;

namespace AdfToArm.Core.Models.DataSets
{
    [JsonObject]
    public class AzureSqlDwTable : DataSet
    {
        public AzureSqlDwTable()
        {
            Properties = new DataSetProperties
            {
                Type = DataSetType.AzureSqlDwTable,
                TypeProperties = new AzureSqlDwTableTypeProperties()
            };
        }

        public AzureSqlDwTable(string name) : this()
        {
            Name = name;
        }
    }
}
