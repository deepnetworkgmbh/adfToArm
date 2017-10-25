using AdfToArm.Core.Models.Common;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace AdfToArm.Core.Models.Pipelines.ActivityProperties
{
    [JsonObject]
    public class MlBatchExecutorTypeProperties : IActivityTypeProperties
    {
        /// <summary>
        /// Datasets that are referenced by the webServiceInput property must also be included in the Activity inputs.
        /// </summary>
        [ArmParameter]
        [JsonProperty("webServiceInput", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string WebServiceInput { get; set; }

        /// <summary>
        /// If the web service takes multiple inputs, use the webServiceInputs property instead of using webServiceInput
        /// 
        /// Datasets that are referenced by the webServiceInputs property must also be included in the Activity inputs.
        /// </summary>
        [ArmParameter("object")]
        [JsonConverter(typeof(PairConverter))]
        [JsonProperty("webServiceInputs", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public KeyValuePair<string, string>[] WebServiceInputs { get; set; }

        /// <summary>
        /// Datasets that are referenced by the webServiceOutputs property must also be included in the Activity outputs.
        /// </summary>
        [ArmParameter("object")]
        [JsonConverter(typeof(PairConverter))]
        [JsonProperty("webServiceOutputs", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public KeyValuePair<string, string>[] WebServiceOutputs { get; set; }

        /// <summary>
        /// </summary>
        [ArmParameter("object")]
        [JsonConverter(typeof(PairConverter))]
        [JsonProperty("globalParameters", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public KeyValuePair<string, string>[] GlobalParameters { get; set; }
    }
}
