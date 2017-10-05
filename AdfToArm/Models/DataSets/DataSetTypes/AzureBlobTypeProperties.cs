using AdfToArm.Models.DataSets.Common;
using Newtonsoft.Json;

namespace AdfToArm.Models.DataSets.DataSetTypes
{
    [JsonObject]
    public class AzureBlobTypeProperties : IDataSetTypeProperties
    {
        /// <summary>
        /// Path to the container and folder in the blob storage. Example: myblobcontainer\myblobfolder\
        /// </summary>
        [ArmParameter]
        [JsonProperty("folderPath", Required = Required.Always)]
        public string FolderPath { get; set; }

        /// <summary>
        /// Name of the blob. fileName is optional and case-sensitive.
        /// 
        /// If you specify a filename, the activity (including Copy) works on the specific Blob.
        /// 
        /// When fileName is not specified, Copy includes all Blobs in the folderPath for input dataset.
        /// 
        /// When fileName is not specified for an output dataset, the name of the generated file would be in the following this format: Data..txt (for example: : Data.0a405f8a-93ff-4c6f-b3be-f69616f1df7a.txt
        /// </summary>
        [ArmParameter]
        [JsonProperty("fileName", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string FileName { get; set; }

        /// <summary>
        /// You can use it to specify a dynamic folderPath and filename for time series data. 
        /// For example, folderPath can be parameterized for every hour of data.
        /// </summary>
        [JsonProperty("partitionedBy", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public PartitionedBy[] PartitionedBy { get; set; }

        /// <summary>
        /// The following format types are supported: TextFormat, JsonFormat, AvroFormat, OrcFormat, ParquetFormat.
        /// 
        /// If you want to copy files as-is between file-based stores (binary copy), skip the format section in both input and output dataset definitions.
        /// </summary>
        [JsonProperty("format", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public FormatType Format { get; set; }

        /// <summary>
        /// Specify the type and level of compression for the data. Supported types are: GZip, Deflate, BZip2, and ZipDeflate. Supported levels are: Optimal and Fastest. 
        /// For more information, see <see href="https://docs.microsoft.com/en-us/azure/data-factory/v1/data-factory-supported-file-and-compression-formats#compression-support">File and compression formats in Azure Data Factory</see>.
        /// </summary>
        [JsonProperty("compression", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public Compression Compression { get; set; }
    }
}
