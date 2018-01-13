using Newtonsoft.Json;
using System.Collections.Generic;

namespace AdfToArm.Core.Models.ARM.Tempaltes
{
    [JsonObject]
    public class DataFactoryArm : ArmResource
    {
        public DataFactoryArm()
        {
            ApiVersion = Constants.DataFactoryApiVersion;
            Type = Constants.DataFactoryType;
            Location = Constants.ResourceGroupLocation;
            Resources = new List<ArmResource>();
        }

        public DataFactoryArm(string name) : this()
        {
            Name = name;
        }

        [ArmParameter(Name = "Location", RemoveBrackets = false)]
        [JsonProperty("location", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Location { get; set; }


        public void AddResource(ArmResource resource)
        {
            Resources.Add(resource);
        }
    }
}
