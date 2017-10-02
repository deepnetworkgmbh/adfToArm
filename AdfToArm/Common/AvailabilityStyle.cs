using System.Runtime.Serialization;

namespace AdfToArm.Common
{
    public enum AvailabilityStyle
    {
        [EnumMember(Value = "StartOfInterval")]
        StartOfInterval,
        [EnumMember(Value = "EndOfInterval")]
        EndOfInterval
    }
}
