using AdfToArm.Core;
using AdfToArm.Core.Models;
using AdfToArm.Core.Models.DataSets;
using AdfToArm.Core.Models.DataSets.DataSetTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace AdfToArm.Tests.DataSet
{
    [TestClass]
    public class AzureSearchIndexDatasetTests
    {
        private const string FullFilePath = @"./samples/datasets/azure_searchindex.json";

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
        public void DataSetType_ShouldBe_AzureSearchIndex()
        {
            // Arrange
            // Act
            var result = AdfSerializer.Deserialize(FullFilePath);

            // Assert
            result.value.ShouldBeAssignableTo<AzureSearchIndex>();
        }

        [TestMethod]
        public void AdfSerializer_ShouldParse_Properties()
        {
            // Arrange
            // Act
            var result = AdfSerializer.Deserialize(FullFilePath);
            var dataset = result.value as AzureSearchIndex;

            // Assert
            dataset.Name.ShouldNotBeNullOrWhiteSpace();
            dataset.Properties.Type.ShouldBe(DataSetType.AzureSearchIndex);

            var props = dataset.Properties.TypeProperties.ShouldBeAssignableTo<AzureSearchIndexTypeProperties>();
            props.IndexName.ShouldNotBeNullOrWhiteSpace();
        }
    }
}
