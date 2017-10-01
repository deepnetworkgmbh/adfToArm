﻿using System.Runtime.Serialization;

namespace AdfToArm.Models.DataSets
{
    public enum DataSetType
    {
        [EnumMember(Value = "AzureBlob")]
        AzureBlob,
        [EnumMember(Value = "AzureSqlTable")]
        AzureSqlTable,
        [EnumMember(Value = "AzureDataLakeStore")]
        AzureDataLakeStore
    }
}
