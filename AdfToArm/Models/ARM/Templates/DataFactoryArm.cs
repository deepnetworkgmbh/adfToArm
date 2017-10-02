using Newtonsoft.Json;

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
            Resources = new ArmResource[0];
        }

        public DataFactoryArm(string name) : this()
        {
            Name = name;
        }

        public void AddResource(ArmResource resource)
        {
            var previousResources = Resources;
            Resources = new ArmResource[previousResources.Length + 1];
            Resources[previousResources.Length] = resource;
        }
    }
}
