using AdfToArm.Core;
using AdfToArm.Core.Models;
using AdfToArm.Core.Models.Common;
using AdfToArm.Core.Models.DataSets;
using AdfToArm.Core.Models.DataSets.Common;
using AdfToArm.Core.Models.DataSets.DataSetTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System.IO.Compression;

namespace AdfToArm.Tests.DataSet
{
    [TestClass]
    public class AzureDataLakeStoreDatasetTests
    {
        private const string FullFilePath = @"./samples/datasets/azure_datalake_full.json";
        private const string MinimumFilePath = @"./samples/datasets/azure_datalake_min.json";

        [TestMethod]
        public void AdfItemType_ShouldBe_DataSet()
        {
            // Arrange
            // Act
            var result = AdfSerializer.Deserialize(FullFilePath);

            // Assert
            result.type.ShouldBe(AdfItemType.DataSet);
        }

        [TestMethod]
        public void DataSetType_ShouldBe_AzureDataLakeStore()
        {
            // Arrange
            // Act
            var result = AdfSerializer.Deserialize(FullFilePath);

            // Assert
            result.value.ShouldBeAssignableTo<AzureDataLakeStore>();
        }

        [TestMethod]
        public void AdfSerializer_ShouldParse_TopLevelBlobProperties()
        {
            // Arrange
            // Act
            var result = AdfSerializer.Deserialize(FullFilePath);
            var dataset = result.value as AzureDataLakeStore;

            // Assert
            dataset.Name.ShouldNotBeNullOrWhiteSpace();
            dataset.Properties.Type.ShouldBe(DataSetType.AzureDataLakeStore);

            var props = dataset.Properties.TypeProperties.ShouldBeAssignableTo<AzureDataLakeStoreTypeProperties>();
            props.FolderPath.ShouldNotBeNullOrWhiteSpace();
            props.FileName.ShouldNotBeNullOrWhiteSpace();
        }

        [TestMethod]
        public void AdfSerializer_ShouldParse_PartitionedBy()
        {
            // Arrange
            // Act
            var result = AdfSerializer.Deserialize(FullFilePath);
            var props = (result.value as AzureDataLakeStore).Properties.TypeProperties as AzureDataLakeStoreTypeProperties;

            // Assert
            var patitionedBy = props.PartitionedBy.ShouldBeAssignableTo<PartitionedBy[]>();
            foreach (var item in patitionedBy)
            {
                item.Name.ShouldNotBeNullOrWhiteSpace();
                item.Value.Type.ShouldNotBeNullOrWhiteSpace();
                item.Value.Date.ShouldNotBeNullOrWhiteSpace();
                item.Value.Format.ShouldNotBeNullOrWhiteSpace();
            }
        }

        [TestMethod]
        public void AdfSerializer_ShouldParse_Format()
        {
            // Arrange
            // Act
            var result = AdfSerializer.Deserialize(FullFilePath);
            var props = (result.value as AzureDataLakeStore).Properties.TypeProperties as AzureDataLakeStoreTypeProperties;

            // Assert
            var format = props.Format.ShouldBeAssignableTo<FormatType>();
            format.Type.ShouldNotBe(FormatTypes.TextFormat, "Samples should not contain default value");
            format.ColumnDelimiter.ShouldNotBeNullOrWhiteSpace();
            format.RowDelimiter.ShouldNotBeNullOrEmpty();
            format.EscapeChar.ShouldNotBeNullOrEmpty();
            format.QuoteChar.ShouldNotBeNullOrEmpty();
            format.NullValue.ShouldNotBeNullOrWhiteSpace();
            format.EncodingName.ShouldNotBeNullOrWhiteSpace();
            format.FirstRowAsHeader.ShouldNotBeNull();
            format.SkipLineCount.ShouldNotBeNull();
            format.TreatEmptyAsNull.ShouldNotBeNull();
            format.FilePattern.ShouldNotBeNullOrWhiteSpace();
            format.JsonNodeReference.ShouldNotBeNullOrWhiteSpace();
            format.JsonPathDefinition.ShouldNotBeNullOrWhiteSpace();
            format.NestingSeparator.ShouldNotBeNull();
        }

        [TestMethod]
        public void AdfSerializer_ShouldParse_Compression()
        {
            // Arrange
            // Act
            var result = AdfSerializer.Deserialize(FullFilePath);
            var props = (result.value as AzureDataLakeStore).Properties.TypeProperties as AzureDataLakeStoreTypeProperties;

            // Assert
            var compression = props.Compression.ShouldBeAssignableTo<Compression>();
            compression.Type.ShouldNotBe(CompressionType.GZip, "Samples should not contain default GZip value");
            compression.Level.ShouldNotBe(CompressionLevel.Optimal, "Samples should not contain default Optimal value");
        }

        [TestMethod]
        public void AdfSerializer_ShouldParse_MinimumSetOfProperties()
        {
            // Arrange
            // Act
            var result = AdfSerializer.Deserialize(MinimumFilePath);
            var dataset = result.value as AzureDataLakeStore;

            // Assert
            dataset.Name.ShouldNotBeNullOrWhiteSpace();
            dataset.Properties.Type.ShouldBe(DataSetType.AzureDataLakeStore);
            dataset.Properties.LinkedServiceName.ShouldNotBeNullOrWhiteSpace();

            var availability = dataset.Properties.Availability.ShouldBeAssignableTo<Availability>();
            availability.Frequency.ShouldNotBe(Frequency.Minute, "Samples in general contain Hour frequency, but not default value");
            availability.Interval.ShouldBeGreaterThanOrEqualTo(1, "Samples in general contain interval >= 1");

            var props = dataset.Properties.TypeProperties.ShouldBeAssignableTo<AzureDataLakeStoreTypeProperties>();
            props.FolderPath.ShouldNotBeNullOrWhiteSpace();
        }
    }
}
