using AdfToArm.Core.Models.LinkedServices.LinkedServiceTypeProperties;
using Newtonsoft.Json;

namespace AdfToArm.Core.Models.LinkedServices
{
    [JsonObject]
    public class AzureDataLakeAnalytics : LinkedService
    {
        public AzureDataLakeAnalytics()
        {
            Properties = new LinkedServiceProperties
            {
                Type = LinkedServiceType.AzureDataLakeAnalytics,
                TypeProperties = new AzureDataLakeAnalyticsTypeProperties()
            };
        }

        public AzureDataLakeAnalytics(string name) : this()
        {
            Name = name;
        }
    }
}
