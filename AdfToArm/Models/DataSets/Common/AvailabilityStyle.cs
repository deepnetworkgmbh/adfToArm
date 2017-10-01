using System.Runtime.Serialization;

namespace AdfToArm.Models.DataSets.Common
{
    public enum AvailabilityStyle
    {
        [EnumMember(Value = "StartOfInterval")]
        StartOfInterval,
        [EnumMember(Value = "EndOfInterval")]
        EndOfInterval
    }
}
