using System.Runtime.Serialization;

namespace AdfToArm.Models.DataSets.Common
{
    public enum CompressionType
    {
        [EnumMember(Value = "GZip")]
        GZip,
        [EnumMember(Value = "Deflate")]
        Deflate,
        [EnumMember(Value = "BZip2")]
        BZip2,
        [EnumMember(Value = "ZipDeflate")]
        ZipDeflate
    }
}
