using System.Runtime.Serialization;

namespace AdfToArm.Models.Common
{
    public enum AvailabilityStyle
    {
        [EnumMember(Value = "StartOfInterval")]
        StartOfInterval,
        [EnumMember(Value = "EndOfInterval")]
        EndOfInterval
    }
}
