﻿using System.Runtime.Serialization;

namespace AdfToArm.Core.Models.Pipelines.ActivityProperties.CopyActivity.Sinks
{
    public enum CopySinkType
    {
        [EnumMember(Value = "BlobSink")]
        BlobSink,
        [EnumMember(Value = "SqlSink")]
        SqlSink,
        [EnumMember(Value = "AzureDataLakeStoreSink")]
        AzureDataLakeStoreSink
    }
}