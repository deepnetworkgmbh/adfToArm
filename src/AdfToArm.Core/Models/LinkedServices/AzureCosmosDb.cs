using AdfToArm.Core.Models.LinkedServices.LinkedServiceTypeProperties;
using Newtonsoft.Json;

namespace AdfToArm.Core.Models.LinkedServices
{
    [JsonObject]
    public class AzureCosmosDb : LinkedService
    {
        public AzureCosmosDb()
        {
            Properties = new LinkedServiceProperties
            {
                Type = LinkedServiceType.AzureCosmosDb,
                TypeProperties = new AzureCosmosDbTypeProperties()
            };
        }

        public AzureCosmosDb(string name) : this()
        {
            Name = name;
        }
    }
}
