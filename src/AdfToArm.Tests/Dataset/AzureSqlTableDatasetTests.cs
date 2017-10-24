using AdfToArm.Core;
using AdfToArm.Core.Models;
using AdfToArm.Core.Models.DataSets;
using AdfToArm.Core.Models.DataSets.DataSetTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace AdfToArm.Tests.DataSet
{
    [TestClass]
    public class AzureSqlTableDatasetTests
    {
        private const string FullFilePath = @"./samples/datasets/azure_sql.json";

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
        public void DataSetType_ShouldBe_AzureSqlTable()
        {
            // Arrange
            // Act
            var result = AdfSerializer.Deserialize(FullFilePath);

            // Assert
            result.value.ShouldBeAssignableTo<AzureSqlTable>();
        }

        [TestMethod]
        public void AdfSerializer_ShouldParse_Properties()
        {
            // Arrange
            // Act
            var result = AdfSerializer.Deserialize(FullFilePath);
            var dataset = result.value as AzureSqlTable;

            // Assert
            dataset.Name.ShouldNotBeNullOrWhiteSpace();
            dataset.Properties.Type.ShouldBe(DataSetType.AzureSqlTable);

            var props = dataset.Properties.TypeProperties.ShouldBeAssignableTo<AzureSqlTableTypeProperties>();
            props.TableName.ShouldNotBeNullOrWhiteSpace();
        }
    }
}
