using Newtonsoft.Json;

namespace AdfToArm.Core.Models.Pipelines.ActivityProperties.CopyActivity
{
    [JsonObject]
    public class RedirectIncompatibleRowSettings
    {
        /// <summary>
        /// The linked service of Azure Storage to store the log that contains the skipped rows.
        /// 
        /// The name of an AzureStorage or AzureStorageSas linked service, which refers to the storage instance that you want to use to store the log file.
        /// </summary>
        [JsonProperty("linkedServiceName", Required = Required.Always)]
        public string LinkedServiceName { get; set; }

        /// <summary>
        /// The path of the log file that contains the skipped rows.
        /// 
        /// Specify the Blob storage path that you want to use to log the incompatible data. 
        /// If you do not provide a path, the service creates a container for you.
        /// </summary>
        [JsonProperty("path", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Path { get; set; }
    }
}
