using Newtonsoft.Json;
using System.Collections.Generic;

namespace AdfToArm.Core.Models.ARM.Tempaltes
{
    [JsonObject]
    public class PipelineArm : ArmResource
    {
        public PipelineArm(string factoryName, Pipelines.Pipeline pipeline)
        {
            Name = pipeline.Name;
            Properties = pipeline.Properties;

            Type = Constants.PipelineType;
            ApiVersion = Constants.DataFactoryApiVersion;

            var dependencies = new List<string>() { factoryName };
            foreach(var activity in pipeline.Properties.Activities)
            {
                if (activity.Inputs != null)
                {
                    foreach (var input in activity.Inputs)
                        dependencies.Add(input.Name);
                }

                foreach (var output in activity.Outputs)
                    dependencies.Add(output.Name);
            }

            DependsOn = dependencies.ToArray();
        }

        [JsonProperty("properties", Required = Required.Always)]
        public object Properties { get; set; }
    }
}
