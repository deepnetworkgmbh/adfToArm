using Newtonsoft.Json;

namespace AdfToArm.Core.Models.ARM
{
    [JsonObject]
    public class ArmTemplateParameterItem
    {
        public ArmTemplateParameterItem(ArmParameter param)
        {
            Name = param.Name;
            Value = param.Properties.DefaultValue;
        }

        [JsonIgnore]
        public string Name { get; set; }

        [JsonProperty("value", Required = Required.AllowNull)]
        public object Value { get; set; }
    }
}
