using System.Runtime.Serialization;

namespace AdfToArm.Core.Models.Pipelines.ActivityProperties.CopyActivity.Sources
{
    public enum CopySourceType
    {
        [EnumMember(Value = "BlobSource")]
        BlobSource,
        [EnumMember(Value = "AzureDataLakeStoreSource")]
        AzureDataLakeStoreSource,
        [EnumMember(Value = "SqlSource")]
        SqlSource,
        [EnumMember(Value = "AzureTableSource")]
        AzureTableSource,
        [EnumMember(Value = "DocumentDbCollectionSource")]
        CosmosDbCollectionSource,
        [EnumMember(Value = "SqlDWSource")]
        SqlDWSource
    }
}
