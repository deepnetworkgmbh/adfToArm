using System.Runtime.Serialization;

namespace AdfToArm.Core.Models.Pipelines.ActivityProperties
{
    public enum GetDebugInfo
    {
        [EnumMember(Value = "None")]
        None,
        [EnumMember(Value = "Always")]
        Always,
        [EnumMember(Value = "Failure")]
        Failure
    }
}
