using Newtonsoft.Json;
using System;

namespace AdfToArm.Models.DataSets.Common
{
    [JsonObject]
    public class Policy
    {
        [JsonProperty("validation", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public PolicyValidation Validation { get; set; }

        /// <summary>
        /// Unless a dataset is being produced by Azure Data Factory, it should be marked as external. 
        /// This setting generally applies to the inputs of first activity in a pipeline unless activity or pipeline chaining is being used.
        /// </summary>
        [JsonProperty("externalData", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public ExternalPolicy External { get; set; }
    }

    [JsonObject]
    public class PolicyValidation
    {
        /// <summary>
        /// Validates that the data in an Azure Blob meets the minimum size requirements (in megabytes).
        /// 
        /// Applies only to Azure Blob
        /// </summary>
        [JsonProperty("minimumSizeMB", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public float? MinimumSizeMB { get; set; }

        /// <summary>
        /// Validates that the data in an Azure SQL database or an Azure table contains the minimum number of rows.
        /// 
        /// Applies only to Azure Blob and Azure SQL Database
        /// </summary>
        [JsonProperty("minimumRows", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public float? MinimumRows { get; set; }
    }

    [JsonObject]
    public class ExternalPolicy
    {
        /// <summary>
        /// Time to delay the check on the availability of the external data for the given slice. 
        /// For example, if the data is available hourly, the check to see the external data is available and the corresponding slice is Ready can be delayed by using dataDelay.
        /// 
        /// Only applies to the present time. For example, if it is 1:00 PM right now and this value is 10 minutes, the validation starts at 1:10 PM.
        /// 
        /// This setting does not affect slices in the past (slices with Slice End Time + dataDelay less then Now) are processed without any delay.
        /// 
        /// Time greater than 23:59 hours need to specified using the day.hours:minutes:seconds format. 
        /// For example, to specify 24 hours, don't use 24:00:00; instead, use 1.00:00:00. 
        /// If you use 24:00:00, it is treated as 24 days (24.00:00:00). 
        /// For 1 day and 4 hours, specify 1:04:00:00.
        /// </summary>
        [JsonProperty("dataDelay", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? DataDelay { get; set; }

        /// <summary>
        /// The wait time between a failure and the next retry attempt. If a try fails, the next try is after retryInterval. 
        /// 
        /// If it is 1:00 PM right now, we begin the first try. 
        /// If the duration to complete the first validation check is 1 minute and the operation failed, the next retry is at 1:00 + 1 min (duration) + 1 min (retry interval) = 1:02 PM. 
        /// 
        /// For slices in the past, there is no delay. The retry happens immediately.
        /// 
        /// Default value is 00:01:00 (1 minute)
        /// </summary>
        [JsonProperty("retryInterval", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public TimeSpan? RetryInterval { get; set; }

        /// <summary>
        /// The timeout for each retry attempt.
        /// 
        /// If this property is set to 10 minutes, the validation needs to be completed within 10 minutes. 
        /// If it takes longer than 10 minutes to perform the validation, the retry times out.
        /// 
        /// If all attempts for the validation times out, the slice is marked as TimedOut.
        /// 
        /// Default value is 00:10:00 (10 minutes)
        /// </summary>
        [JsonProperty("retryTimeout", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public TimeSpan? RetryTimeout { get; set; }

        /// <summary>
        /// Number of times to check for the availability of the external data. The allowed maximum value is 10.
        /// 
        /// Default value is 3
        /// </summary>
        [JsonProperty("maximumRetry", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? MaximumRetry { get; set; }
    }
}
