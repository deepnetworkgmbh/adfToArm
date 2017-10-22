using AdfToArm.Core;
using AdfToArm.Core.Models;
using AdfToArm.Core.Models.LinkedServices;
using AdfToArm.Core.Models.LinkedServices.LinkedServiceTypeProperties;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace AdfToArm.Tests.LinkedService
{
    [TestClass]
    public class HDInsightLinkedSeriveTests
    {
        private const string FullFilePath = @"./samples/linkedservices/hdinsight_full.json";
        private const string MinimumFilePath = @"./samples/linkedservices/hdinsight_min.json";

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
        public void LinkedServiceType_ShouldBe_HDInsight()
        {
            // Arrange
            // Act
            var result = AdfSerializer.Deserialize(FullFilePath);

            // Assert
            result.value.ShouldBeAssignableTo<HDInsight>();
        }

        [TestMethod]
        public void AdfSerializer_ShouldParse_AllProperties()
        {
            // Arrange
            // Act
            var result = AdfSerializer.Deserialize(FullFilePath);
            var service = result.value as HDInsight;

            // Assert
            service.Schema.ShouldNotBeNullOrWhiteSpace();
            service.Name.ShouldNotBeNullOrWhiteSpace();
            service.Properties.Type.ShouldBe(LinkedServiceType.HDInsight);
            service.Properties.HubName.ShouldNotBeNullOrWhiteSpace();

            var props = service.Properties.TypeProperties.ShouldBeAssignableTo<HDInsightTypeProperties>();
            props.ClusterUri.ShouldNotBeNullOrWhiteSpace();
            props.UserName.ShouldNotBeNullOrWhiteSpace();
            props.Password.ShouldNotBeNullOrWhiteSpace();
            props.LinkedServiceName.ShouldNotBeNullOrWhiteSpace();
        }

        [TestMethod]
        public void AdfSerializer_ShouldParse_MinimumSetOfProperties()
        {
            // Arrange
            // Act
            var result = AdfSerializer.Deserialize(MinimumFilePath);
            var service = result.value as HDInsight;

            // Assert
            service.Schema.ShouldNotBeNullOrWhiteSpace();
            service.Name.ShouldNotBeNullOrWhiteSpace();
            service.Properties.Type.ShouldBe(LinkedServiceType.HDInsight);

            var props = service.Properties.TypeProperties.ShouldBeAssignableTo<HDInsightTypeProperties>();
            props.ClusterUri.ShouldNotBeNullOrWhiteSpace();
            props.UserName.ShouldNotBeNullOrWhiteSpace();
            props.Password.ShouldNotBeNullOrWhiteSpace();
            props.LinkedServiceName.ShouldNotBeNullOrWhiteSpace();
        }
    }
}
