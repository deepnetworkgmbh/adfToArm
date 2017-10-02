using Newtonsoft.Json;

namespace AdfToArm.Models.ARM
{
    [JsonObject]
    public class ArmTemplate
    {
        public ArmTemplate()
        {
            Schema = @"http://schema.management.azure.com/schemas/2015-01-01/deploymentTemplate.json#";
            ContentVersion = "1.0.0.0";
            Parameters = new ArmParameter[0];
            Resources = new ArmResource[0];
        }

        [JsonProperty("$schema", Required = Required.Always)]
        public string Schema { get; set; }

        [JsonProperty("contentVersion", Required = Required.Always)]
        public string ContentVersion { get; set; }

        [JsonProperty("parameters", Required = Required.Always)]
        public ArmParameter[] Parameters { get; set; }

        [JsonProperty("resources", Required = Required.Always)]
        public ArmResource[] Resources { get; set; }
    }
}
