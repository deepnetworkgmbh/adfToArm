using Newtonsoft.Json;
using System;

namespace AdfToArm.Core.Models.Pipelines.ActivityProperties.CopyActivity.Sinks
{
    [JsonObject]
    public class CopySinkBlob : ICopySink
    {
        /// <summary>
        /// The type property of the copy activity sink must be set to: BlobSink
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

        /// <summary>
        /// Specifies whether to add a header of column definitions while writing to an output dataset.
        /// 
        /// BlobSink supports the property for backward compatibility.
        /// </summary>
        [JsonProperty("blobWriterAddHeader", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool? BlobWriterAddHeader { get; set; }

        /// <summary>
        /// Writes data into the Blob when the writeBatchSize or writeBatchTimeout is hit.
        /// </summary>
        [JsonProperty("writeBatchSize", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? WriteBatchSize { get; set; }

        /// <summary>
        /// Writes data into the Blob when the writeBatchSize or writeBatchTimeout is hit.
        /// </summary>
        [JsonProperty("writeBatchTimeout", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public TimeSpan? WriteBatchTimeout { get; set; }
    }
}
