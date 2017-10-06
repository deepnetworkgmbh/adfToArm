using AdfToArm.Core.Models.LinkedServices;
using AdfToArm.Core.Models.LinkedServices.LinkedServiceTypeProperties;
using Newtonsoft.Json;

namespace AdfToArm.Core.Models.ARM.Tempaltes
{
    [JsonObject]
    public class LinkedServiceArm : ArmResource
    {
        public LinkedServiceArm(string factoryName, LinkedService linkedService)
        {
            Name = linkedService.Name;
            Properties = linkedService.Properties;

            Type = Constants.LinkedServiceType;
            ApiVersion = Constants.DataFactoryApiVersion;

            switch(linkedService.Properties.TypeProperties)
            {
                case AzureBatchTypeProperties batch:
                    DependsOn = new string[2] { factoryName, batch.LinkedServiceName };
                    break;
                case HDInsightTypeProperties insights:
                    DependsOn = new string[2] { factoryName, insights.LinkedServiceName };
                    break;
                default:
                    DependsOn = new string[1] { factoryName };
                    break;
            }
        }

        [JsonProperty("properties", Required = Required.Always)]
        public object Properties { get; set; }
    }
}
