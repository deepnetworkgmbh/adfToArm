using System.Runtime.Serialization;

namespace AdfToArm.Models.Pipelines.ActivityProperties.CopyActivity.Sinks
{
    public enum CopySinkType
    {
        [EnumMember(Value = "BlobSink")]
        BlobSink,
        [EnumMember(Value = "SqlSink")]
        SqlSink,
        [EnumMember(Value = "AzureDataLakeStoreSink")]
        AzureDataLakeStoreSink
    }
}
