using AdfToArm.Core;
using AdfToArm.Core.Models;
using AdfToArm.Core.Models.DataSets;
using AdfToArm.Core.Models.DataSets.DataSetTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace AdfToArm.Tests.DataSet
{
    [TestClass]
    public class AzureTableDatasetTests
    {
        private const string FullFilePath = @"./samples/datasets/azure_table.json";

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
        public void DataSetType_ShouldBe_AzureTable()
        {
            // Arrange
            // Act
            var result = AdfSerializer.Deserialize(FullFilePath);

            // Assert
            result.value.ShouldBeAssignableTo<AzureTable>();
        }

        [TestMethod]
        public void AdfSerializer_ShouldParse_Properties()
        {
            // Arrange
            // Act
            var result = AdfSerializer.Deserialize(FullFilePath);
            var dataset = result.value as AzureTable;

            // Assert
            dataset.Name.ShouldNotBeNullOrWhiteSpace();
            dataset.Properties.Type.ShouldBe(DataSetType.AzureTable);

            var props = dataset.Properties.TypeProperties.ShouldBeAssignableTo<AzureTableTypeProperties>();
            props.TableName.ShouldNotBeNullOrWhiteSpace();
        }
    }
}
