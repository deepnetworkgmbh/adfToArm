using System.Runtime.Serialization;

namespace AdfToArm.Core.Models.Common
{
    public enum Frequency
    {
        [EnumMember(Value = "Minute")]
        Minute,
        [EnumMember(Value = "Hour")]
        Hour,
        [EnumMember(Value = "Day")]
        Day,
        [EnumMember(Value = "Week")]
        Week,
        [EnumMember(Value = "Month")]
        Month
    }
}
