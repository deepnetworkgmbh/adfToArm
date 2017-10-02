using AdfToArm.Models.LinkedServices.LinkedServiceTypeProperties;
using Newtonsoft.Json;

namespace AdfToArm.Models.LinkedServices
{
    [JsonObject]
    public class HDInsight : LinkedService
    {
        public HDInsight()
        {
            Properties = new LinkedServiceProperties
            {
                Type = LinkedServiceType.HDInsight,
                TypeProperties = new HDInsightTypeProperties()
            };
        }

        public HDInsight(string name): this()
        {
            Name = name;
        }
    }
}
