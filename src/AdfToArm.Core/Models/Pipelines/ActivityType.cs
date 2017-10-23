using System.Runtime.Serialization;

namespace AdfToArm.Core.Models.Pipelines
{
    public enum ActivityType
    {
        [EnumMember(Value = "Copy")]
        Copy,
        [EnumMember(Value = "SqlServerStoredProcedure")]
        SqlServerStoredProcedure,
        [EnumMember(Value = "HDInsightSpark")]
        HDInsightSpark,
        [EnumMember(Value = "DataLakeAnalyticsU-SQL")]
        DataLakeAnalyticsUSQL,
        [EnumMember(Value = "DotNetActivity")]
        DotNetActivity
    }
}
