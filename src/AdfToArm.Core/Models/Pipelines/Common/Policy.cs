using Newtonsoft.Json;
using System;

namespace AdfToArm.Core.Models.Pipelines.Common
{
    [JsonObject]
    public class Policy
    {
        /// <summary>
        /// Number of concurrent executions of the activity.
        /// 
        /// It determines the number of parallel activity executions that can happen on different slices. 
        /// For example, if an activity needs to go through a large set of available data, having a larger concurrency value speeds up the data processing.
        /// 
        /// Default value is 1, Maximum - 10.
        /// </summary>
        [JsonProperty("concurrency", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? Concurrency { get; set; }

        /// <summary>
        /// Determines the ordering of data slices that are being processed.
        /// 
        /// For example, if you have 2 slices (one happening at 4pm, and another one at 5pm), and both are pending execution. 
        /// If you set the executionPriorityOrder to be NewestFirst, the slice at 5 PM is processed first. 
        /// Similarly if you set the executionPriorityORder to be OldestFIrst, then the slice at 4 PM is processed.
        /// </summary>
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        [JsonProperty("executionPriorityOrder", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public ExecutionPriorityOrders? ExecutionPriorityOrder { get; set; }

        /// <summary>
        /// Number of retries before the data processing for the slice is marked as Failure. 
        /// Activity execution for a data slice is retried up to the specified retry count. 
        /// The retry is done as soon as possible after the failure.
        /// 
        /// Default value is 0, Maximum - 10.
        /// </summary>
        [JsonProperty("retry", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? Retry { get; set; }

        /// <summary>
        /// Timeout for the activity. Example: 00:10:00 (implies timeout 10 mins)
        /// 
        /// If a value is not specified or is 0, the timeout is infinite.
        /// 
        /// If the data processing time on a slice exceeds the timeout value, it is canceled, and the system attempts to retry the processing. 
        /// The number of retries depends on the retry property. When timeout occurs, the status is set to TimedOut.
        /// </summary>
        [JsonProperty("timeout", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public TimeSpan? Timeout { get; set; }

        /// <summary>
        /// Specify the delay before data processing of the slice starts.
        /// 
        /// The execution of activity for a data slice is started after the Delay is past the expected execution time.
        /// 
        /// Example: 00:10:00 (implies delay of 10 mins)
        /// </summary>
        [JsonProperty("delay", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public TimeSpan? Delay { get; set; }

        /// <summary>
        /// The number of long retry attempts before the slice execution is failed.
        /// 
        /// longRetry attempts are spaced by longRetryInterval. So if you need to specify a time between retry attempts, use longRetry. 
        /// If both Retry and longRetry are specified, each longRetry attempt includes Retry attempts and the max number of attempts is Retry * longRetry.
        /// 
        /// <example>
        /// For example, if we have the following settings in the activity policy:Retry: 3; longRetry: 2 longRetryInterval: 01:00:00.
        /// 
        /// Assume there is only one slice to execute (status is Waiting) and the activity execution fails every time. 
        /// Initially there would be 3 consecutive execution attempts. 
        /// After each attempt, the slice status would be Retry. 
        /// After first 3 attempts are over, the slice status would be LongRetry.
        /// 
        /// After an hour (that is, longRetryInteval’s value), there would be another set of 3 consecutive execution attempts. 
        /// After that, the slice status would be Failed and no more retries would be attempted. 
        /// Hence overall 6 attempts were made.
        /// 
        /// If any execution succeeds, the slice status would be Ready and no more retries are attempted.
        /// </example>
        /// 
        /// longRetry may be used in situations where dependent data arrives at non-deterministic times or the overall environment is flaky under which data processing occurs. 
        /// In such cases, doing retries one after another may not help and doing so after an interval of time results in the desired output.
        /// 
        /// Word of caution: do not set high values for longRetry or longRetryInterval. Typically, higher values imply other systemic issues.
        /// 
        /// Default value is 1, Maximum - 10.
        /// </summary>
        [JsonProperty("longRetry", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? LongRetry { get; set; }

        /// <summary>
        /// The delay between long retry attempts
        /// 
        /// Default value is 00:00:00
        /// </summary>
        [JsonProperty("longRetryInterval", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public TimeSpan? LongRetryInterval { get; set; }
    }
}
