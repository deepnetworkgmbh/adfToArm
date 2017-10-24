using AdfToArm.Core;
using AdfToArm.Core.Models;
using AdfToArm.Core.Models.LinkedServices;
using AdfToArm.Core.Models.LinkedServices.LinkedServiceTypeProperties;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace AdfToArm.Tests.LinkedService
{
    [TestClass]
    public class AzureSearchLinkedSeriveTests
    {
        private const string FullFilePath = @"./samples/linkedservices/azure_search.json";

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
        public void LinkedServiceType_ShouldBe_AzureSearchIndex()
        {
            // Arrange
            // Act
            var result = AdfSerializer.Deserialize(FullFilePath);

            // Assert
            result.value.ShouldBeAssignableTo<AzureSearch>();
        }

        [TestMethod]
        public void AdfSerializer_ShouldParse_AllProperties()
        {
            // Arrange
            // Act
            var result = AdfSerializer.Deserialize(FullFilePath);
            var service = result.value as AzureSearch;

            // Assert
            service.Name.ShouldNotBeNullOrWhiteSpace();
            service.Properties.Type.ShouldBe(LinkedServiceType.AzureSearch);

            var props = service.Properties.TypeProperties.ShouldBeAssignableTo<AzureSearchTypeProperties>();
            props.Url.ShouldNotBeNullOrWhiteSpace();
            props.Key.ShouldNotBeNullOrWhiteSpace();
        }
    }
}
