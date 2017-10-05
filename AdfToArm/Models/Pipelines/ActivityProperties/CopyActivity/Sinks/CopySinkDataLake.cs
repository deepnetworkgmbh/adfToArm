using Newtonsoft.Json;

namespace AdfToArm.Models.Pipelines.ActivityProperties.CopyActivity.Sinks
{
    [JsonObject]
    public class CopySinkDataLake : ICopySink
    {
        /// <summary>
        /// The type property of the copy activity sink must be set to: AzureDataLakeStoreSink
        /// </summary>
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        [JsonProperty("type", Required = Required.Always)]
        public CopySinkType Type { get; set; }

        /// <summary>
        /// Defines the copy behavior when the source is files from file-based data store.
        /// - PreserveHierarchy(default): preserves the file hierarchy in the target folder.The relative path of source file to source folder is identical to the relative path of target file to target folder.
        /// - FlattenHierarchy: all files from the source folder are in the first level of target folder.The target files have auto generated name. 
        /// - MergeFiles: merges all files from the source folder to one file. If the File/Blob Name is specified, the merged file name would be the specified name; otherwise, would be auto-generated file name.
        /// </summary>
        [JsonProperty("copyBehavior", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public CopyBehavior? CopyBehavior { get; set; }
    }
}
