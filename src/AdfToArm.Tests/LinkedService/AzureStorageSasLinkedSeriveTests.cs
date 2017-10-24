using AdfToArm.Core;
using AdfToArm.Core.Models;
using AdfToArm.Core.Models.LinkedServices;
using AdfToArm.Core.Models.LinkedServices.LinkedServiceTypeProperties;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace AdfToArm.Tests.LinkedService
{
    [TestClass]
    public class AzureStorageSasLinkedSeriveTests
    {
        private const string FullFilePath = @"./samples/linkedservices/azure_storagesas.json";

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
        public void LinkedServiceType_ShouldBe_AzureStorageSas()
        {
            // Arrange
            // Act
            var result = AdfSerializer.Deserialize(FullFilePath);

            // Assert
            result.value.ShouldBeAssignableTo<AzureStorageSas>();
        }

        [TestMethod]
        public void AdfSerializer_ShouldParse_AllProperties()
        {
            // Arrange
            // Act
            var result = AdfSerializer.Deserialize(FullFilePath);
            var service = result.value as AzureStorageSas;

            // Assert
            service.Name.ShouldNotBeNullOrWhiteSpace();
            service.Properties.Type.ShouldBe(LinkedServiceType.AzureStorageSas);

            var props = service.Properties.TypeProperties.ShouldBeAssignableTo<AzureStorageSasTypeProperties>();
            props.SasUri.ShouldNotBeNullOrWhiteSpace();
        }
    }
}
