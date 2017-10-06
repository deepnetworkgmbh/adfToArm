using System.Runtime.Serialization;

namespace AdfToArm.Core.Models.Pipelines.Common
{
    public enum PipelineMode
    {
        [EnumMember(Value = "Scheduled")]
        Scheduled,
        [EnumMember(Value = "Onetime")]
        Onetime
    }
}
