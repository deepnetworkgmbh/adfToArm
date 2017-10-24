using AdfToArm.Core;
using AdfToArm.Core.Models;
using AdfToArm.Core.Models.LinkedServices;
using AdfToArm.Core.Models.LinkedServices.LinkedServiceTypeProperties;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System;

namespace AdfToArm.Tests.LinkedService
{
    [TestClass]
    public class HDInsightOnDemandLinkedSeriveTests
    {
        private const string FullFilePath = @"./samples/linkedservices/hdinsight_ondemand_full.json";
        private const string MinimumFilePath = @"./samples/linkedservices/hdinsight_ondemand_min.json";

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
        public void LinkedServiceType_ShouldBe_HDInsightOnDemand()
        {
            // Arrange
            // Act
            var result = AdfSerializer.Deserialize(FullFilePath);

            // Assert
            result.value.ShouldBeAssignableTo<HDInsightOnDemand>();
        }

        [TestMethod]
        public void AdfSerializer_ShouldParse_AllProperties()
        {
            // Arrange
            // Act
            var result = AdfSerializer.Deserialize(FullFilePath);
            var service = result.value as HDInsightOnDemand;

            // Assert
            service.Name.ShouldNotBeNullOrWhiteSpace();
            service.Properties.Type.ShouldBe(LinkedServiceType.HDInsightOnDemand);

            var props = service.Properties.TypeProperties.ShouldBeAssignableTo<HDInsightOnDemandTypeProperties>();
            props.ClusterSize.ShouldBeGreaterThanOrEqualTo(1);
            props.TimeToLive.ShouldBeGreaterThan(TimeSpan.FromSeconds(1));
            props.Version.ShouldNotBeNullOrWhiteSpace();
            props.LinkedServiceName.ShouldNotBeNullOrWhiteSpace();
            props.AdditionalLinkedServiceNames.ShouldNotBeEmpty();
            props.OsType.ShouldNotBeNullOrWhiteSpace();
            props.HcatalogLinkedServiceName.ShouldNotBeNullOrWhiteSpace();
            props.CoreConfiguration.ShouldNotBeNull();
            props.HBaseConfiguration.ShouldNotBeNull();
            props.HdfsConfiguration.ShouldNotBeNull();
            props.HiveConfiguration.ShouldNotBeNull();
            props.MapReduceConfiguration.ShouldNotBeNull();
            props.OozieConfiguration.ShouldNotBeNull();
            props.StormConfiguration.ShouldNotBeNull();
            props.YarnConfiguration.ShouldNotBeNull();
            props.HeadNodeSize.ShouldNotBeNullOrWhiteSpace();
            props.DataNodeSize.ShouldNotBeNullOrWhiteSpace();
            props.ZookeeperNodeSize.ShouldNotBeNullOrWhiteSpace();
        }

        [TestMethod]
        public void AdfSerializer_ShouldParse_MinimumSetOfProperties()
        {
            // Arrange
            // Act
            var result = AdfSerializer.Deserialize(MinimumFilePath);
            var service = result.value as HDInsightOnDemand;

            // Assert
            service.Name.ShouldNotBeNullOrWhiteSpace();
            service.Properties.Type.ShouldBe(LinkedServiceType.HDInsightOnDemand);

            var props = service.Properties.TypeProperties.ShouldBeAssignableTo<HDInsightOnDemandTypeProperties>();
            props.ClusterSize.ShouldBeGreaterThanOrEqualTo(1);
            props.TimeToLive.ShouldBeGreaterThan(TimeSpan.FromSeconds(1));
            props.LinkedServiceName.ShouldNotBeNullOrWhiteSpace();
        }
    }
}
