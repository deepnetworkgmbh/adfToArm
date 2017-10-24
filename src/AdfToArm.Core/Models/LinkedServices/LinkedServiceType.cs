using System.Runtime.Serialization;

namespace AdfToArm.Core.Models.LinkedServices
{
    public enum LinkedServiceType
    {
        [EnumMember(Value = "AzureSqlDatabase")]
        AzureSqlDatabase,
        [EnumMember(Value = "AzureSqlDW")]
        AzureSqlDW,
        [EnumMember(Value = "AzureStorage")]
        AzureStorage,
        [EnumMember(Value = "AzureStorageSas")]
        AzureStorageSas,
        [EnumMember(Value = "HDInsight")]
        HDInsight,
        [EnumMember(Value = "AzureDataLakeAnalytics")]
        AzureDataLakeAnalytics,
        [EnumMember(Value = "AzureDataLakeStore")]
        AzureDataLakeStore,
        [EnumMember(Value = "AzureBatch")]
        AzureBatch,
        [EnumMember(Value = "DocumentDb")]
        AzureCosmosDb,
        [EnumMember(Value = "AzureSearch")]
        AzureSearch,
        [EnumMember(Value = "AzureML")]
        AzureML
    }
}
