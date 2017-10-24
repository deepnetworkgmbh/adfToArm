using AdfToArm.Core;
using AdfToArm.Core.Models;
using AdfToArm.Core.Models.Common;
using AdfToArm.Core.Models.DataSets.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace AdfToArm.Tests.Dataset
{
    [TestClass]
    public class DatasetTests
    {
        private const string FullFilePath = @"./samples/datasets/dataset_full.json";

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
        public void AdfSerializer_ShouldParse_AllTopLevelProperties()
        {
            // Arrange
            // Act
            var result = AdfSerializer.Deserialize(FullFilePath);
            var dataset = result.value as Core.Models.DataSets.DataSet;

            // Assert
            dataset.Schema.ShouldNotBeNullOrWhiteSpace();
            dataset.Name.ShouldNotBeNullOrWhiteSpace();
            dataset.Properties.LinkedServiceName.ShouldNotBeNullOrWhiteSpace();
            dataset.Properties.Published.ShouldNotBeNull();
            dataset.Properties.External.ShouldNotBeNull();
        }

        [TestMethod]
        public void AdfSerializer_ShouldParse_StructureItems()
        {
            // Arrange
            // Act
            var result = AdfSerializer.Deserialize(FullFilePath);
            var dataset = result.value as Core.Models.DataSets.DataSet;

            // Assert
            var structure = dataset.Properties.Structure.ShouldBeAssignableTo<StructureItem[]>();
            foreach (var item in structure)
            {
                item.Name.ShouldNotBeNullOrWhiteSpace();
                item.Type.ShouldNotBeNullOrWhiteSpace();
                item.Culture.ShouldNotBeNullOrWhiteSpace();
                if (item.Type == "DateTime" || item.Type == "DateTimeOffset")
                    item.Format.ShouldNotBeNullOrWhiteSpace();
            }
        }

        [TestMethod]
        public void AdfSerializer_ShouldParse_Availability()
        {
            // Arrange
            // Act
            var result = AdfSerializer.Deserialize(FullFilePath);
            var dataset = result.value as Core.Models.DataSets.DataSet;

            // Assert
            var availability = dataset.Properties.Availability.ShouldBeAssignableTo<Availability>();
            availability.Frequency.ShouldNotBe(Frequency.Minute, "Samples in general contain Hour frequency, but not default value");
            availability.Interval.ShouldBeGreaterThanOrEqualTo(1, "Samples in general contain interval >= 1");
            availability.Style.ShouldNotBeNull();
            availability.AnchorDateTime.ShouldNotBeNull();
            availability.Offset.ShouldNotBeNull();
        }

        [TestMethod]
        public void AdfSerializer_ShouldParse_Policy()
        {
            // Arrange
            // Act
            var result = AdfSerializer.Deserialize(FullFilePath);
            var dataset = result.value as Core.Models.DataSets.DataSet;

            // Assert
            var policy = dataset.Properties.Policy.ShouldBeAssignableTo<Policy>();
            policy.Validation.MinimumSizeMB.ShouldNotBeNull();
            policy.Validation.MinimumRows.ShouldNotBeNull();
            policy.External.DataDelay.ShouldNotBeNull();
            policy.External.RetryInterval.ShouldNotBeNull();
            policy.External.RetryTimeout.ShouldNotBeNull();
            policy.External.MaximumRetry.ShouldNotBeNull();
        }
    }
}
