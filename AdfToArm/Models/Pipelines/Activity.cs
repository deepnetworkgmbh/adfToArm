using AdfToArm.Models.Pipelines.ActivityProperties;
using AdfToArm.Models.Pipelines.Common;
using Newtonsoft.Json;

namespace AdfToArm.Models.Pipelines
{
    public abstract class Activity
    {
        /// <summary>
        /// Name of the activity. Specify a name that represents the action that the activity is configured to do
        /// </summary>
        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }

        /// <summary>
        /// Text describing what the activity is used for.
        /// </summary>
        [JsonProperty("description", Required = Required.Always)]
        public string Description { get; set; }

        /// <summary>
        /// Specifies the type of the activity
        /// </summary>
        [JsonProperty("type", Required = Required.Always)]
        public ActivityType Type { get; set; }

        /// <summary>
        /// Input tables used by the activity
        /// </summary>
        [JsonProperty("inputs", Required = Required.Always)]
        public IOItem[] Inputs { get; set; }

        /// <summary>
        /// Outputs tables used by the activity
        /// </summary>
        [JsonProperty("outputs", Required = Required.Always)]
        public IOItem[] Outputs { get; set; }

        /// <summary>
        /// Name of the linked service used by the activity.
        /// An activity may require that you specify the linked service that links to the required compute environment.
        /// 
        /// It is required for HDInsight activities, Azure Machine Learning activities, and Stored Procedure Activity. 
        /// No for all others
        /// </summary>
        [JsonProperty("linkedServiceName", Required = Required.AllowNull)]
        public string LinkedServiceName { get; set; }

        /// <summary>
        /// Properties in the typeProperties section depend on type of the activity.
        /// </summary>
        [JsonProperty("typeProperties", Required = Required.AllowNull)]
        public IActivityTypeProperties TypeProperties { get; set; }

        /// <summary>
        /// Policies that affect the run-time behavior of the activity. If it is not specified, default policies are used.
        /// </summary>
        [JsonProperty("policy", Required = Required.AllowNull)]
        public Policy Policy { get; set; }

        /// <summary>
        /// “scheduler” property is used to define desired scheduling for the activity
        /// </summary>
        [JsonProperty("scheduler", Required = Required.AllowNull)]
        public Scheduler Scheduler { get; set; }
    }
}
