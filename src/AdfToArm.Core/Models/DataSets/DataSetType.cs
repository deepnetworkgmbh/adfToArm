using System.Runtime.Serialization;

namespace AdfToArm.Core.Models.DataSets
{
    public enum DataSetType
    {
        [EnumMember(Value = "AzureBlob")]
        AzureBlob,
        [EnumMember(Value = "AzureSqlTable")]
        AzureSqlTable,
        [EnumMember(Value = "AzureDataLakeStore")]
        AzureDataLakeStore,
        [EnumMember(Value = "DocumentDbCollection")]
        CosmosDbCollection,
        [EnumMember(Value = "AzureTable")]
        AzureTable
    }
}
