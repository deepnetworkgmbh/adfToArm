using Newtonsoft.Json;
using System.IO.Compression;

namespace AdfToArm.Models.DataSets.Common
{
    [JsonObject]
    public class Compression
    {
        /// <summary>
        /// the compression codec, which can be GZIP, Deflate, BZIP2, or ZipDeflate.
        /// 
        /// NOTE: Compression settings are not supported for data in the AvroFormat, OrcFormat, or ParquetFormat. 
        /// When reading files in these formats, Data Factory detects and uses the compression codec in the metadata. 
        /// When writing to files in these formats, Data Factory chooses the default compression codec for that format. 
        /// For example, ZLIB for OrcFormat and SNAPPY for ParquetFormat.
        /// </summary>
        [JsonProperty("type", Required = Required.Always)]
        public CompressionType Type { get; set; }

        /// <summary>
        /// the compression ratio, which can be Optimal or Fastest.
        /// 
        /// Fastest: The compression operation should complete as quickly as possible, even if the resulting file is not optimally compressed.
        /// 
        /// Optimal: The compression operation should be optimally compressed, even if the operation takes a longer time to complete.
        /// </summary>
        [JsonProperty("level", Required = Required.Always)]
        public CompressionLevel Level { get; set; }

    }
}
