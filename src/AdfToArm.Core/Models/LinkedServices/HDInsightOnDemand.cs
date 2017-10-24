using AdfToArm.Core.Models.LinkedServices.LinkedServiceTypeProperties;
using Newtonsoft.Json;

namespace AdfToArm.Core.Models.LinkedServices
{
    [JsonObject]
    public class HDInsightOnDemand : LinkedService
    {
        public HDInsightOnDemand()
        {
            Properties = new LinkedServiceProperties
            {
                Type = LinkedServiceType.HDInsightOnDemand,
                TypeProperties = new HDInsightOnDemandTypeProperties()
            };
        }

        public HDInsightOnDemand(string name): this()
        {
            Name = name;
        }
    }
}
