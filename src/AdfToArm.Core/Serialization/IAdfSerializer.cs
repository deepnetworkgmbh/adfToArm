using AdfToArm.Core.Models;

namespace AdfToArm.Core.Serialization
{
    public interface IAdfSerializer
    {
        (AdfItemType type, object value) Deserialize();
    }
}
