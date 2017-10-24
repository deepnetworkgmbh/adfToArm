using Newtonsoft.Json;

namespace AdfToArm.Core.Models.DataSets.DataSetTypes
{
    [JsonObject]
    public class AzureTableTypeProperties : IDataSetTypeProperties
    {
        /// <summary>
        /// Name of the table in the Azure Table Database instance that linked service refers to.
        /// </summary>
        [ArmParameter]
        [JsonProperty("tableName", Required = Required.Always)]
        public string TableName { get; set; }
    }
}
