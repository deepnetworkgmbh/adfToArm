using AdfToArm.Core.Models.LinkedServices.LinkedServiceTypeProperties;
using Newtonsoft.Json;

namespace AdfToArm.Core.Models.LinkedServices
{
    [JsonObject]
    public class AzureMachineLearning : LinkedService
    {
        public AzureMachineLearning()
        {
            Properties = new LinkedServiceProperties
            {
                Type = LinkedServiceType.AzureML,
                TypeProperties = new AzureMachineLearningTypeProperties()
            };
        }

        public AzureMachineLearning(string name) : this()
        {
            Name = name;
        }
    }
}
