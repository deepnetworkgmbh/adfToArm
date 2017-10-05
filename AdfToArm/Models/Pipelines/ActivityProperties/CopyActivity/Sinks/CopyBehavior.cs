using System.Runtime.Serialization;

namespace AdfToArm.Models.Pipelines.ActivityProperties.CopyActivity.Sinks
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
