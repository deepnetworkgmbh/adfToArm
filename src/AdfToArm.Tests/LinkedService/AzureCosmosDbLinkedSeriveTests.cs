using AdfToArm.Core;
using AdfToArm.Core.Models;
using AdfToArm.Core.Models.LinkedServices;
using AdfToArm.Core.Models.LinkedServices.LinkedServiceTypeProperties;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace AdfToArm.Tests.LinkedService
{
    [TestClass]
    public class AzureCosmosDbLinkedSeriveTests
    {
        private const string FullFilePath = @"./samples/linkedservices/azure_cosmosdb.json";

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
            result.value.ShouldBeAssignableTo<AzureCosmosDb>();
        }

        [TestMethod]
        public void AdfSerializer_ShouldParse_AllProperties()
        {
            // Arrange
            // Act
            var result = AdfSerializer.Deserialize(FullFilePath);
            var service = result.value as AzureCosmosDb;

            // Assert
            service.Name.ShouldNotBeNullOrWhiteSpace();
            service.Properties.Type.ShouldBe(LinkedServiceType.AzureCosmosDb);

            var props = service.Properties.TypeProperties.ShouldBeAssignableTo<AzureCosmosDbTypeProperties>();
            props.ConnectionString.ShouldNotBeNullOrWhiteSpace();
        }
    }
}
