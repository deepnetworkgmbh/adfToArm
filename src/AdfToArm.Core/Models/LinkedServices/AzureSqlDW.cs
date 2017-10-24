using AdfToArm.Core.Models.LinkedServices.LinkedServiceTypeProperties;
using Newtonsoft.Json;

namespace AdfToArm.Core.Models.LinkedServices
{
    [JsonObject]
    public class AzureSqlDW : LinkedService
    {
        public AzureSqlDW()
        {
            Properties = new LinkedServiceProperties
            {
                Type = LinkedServiceType.AzureSqlDW,
                TypeProperties = new AzureSqlDWTypeProperties()
            };
        }

        public AzureSqlDW(string name) : this()
        {
            Name = name;
        }
    }
}
