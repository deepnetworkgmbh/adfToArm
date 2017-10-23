using AdfToArm.Core;
using AdfToArm.Core.Models;
using AdfToArm.Core.Models.LinkedServices;
using AdfToArm.Core.Models.LinkedServices.LinkedServiceTypeProperties;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace AdfToArm.Tests.LinkedService
{
    [TestClass]
    public class AzureDataLakeAnalyticsLinkedSeriveTests
    {
        private const string FullServiceFilePath = @"./samples/linkedservices/azure_datalakeanalytics_service_full.json";
        private const string MinimumServiceFilePath = @"./samples/linkedservices/azure_datalakeanalytics_service_min.json";
        private const string FullUserFilePath = @"./samples/linkedservices/azure_datalakeanalytics_user_full.json";
        private const string MinimumUserFilePath = @"./samples/linkedservices/azure_datalakeanalytics_user_min.json";

        [TestMethod]
        public void AdfItemType_ShouldBe_LinkedService()
        {
            // Arrange
            // Act
            var result = AdfSerializer.Deserialize(FullServiceFilePath);

            // Assert
            result.type.ShouldBe(AdfItemType.LinkedService);
        }

        [TestMethod]
        public void LinkedServiceType_ShouldBe_AzureDataLakeAnalytics()
        {
            // Arrange
            // Act
            var result = AdfSerializer.Deserialize(FullServiceFilePath);

            // Assert
            result.value.ShouldBeAssignableTo<AzureDataLakeAnalytics>();
        }

        [TestMethod]
        public void AdfSerializer_ShouldParse_AllServiceAuthenticationProperties()
        {
            // Arrange
            // Act
            var result = AdfSerializer.Deserialize(FullServiceFilePath);
            var service = result.value as AzureDataLakeAnalytics;

            // Assert
            service.Schema.ShouldNotBeNullOrWhiteSpace();
            service.Name.ShouldNotBeNullOrWhiteSpace();
            service.Properties.Type.ShouldBe(LinkedServiceType.AzureDataLakeAnalytics);
            service.Properties.HubName.ShouldNotBeNullOrWhiteSpace();

            var props = service.Properties.TypeProperties.ShouldBeAssignableTo<AzureDataLakeAnalyticsTypeProperties>();
            props.AccountName.ShouldNotBeNullOrWhiteSpace();
            props.DataLakeAnalyticsUri.ShouldNotBeNullOrWhiteSpace();
            props.SubscriptionId.ShouldNotBeNullOrWhiteSpace();
            props.ResourceGroupName.ShouldNotBeNullOrWhiteSpace();
            props.ServicePrincipalId.ShouldNotBeNullOrWhiteSpace();
            props.ServicePrincipalKey.ShouldNotBeNullOrWhiteSpace();
            props.Tenant.ShouldNotBeNullOrWhiteSpace();

            props.Authorization.ShouldBeNullOrEmpty();
            props.SessionId.ShouldBeNullOrEmpty();
        }

        [TestMethod]
        public void AdfSerializer_ShouldParse_MinimumServiceAuthenticationProperties()
        {
            // Arrange
            // Act
            var result = AdfSerializer.Deserialize(MinimumServiceFilePath);
            var service = result.value as AzureDataLakeAnalytics;

            // Assert
            service.Name.ShouldNotBeNullOrWhiteSpace();
            service.Properties.Type.ShouldBe(LinkedServiceType.AzureDataLakeAnalytics);

            var props = service.Properties.TypeProperties.ShouldBeAssignableTo<AzureDataLakeAnalyticsTypeProperties>();
            props.AccountName.ShouldNotBeNullOrWhiteSpace();
            props.ServicePrincipalId.ShouldNotBeNullOrWhiteSpace();
            props.ServicePrincipalKey.ShouldNotBeNullOrWhiteSpace();
            props.Tenant.ShouldNotBeNullOrWhiteSpace();
        }

        [TestMethod]
        public void AdfSerializer_ShouldParse_AllUserAuthenticationProperties()
        {
            // Arrange
            // Act
            var result = AdfSerializer.Deserialize(FullUserFilePath);
            var service = result.value as AzureDataLakeAnalytics;

            // Assert
            service.Schema.ShouldNotBeNullOrWhiteSpace();
            service.Name.ShouldNotBeNullOrWhiteSpace();
            service.Properties.Type.ShouldBe(LinkedServiceType.AzureDataLakeAnalytics);
            service.Properties.HubName.ShouldNotBeNullOrWhiteSpace();

            var props = service.Properties.TypeProperties.ShouldBeAssignableTo<AzureDataLakeAnalyticsTypeProperties>();
            props.AccountName.ShouldNotBeNullOrWhiteSpace();
            props.DataLakeAnalyticsUri.ShouldNotBeNullOrWhiteSpace();
            props.SubscriptionId.ShouldNotBeNullOrWhiteSpace();
            props.ResourceGroupName.ShouldNotBeNullOrWhiteSpace();
            props.Authorization.ShouldNotBeNullOrWhiteSpace();
            props.SessionId.ShouldNotBeNullOrWhiteSpace();

            props.ServicePrincipalId.ShouldBeNullOrEmpty();
            props.ServicePrincipalKey.ShouldBeNullOrEmpty();
            props.Tenant.ShouldBeNullOrEmpty();
        }

        [TestMethod]
        public void AdfSerializer_ShouldParse_MinimumUserAuthenticationProperties()
        {
            // Arrange
            // Act
            var result = AdfSerializer.Deserialize(MinimumUserFilePath);
            var service = result.value as AzureDataLakeAnalytics;

            // Assert
            service.Name.ShouldNotBeNullOrWhiteSpace();
            service.Properties.Type.ShouldBe(LinkedServiceType.AzureDataLakeAnalytics);

            var props = service.Properties.TypeProperties.ShouldBeAssignableTo<AzureDataLakeAnalyticsTypeProperties>();
            props.AccountName.ShouldNotBeNullOrWhiteSpace();
            props.Authorization.ShouldNotBeNullOrWhiteSpace();
            props.SessionId.ShouldNotBeNullOrWhiteSpace();

            props.ServicePrincipalId.ShouldBeNullOrEmpty();
            props.ServicePrincipalKey.ShouldBeNullOrEmpty();
            props.Tenant.ShouldBeNullOrEmpty();
        }
    }
}
