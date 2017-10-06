using Newtonsoft.Json;

namespace AdfToArm.Core.Models.ARM.Tempaltes
{
    [JsonObject]
    public class DataSetArm : ArmResource
    {
        public DataSetArm(string factoryName, DataSets.DataSet dataSet)
        {
            Name = dataSet.Name;
            Properties = dataSet.Properties;

            Type = Constants.DataSetType;
            ApiVersion = Constants.DataFactoryApiVersion;

            DependsOn = new string[2] { factoryName, dataSet.Properties.LinkedServiceName };
        }

        [JsonProperty("properties", Required = Required.Always)]
        public object Properties { get; set; }
    }
}
