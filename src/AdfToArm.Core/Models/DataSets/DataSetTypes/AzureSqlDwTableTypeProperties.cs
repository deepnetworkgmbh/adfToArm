using Newtonsoft.Json;

namespace AdfToArm.Core.Models.DataSets.DataSetTypes
{
    [JsonObject]
    public class AzureSqlDwTableTypeProperties : IDataSetTypeProperties
    {
        /// <summary>
        /// Name of the table or view in the Azure SQL Data Warehouse database that the linked service refers to.
        /// </summary>
        [ArmParameter]
        [JsonProperty("tableName", Required = Required.Always)]
        public string TableName { get; set; }
    }
}
