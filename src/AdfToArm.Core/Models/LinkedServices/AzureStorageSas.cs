using AdfToArm.Core.Models.LinkedServices.LinkedServiceTypeProperties;
using Newtonsoft.Json;

namespace AdfToArm.Core.Models.LinkedServices
{
    [JsonObject]
    public class AzureStorageSas : LinkedService
    {
        public AzureStorageSas()
        {
            Properties = new LinkedServiceProperties
            {
                Type = LinkedServiceType.AzureStorageSas,
                TypeProperties = new AzureStorageSasTypeProperties()
            };
        }

        public AzureStorageSas(string name) : this()
        {
            Name = name;
        }
    }
}
