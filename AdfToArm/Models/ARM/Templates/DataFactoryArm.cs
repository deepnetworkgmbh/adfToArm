using Newtonsoft.Json;
using System.Collections.Generic;

namespace AdfToArm.Models.ARM.Tempaltes
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

        public void AddResource(ArmResource resource)
        {
            Resources.Add(resource);
        }
    }
}
