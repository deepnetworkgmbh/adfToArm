using AdfToArm.Common;
using AdfToArm.Models.Pipelines.Common;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace AdfToArm.Models.Pipelines.ActivityProperties
{
    [JsonObject]
    public class DotNetActivityTypeProperties : IActivityTypeProperties
    {
        /// <summary>
        /// Name of the assembly. For example, MyDotnetActivity.dll.
        /// </summary>
        [JsonProperty("AssemblyName", Required = Required.Always)]
        public string AssemblyName { get; set; }

        /// <summary>
        /// Name of the class that implements the IDotNetActivity interface. 
        /// For example, MyDotNetActivityNS.MyDotNetActivity where MyDotNetActivityNS is the namespace and MyDotNetActivity is the class.
        /// </summary>
        [JsonProperty("EntryPoint", Required = Required.Always)]
        public string EntryPoint { get; set; }

        /// <summary>
        /// Name of the Azure Storage linked service that points to the blob storage that contains the custom activity zip file. 
        /// For example, AzureStorageLinkedService.
        /// </summary>
        [JsonProperty("PackageLinkedService", Required = Required.Always)]
        public string PackageLinkedService { get; set; }

        /// <summary>
        /// Name of the zip file. For example, customactivitycontainer/MyDotNetActivity.zip.
        /// </summary>
        [JsonProperty("PackageFile", Required = Required.Always)]
        public string PackageFile { get; set; }

        /// <summary>
        /// Extended properties that you can define and pass on to the .NET code
        /// </summary>
        [JsonConverter(typeof(PairConverter))]
        [JsonProperty("extendedProperties", Required = Required.Default)]
        public KeyValuePair<string, string>[] ExtendedProperties { get; set; }
    }
}
