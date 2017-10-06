using Newtonsoft.Json;
using System.Collections.Generic;

namespace AdfToArm.Core.Models.ARM
{
    [JsonObject]
    public class ArmTemplate
    {
        public ArmTemplate()
        {
            Schema = @"http://schema.management.azure.com/schemas/2015-01-01/deploymentTemplate.json#";
            ContentVersion = "1.0.0.0";
            Parameters = new List<ArmParameter>();
            Resources = new List<ArmResource>();
        }

        [JsonProperty("$schema", Required = Required.Always)]
        public string Schema { get; set; }

        [JsonProperty("contentVersion", Required = Required.Always)]
        public string ContentVersion { get; set; }

        [JsonProperty("parameters", Required = Required.Always)]
        public List<ArmParameter> Parameters { get; set; }

        [JsonProperty("resources", Required = Required.Always)]
        public List<ArmResource> Resources { get; set; }
    }
}
