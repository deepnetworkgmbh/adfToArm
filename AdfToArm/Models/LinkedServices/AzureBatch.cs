using AdfToArm.Models.LinkedServices.LinkedServiceTypeProperties;
using Newtonsoft.Json;

namespace AdfToArm.Models.LinkedServices
{
    [JsonObject]
    public class AzureBatch : LinkedService
    {
        public AzureBatch()
        {
            Properties = new LinkedServiceProperties
            {
                Type = LinkedServiceType.AzureBatch,
                TypeProperties = new AzureBatchTypeProperties()
            };
        }

        public AzureBatch(string name) : this()
        {
            Name = name;
        }
    }
}
