using AdfToArm.Models.LinkedServices.LinkedServiceTypeProperties;
using Newtonsoft.Json;

namespace AdfToArm.Models.LinkedServices
{
    [JsonObject]
    public class AzureSqlDatabase : LinkedService
    {
        public AzureSqlDatabase()
        {
            Properties = new LinkedServiceProperties
            {
                Type = LinkedServiceType.AzureSqlDatabase,
                TypeProperties = new AzureSqlDatabaseTypeProperties()
            };
        }

        public AzureSqlDatabase(string name) : this()
        {
            Name = name;
        }
    }
}
