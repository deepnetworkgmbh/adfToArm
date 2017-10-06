using System.Runtime.Serialization;

namespace AdfToArm.Core.Models.Pipelines.ActivityProperties.CopyActivity.Sinks
{
    public enum CopyBehavior
    {
        [EnumMember(Value = "PreserveHierarchy ")]
        PreserveHierarchy,
        [EnumMember(Value = "FlattenHierarchy")]
        FlattenHierarchy,
        [EnumMember(Value = "MergeFiles")]
        MergeFiles
    }
}
