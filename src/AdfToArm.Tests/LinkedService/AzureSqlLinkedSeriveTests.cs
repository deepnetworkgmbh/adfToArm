using AdfToArm.Core;
using AdfToArm.Core.Models;
using AdfToArm.Core.Models.LinkedServices;
using AdfToArm.Core.Models.LinkedServices.LinkedServiceTypeProperties;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace AdfToArm.Tests.LinkedService
{
    [TestClass]
    public class AzureSqlLinkedSeriveTests
    {
        private const string FullFilePath = @"./samples/linkedservices/azure_sql_full.json";
        private const string MinimumFilePath = @"./samples/linkedservices/azure_sql_min.json";

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
        public void LinkedServiceType_ShouldBe_AzureSqlDatabase()
        {
            // Arrange
            // Act
            var result = AdfSerializer.Deserialize(FullFilePath);

            // Assert
            result.value.ShouldBeAssignableTo<AzureSqlDatabase>();
        }

        [TestMethod]
        public void AdfSerializer_ShouldParse_AllProperties()
        {
            // Arrange
            // Act
            var result = AdfSerializer.Deserialize(FullFilePath);
            var service = result.value as AzureSqlDatabase;

            // Assert
            service.Schema.ShouldNotBeNullOrWhiteSpace();
            service.Name.ShouldNotBeNullOrWhiteSpace();
            service.Properties.Type.ShouldBe(LinkedServiceType.AzureSqlDatabase);
            service.Properties.HubName.ShouldNotBeNullOrWhiteSpace();

            var props = service.Properties.TypeProperties.ShouldBeAssignableTo<AzureSqlDatabaseTypeProperties>();
            props.ConnectionString.ShouldNotBeNullOrWhiteSpace();
        }

        [TestMethod]
        public void AdfSerializer_ShouldParse_MinimumSetOfProperties()
        {
            // Arrange
            // Act
            var result = AdfSerializer.Deserialize(MinimumFilePath);
            var service = result.value as AzureSqlDatabase;

            // Assert
            service.Schema.ShouldNotBeNullOrWhiteSpace();
            service.Name.ShouldNotBeNullOrWhiteSpace();
            service.Properties.Type.ShouldBe(LinkedServiceType.AzureSqlDatabase);

            var props = service.Properties.TypeProperties.ShouldBeAssignableTo<AzureSqlDatabaseTypeProperties>();
            props.ConnectionString.ShouldNotBeNullOrWhiteSpace();
        }
    }
}
