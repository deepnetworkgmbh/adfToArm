using System.Runtime.Serialization;

namespace AdfToArm.Core.Models.Pipelines.ActivityProperties.CopyActivity.Sinks
{
    public enum CopySinkType
    {
        [EnumMember(Value = "BlobSink")]
        BlobSink,
        [EnumMember(Value = "SqlSink")]
        SqlSink,
        [EnumMember(Value = "AzureDataLakeStoreSink")]
        AzureDataLakeStoreSink,
        [EnumMember(Value = "AzureTableSink")]
        AzureTableSink,
        [EnumMember(Value = "DocumentDbCollectionSink")]
        CosmosDbCollectionSink,
        [EnumMember(Value = "AzureSearchIndexSink")]
        AzureSearchIndexSink,
        [EnumMember(Value = "SqlDWSink")]
        SqlDWSink
    }
}
