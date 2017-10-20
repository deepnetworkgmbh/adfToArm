using AdfToArm.Core.Models.LinkedServices.LinkedServiceTypeProperties;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AdfToArm.Core.Models.LinkedServices
{
    public abstract class LinkedService
    {
        public LinkedService()
        {
            Schema = @"http://datafactories.schema.management.azure.com/internalschemas/2015-09-01/Microsoft.DataFactory.LinkedService.json";
        }

        [JsonProperty("$schema", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Schema { get; set; }

        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty("properties", Required = Required.Always)]
        public LinkedServiceProperties Properties { get; set; }
    }

    [JsonObject]
    public class LinkedServiceProperties
    {
        [JsonProperty("type", Required = Required.Always)]
        [JsonConverter(typeof(StringEnumConverter))]
        public LinkedServiceType Type { get; set; }

        [JsonProperty("hubName", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string HubName { get; set; }

        [JsonProperty("typeProperties", Required = Required.Always)]
        public ILinkedServiceProperties TypeProperties { get; set; }
    }
}
