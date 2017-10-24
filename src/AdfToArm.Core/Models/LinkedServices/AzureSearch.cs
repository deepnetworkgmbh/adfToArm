using AdfToArm.Core.Models.LinkedServices.LinkedServiceTypeProperties;
using Newtonsoft.Json;

namespace AdfToArm.Core.Models.LinkedServices
{
    [JsonObject]
    public class AzureSearch : LinkedService
    {
        public AzureSearch()
        {
            Properties = new LinkedServiceProperties
            {
                Type = LinkedServiceType.AzureSearch,
                TypeProperties = new AzureSearchTypeProperties()
            };
        }

        public AzureSearch(string name) : this()
        {
            Name = name;
        }
    }
}
