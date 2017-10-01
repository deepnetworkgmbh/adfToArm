using System.Runtime.Serialization;

namespace AdfToArm.Models
{
    public enum LinkedService
    {
        [EnumMember(Value = "AzureSqlDatabase")]
        AzureSqlDatabase,
        [EnumMember(Value = "AzureStorage")]
        AzureStorage,
        [EnumMember(Value = "HDInsight")]
        HDInsight,
        [EnumMember(Value = "AzureDataLakeAnalytics")]
        AzureDataLakeAnalytics,
        [EnumMember(Value = "AzureDataLakeStore")]
        AzureDataLakeStore,
        [EnumMember(Value = "AzureBatch")]
        AzureBatch
    }
}
