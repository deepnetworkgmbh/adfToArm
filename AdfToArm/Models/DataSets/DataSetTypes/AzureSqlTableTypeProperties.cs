using Newtonsoft.Json;

namespace AdfToArm.Models.DataSets.DataSetTypes
{
    [JsonObject]
    public class AzureSqlTableTypeProperties : IDataSetTypeProperties
    {
        /// <summary>
        /// Name of the table or view in the Azure SQL Database instance that linked service refers to.
        /// </summary>
        [ArmParameter]
        [JsonProperty("tableName", Required = Required.Always)]
        public string TableName { get; set; }
    }
}
