using System.Runtime.Serialization;

namespace AdfToArm.Models.DataSets.Common
{
    public enum FormatTypes
    {
        [EnumMember(Value = "TextFormat")]
        TextFormat,
        [EnumMember(Value = "JsonFormat")]
        JsonFormat,
        [EnumMember(Value = "AvroFormat")]
        AvroFormat,
        [EnumMember(Value = "OrcFormat")]
        OrcFormat,
        [EnumMember(Value = "ParquetFormat")]
        ParquetFormat
    }
}
