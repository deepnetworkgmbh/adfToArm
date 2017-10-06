using System.Runtime.Serialization;

namespace AdfToArm.Core.Models.Pipelines.Common
{
    public enum ExecutionPriorityOrders
    {
        [EnumMember(Value = "OldestFirst")]
        OldestFirst,
        [EnumMember(Value = "NewestFirst")]
        NewestFirst
    }
}
