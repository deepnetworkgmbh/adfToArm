using System.Runtime.Serialization;

namespace AdfToArm.Models.Pipelines.Common
{
    public enum ExecutionPriorityOrders
    {
        [EnumMember(Value = "OldestFirst")]
        OldestFirst,
        [EnumMember(Value = "NewestFirst")]
        NewestFirst
    }
}
