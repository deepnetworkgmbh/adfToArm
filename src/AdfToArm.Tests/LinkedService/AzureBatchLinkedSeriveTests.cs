using AdfToArm.Core;
using AdfToArm.Core.Models;
using AdfToArm.Core.Models.LinkedServices;
using AdfToArm.Core.Models.LinkedServices.LinkedServiceTypeProperties;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace AdfToArm.Tests.LinkedService
{
    [TestClass]
    public class AzureBatchLinkedSeriveTests
    {
        private const string FullFilePath = @"./samples/linkedservices/azure_batch_full.json";
        private const string MinimumFilePath = @"./samples/linkedservices/azure_batch_min.json";

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
        public void LinkedServiceType_ShouldBe_AzureBatch()
        {
            // Arrange
            // Act
            var result = AdfSerializer.Deserialize(FullFilePath);

            // Assert
            result.value.ShouldBeAssignableTo<AzureBatch>();
        }

        [TestMethod]
        public void AdfSerializer_ShouldParse_AllProperties()
        {
            // Arrange
            // Act
            var result = AdfSerializer.Deserialize(FullFilePath);
            var service = result.value as AzureBatch;

            // Assert
            service.Schema.ShouldNotBeNullOrWhiteSpace();
            service.Name.ShouldNotBeNullOrWhiteSpace();
            service.Properties.Type.ShouldBe(LinkedServiceType.AzureBatch);
            service.Properties.HubName.ShouldNotBeNullOrWhiteSpace();

            var props = service.Properties.TypeProperties.ShouldBeAssignableTo<AzureBatchTypeProperties>();
            props.AccessKey.ShouldNotBeNullOrWhiteSpace();
            props.AccountName.ShouldNotBeNullOrWhiteSpace();
            props.LinkedServiceName.ShouldNotBeNullOrWhiteSpace();
            props.PoolName.ShouldNotBeNullOrWhiteSpace();
            props.BatchUri.ShouldNotBeNullOrWhiteSpace();
        }

        [TestMethod]
        public void AdfSerializer_ShouldParse_MinimumSetOfProperties()
        {
            // Arrange
            // Act
            var result = AdfSerializer.Deserialize(MinimumFilePath);
            var service = result.value as AzureBatch;

            // Assert
            service.Name.ShouldNotBeNullOrWhiteSpace();
            service.Properties.Type.ShouldBe(LinkedServiceType.AzureBatch);

            var props = service.Properties.TypeProperties.ShouldBeAssignableTo<AzureBatchTypeProperties>();
            props.AccessKey.ShouldNotBeNullOrWhiteSpace();
            props.AccountName.ShouldNotBeNullOrWhiteSpace();
            props.LinkedServiceName.ShouldNotBeNullOrWhiteSpace();
            props.PoolName.ShouldNotBeNullOrWhiteSpace();
            props.BatchUri.ShouldNotBeNullOrWhiteSpace();
        }
    }
}
