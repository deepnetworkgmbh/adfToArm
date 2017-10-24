using AdfToArm.Core;
using AdfToArm.Core.Models;
using AdfToArm.Core.Models.DataSets;
using AdfToArm.Core.Models.DataSets.DataSetTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace AdfToArm.Tests.DataSet
{
    [TestClass]
    public class AzureSqlDwTableDatasetTests
    {
        private const string FullFilePath = @"./samples/datasets/azure_sqldw.json";

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
        public void DataSetType_ShouldBe_AzureSqlDwTable()
        {
            // Arrange
            // Act
            var result = AdfSerializer.Deserialize(FullFilePath);

            // Assert
            result.value.ShouldBeAssignableTo<AzureSqlDwTable>();
        }

        [TestMethod]
        public void AdfSerializer_ShouldParse_Properties()
        {
            // Arrange
            // Act
            var result = AdfSerializer.Deserialize(FullFilePath);
            var dataset = result.value as AzureSqlDwTable;

            // Assert
            dataset.Name.ShouldNotBeNullOrWhiteSpace();
            dataset.Properties.Type.ShouldBe(DataSetType.AzureSqlDwTable);

            var props = dataset.Properties.TypeProperties.ShouldBeAssignableTo<AzureSqlDwTableTypeProperties>();
            props.TableName.ShouldNotBeNullOrWhiteSpace();
        }
    }
}
