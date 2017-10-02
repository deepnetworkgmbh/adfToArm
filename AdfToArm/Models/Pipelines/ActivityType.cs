using System.Runtime.Serialization;

namespace AdfToArm.Models.Pipelines
{
    public enum ActivityType
    {
        [EnumMember(Value = "SqlServerStoredProcedure")]
        SqlServerStoredProcedure,
        [EnumMember(Value = "Copy")]
        Copy,
        [EnumMember(Value = "HDInsightSpark")]
        HDInsightSpark,
        [EnumMember(Value = "DataLakeAnalyticsU-SQL")]
        DataLakeAnalyticsUSQL,
        [EnumMember(Value = "DotNetActivity")]
        DotNetActivity
    }
}
