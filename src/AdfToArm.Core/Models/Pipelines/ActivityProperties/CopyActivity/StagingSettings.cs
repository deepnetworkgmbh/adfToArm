using Newtonsoft.Json;

namespace AdfToArm.Core.Models.Pipelines.ActivityProperties.CopyActivity
{
    [JsonObject]
    public class StagingSettings
    {
        /// <summary>
        /// Specify the name of an AzureStorage or AzureStorageSas linked service, which refers to the instance of Storage that you use as an interim staging store. 
        ///
        /// You cannot use Storage with a shared access signature to load data into SQL Data Warehouse via PolyBase.
        /// You can use it in all other scenarios.
        /// </summary>
        [JsonProperty("linkedServiceName", Required = Required.Always)]
        public string LinkedServiceName { get; set; }

        /// <summary>
        /// Specify the Blob storage path that you want to contain the staged data. 
        /// If you do not provide a path, the service creates a container to store temporary data. 
        /// 
        /// Specify a path only if you use Storage with a shared access signature, or you require temporary data to be in a specific location.
        /// </summary>
        [JsonProperty("path", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Path { get; set; }

        /// <summary>
        /// Specifies whether data should be compressed before it is copied to the destination. 
        /// This setting reduces the volume of data being transferred.
        /// </summary>
        [JsonProperty("enableCompression", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool? EnableCompression { get; set; }
    }
}
