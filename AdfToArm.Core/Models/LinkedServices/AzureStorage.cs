using AdfToArm.Core.Models.LinkedServices.LinkedServiceTypeProperties;
using Newtonsoft.Json;

namespace AdfToArm.Core.Models.LinkedServices
{
    [JsonObject]
    public class AzureStorage : LinkedService
    {
        public AzureStorage()
        {
            Properties = new LinkedServiceProperties
            {
                Type = LinkedServiceType.AzureStorage,
                TypeProperties = new AzureStorageTypeProperties()
            };
        }

        public AzureStorage(string name) : this()
        {
            Name = name;
        }
    }
}
