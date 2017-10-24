using Newtonsoft.Json;

namespace AdfToArm.Core.Models.LinkedServices.LinkedServiceTypeProperties
{
    [JsonObject]
    public class AzureSqlDWTypeProperties : ILinkedServiceProperties
    {
        /// <summary>
        /// Specify information needed to connect to the Azure SQL Data Warehouse instance for the connectionString property. 
        /// Only basic authentication is supported.
        /// </summary>
        [ArmParameter]
        [JsonProperty("connectionString", Required = Required.Always)]
        public string ConnectionString { get; set; }
    }
}
