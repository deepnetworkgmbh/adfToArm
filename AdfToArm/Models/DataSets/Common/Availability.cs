using AdfToArm.Models.Common;
using Newtonsoft.Json;
using System;

namespace AdfToArm.Models.DataSets.Common
{
    [JsonObject]
    public class Availability
    {
        /// <summary>
        /// Specifies the time unit for dataset slice production.
        ///
        /// Supported frequency: Minute, Hour, Day, Week, Month
        /// </summary>
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        [JsonProperty("frequency", Required = Required.Always)]
        public Frequency Frequency { get; set; }

        /// <summary>
        /// Specifies a multiplier for frequency
        /// ”Frequency x interval” determines how often the slice is produced.
        /// If you need the dataset to be sliced on an hourly basis, you set Frequency to Hour, and interval to 1.
        /// Note: If you specify Frequency as Minute, we recommend that you set the interval to no less than 15
        /// </summary>
        [JsonProperty("interval", Required = Required.Always)]
        public int Interval { get; set; }

        /// <summary>
        /// Specifies whether the slice should be produced at the start/end of the interval.
        /// 
        /// If Frequency is set to Month and style is set to EndOfInterval, the slice is produced on the last day of month. 
        /// If the style is set to StartOfInterval, the slice is produced on the first day of month.
        /// 
        /// If Frequency is set to Day and style is set to EndOfInterval, the slice is produced in the last hour of the day.
        /// 
        /// If Frequency is set to Hour and style is set to EndOfInterval, the slice is produced at the end of the hour. 
        /// For example, for a slice for 1 PM – 2 PM period, the slice is produced at 2 PM.
        /// </summary>
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        [JsonProperty("style", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public AvailabilityStyle? Style { get; set; }

        /// <summary>
        /// Defines the absolute position in time used by scheduler to compute dataset slice boundaries. 
        /// 
        /// Note: If the AnchorDateTime has date parts that are more granular than the frequency then the more granular parts are ignored. 
        /// 
        /// For example, if the interval is hourly (frequency: hour and interval: 1) and the AnchorDateTime contains minutes and seconds then the minutes and seconds parts of the AnchorDateTime are ignored.
        /// </summary>
        [JsonProperty("anchorDateTime", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? AnchorDateTime { get; set; }

        /// <summary>
        /// Timespan by which the start and end of all dataset slices are shifted. 
        /// 
        /// Note: If both anchorDateTime and offset are specified, the result is the combined shift.
        /// </summary>
        [JsonProperty("offset", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public TimeSpan? Offset { get; set; }
    }
}
