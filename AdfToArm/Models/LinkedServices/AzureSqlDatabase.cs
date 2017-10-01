using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AdfToArm.Models.LinkedServices
{
    [JsonObject]
    public class AzureSqlDatabase
    {
        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty("properties", Required = Required.Always)]
        public AzureSqlDatabaseProperties Properties { get; set; }
    }

    public class AzureSqlDatabaseProperties
    {
        public AzureSqlDatabaseProperties()
        {
            Type = LinkedService.AzureSqlDatabase;
        }

        [JsonProperty("type", Required = Required.Always)]
        [JsonConverter(typeof(StringEnumConverter))]
        public LinkedService Type { get; }

        [JsonProperty("typeProperties", Required = Required.Always)]
        public AzureSqlDatabaseTypeProperties TypeProperties { get; set; }
    }

    public class AzureSqlDatabaseTypeProperties
    {
        [JsonProperty("connectionString", Required = Required.Always)]
        public string ConnectionString { get; set; }
    }
}
