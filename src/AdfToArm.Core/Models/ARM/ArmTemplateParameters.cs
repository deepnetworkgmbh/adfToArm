using Newtonsoft.Json;
using System.Collections.Generic;

namespace AdfToArm.Core.Models.ARM
{
    [JsonObject]
    public class ArmTemplateParameters
    {
        public ArmTemplateParameters()
        {
            Schema = @"http://schema.management.azure.com/schemas/2015-01-01/deploymentParameters.json#";
            ContentVersion = "1.0.0.0";
            Parameters = new List<ArmTemplateParameterItem>();
        }

        [JsonProperty("$schema", Required = Required.Always)]
        public string Schema { get; set; }

        [JsonProperty("contentVersion", Required = Required.Always)]
        public string ContentVersion { get; set; }

        [JsonConverter(typeof(ArmTemplateParametersConverter))]
        [JsonProperty("parameters", Required = Required.Always)]
        public List<ArmTemplateParameterItem> Parameters { get; set; }
    }
}
