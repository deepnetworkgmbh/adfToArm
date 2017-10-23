using AdfToArm.Core.Models.Pipelines.ActivityProperties.CopyActivity;
using Newtonsoft.Json;

namespace AdfToArm.Core.Models.Pipelines.ActivityProperties
{
    [JsonObject]
    public class CopyTypeProperties : IActivityTypeProperties
    {
        /// <summary>
        /// Specify the copy source type and the corresponding properties on how to retrieve data.
        /// </summary>
        [JsonConverter(typeof(CopySourceTypeConverter))]
        [JsonProperty("source", Required = Required.Always)]
        public ICopySource Source { get; set; }

        /// <summary>
        /// Specify the copy sink type and the corresponding properties on how to write data.
        /// </summary>
        [JsonConverter(typeof(CopySinkTypeConverter))]
        [JsonProperty("sink", Required = Required.Always)]
        public ICopySink Sink { get; set; }

        /// <summary>
        /// Specify explicit column mappings from source to sink. Applies when the default copy behavior cannot fulfill your need.
        /// </summary>
        [JsonProperty("translator", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public CopyTranslator Translator { get; set; }

        /// <summary>
        /// Specify the powerfulness of Azure Integration Runtime to empower data copy.
        /// 
        /// The allowed values are 2, 4, 8, 16, 32.
        /// </summary>
        [JsonProperty("cloudDataMovementUnits", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? CloudDataMovementUnits { get; set; }

        /// <summary>
        /// Specify the parallelism that you want Copy Activity to use when reading data from source and writing data to sink.
        /// </summary>
        [JsonProperty("parallelCopies", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? ParallelCopies { get; set; }

        /// <summary>
        /// Choose to stage the interim data in aa blob storage instead of directly copy data from source to sink.
        /// </summary>
        [JsonProperty("enableStaging", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool? EnableStaging { get; set; }

        /// <summary>
        /// Choose to stage the interim data in aa blob storage instead of directly copy data from source to sink.
        /// </summary>
        [JsonProperty("stagingSettings", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public StagingSettings StagingSettings { get; set; }

        /// <summary>
        /// Choose how to handle incompatible rows when copying data from source to sink.
        /// </summary>
        [JsonProperty("enableSkipIncompatibleRow", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool? EnableSkipIncompatibleRow { get; set; }

        /// <summary>
        /// Choose how to handle incompatible rows when copying data from source to sink.
        /// </summary>
        [JsonProperty("redirectIncompatibleRowSettings", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public RedirectIncompatibleRowSettings RedirectIncompatibleRowSettings { get; set; }
    }
}
