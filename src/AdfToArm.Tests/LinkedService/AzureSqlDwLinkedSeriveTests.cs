using AdfToArm.Core;
using AdfToArm.Core.Models;
using AdfToArm.Core.Models.LinkedServices;
using AdfToArm.Core.Models.LinkedServices.LinkedServiceTypeProperties;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace AdfToArm.Tests.LinkedService
{
    [TestClass]
    public class AzureSqlDwLinkedSeriveTests
    {
        private const string FullFilePath = @"./samples/linkedservices/azure_sqldw.json";

        [TestMethod]
        public void AdfItemType_ShouldBe_LinkedService()
        {
            // Arrange
            // Act
            var result = AdfSerializer.Deserialize(FullFilePath);

            // Assert
            result.type.ShouldBe(AdfItemType.LinkedService);
        }

        [TestMethod]
        public void LinkedServiceType_ShouldBe_AzureSqlDW()
        {
            // Arrange
            // Act
            var result = AdfSerializer.Deserialize(FullFilePath);

            // Assert
            result.value.ShouldBeAssignableTo<AzureSqlDW>();
        }

        [TestMethod]
        public void AdfSerializer_ShouldParse_AllProperties()
        {
            // Arrange
            // Act
            var result = AdfSerializer.Deserialize(FullFilePath);
            var service = result.value as AzureSqlDW;

            // Assert
            service.Name.ShouldNotBeNullOrWhiteSpace();
            service.Properties.Type.ShouldBe(LinkedServiceType.AzureSqlDW);

            var props = service.Properties.TypeProperties.ShouldBeAssignableTo<AzureSqlDWTypeProperties>();
            props.ConnectionString.ShouldNotBeNullOrWhiteSpace();
        }
    }
}
