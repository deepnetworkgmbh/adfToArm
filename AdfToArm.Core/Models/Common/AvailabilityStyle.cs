using System.Runtime.Serialization;

namespace AdfToArm.Core.Models.Common
{
    public enum AvailabilityStyle
    {
        [EnumMember(Value = "StartOfInterval")]
        StartOfInterval,
        [EnumMember(Value = "EndOfInterval")]
        EndOfInterval
    }
}
