using AdfToArm.Models.Pipelines.Common;
using Newtonsoft.Json;
using System;

namespace AdfToArm.Models.Pipelines
{
    [JsonObject]
    public class Pipeline
    {
        // TODO: naming rules: https://docs.microsoft.com/en-us/azure/data-factory/v1/data-factory-json-scripting-reference#pipeline
        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty("properties", Required = Required.Always)]
        public PipelineProperties Properties { get; set; }
    }

    [JsonObject]
    public class PipelineProperties
    {
        /// <summary>
        /// Text describing what the activity or pipeline is used for
        /// </summary>
        [JsonProperty("description", Required = Required.AllowNull)]
        public string Description { get; set; }

        /// <summary>
        /// Contains a list of activities.
        /// </summary>
        [JsonProperty("activities", Required = Required.Always)]
        public Activity[] Activities { get; set; }

        /// <summary>
        /// Start date-time for the pipeline. Must be in ISO format. For example: 2014-10-14T16:32:41. 
        /// 
        /// It is possible to specify a local time, for example an EST time. 
        /// Here is an example: 2016-02-27T06:00:00**-05:00, which is 6 AM EST.
        /// 
        /// The start and end properties together specify active period for the pipeline. Output slices are only produced with in this active period.
        /// 
        /// If you specify a value for the end property, you must specify value for the start property.
        /// The start and end times can both be empty to create a pipeline. 
        /// You must specify both values to set an active period for the pipeline to run. 
        /// If you do not specify start and end times when creating a pipeline, you can set them using the Set-AzureRmDataFactoryPipelineActivePeriod cmdlet later.
        /// </summary>
        [JsonProperty("start", Required = Required.AllowNull)]
        public DateTime? Start { get; set; }

        /// <summary>
        /// End date-time for the pipeline. If specified must be in ISO format. For example: 2014-10-14T17:32:41 
        /// It is possible to specify a local time, for example an EST time. Here is an example: 2016-02-27T06:00:00**-05:00, which is 6 AM EST.
        /// To run the pipeline indefinitely, specify 9999-09-09 as the value for the end property.
        /// 
        /// If you specify a value for the start property, you must specify value for the end property. 
        /// See notes for the start property.
        /// </summary>
        [JsonProperty("end", Required = Required.AllowNull)]
        public DateTime? End { get; set; }

        /// <summary>
        /// If set to true the pipeline does not run. Default value = false. You can use this property to enable or disable.
        /// </summary>
        [JsonProperty("isPaused", Required = Required.AllowNull)]
        public bool? IsPaused { get; set; }

        /// <summary>
        /// The method for scheduling runs for the pipeline. Allowed values are: scheduled (default), onetime.
        /// 
        /// ‘Scheduled’ indicates that the pipeline runs at a specified time interval according to its active period (start and end time). 
        /// ‘Onetime’ indicates that the pipeline runs only once. Onetime pipelines once created cannot be modified/updated currently. 
        /// See Onetime pipeline for details about onetime setting.
        /// </summary>
        [JsonProperty("pipelineMode", Required = Required.AllowNull)]
        public PipelineMode PipelineMode { get; set; }

        /// <summary>
        /// Duration of time after creation for which the pipeline is valid and should remain provisioned. 
        /// If it does not have any active, failed, or pending runs, the pipeline is deleted automatically once it reaches the expiration time.
        /// </summary>
        [JsonProperty("expirationTime", Required = Required.AllowNull)]
        public TimeSpan? ExpirationTime { get; set; }
    }
}
