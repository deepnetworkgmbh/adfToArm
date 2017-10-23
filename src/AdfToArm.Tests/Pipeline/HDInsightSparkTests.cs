using AdfToArm.Core;
using AdfToArm.Core.Models;
using AdfToArm.Core.Models.Pipelines;
using AdfToArm.Core.Models.Pipelines.ActivityProperties;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace AdfToArm.Tests.Dataset
{
    [TestClass]
    public class HDInsightSparkTests
    {
        private const string FullFilePath = @"./samples/pipelines/activity_hdi_spark_full.json";
        private const string MinFilePath = @"./samples/pipelines/activity_hdi_spark_min.json";

        [TestMethod]
        public void AdfItemType_ShouldBe_Pipeline()
        {
            // Arrange
            // Act
            var result = AdfSerializer.Deserialize(FullFilePath);

            // Assert
            result.type.ShouldBe(AdfItemType.Pipeline);
        }

        [TestMethod]
        public void AdfSerializer_ShouldParse_AllProperties()
        {
            // Arrange
            // Act
            var result = AdfSerializer.Deserialize(FullFilePath);
            var activity = (result.value as Pipeline).Properties.Activities[0];

            // Assert
            activity.Name.ShouldNotBeNullOrWhiteSpace();
            activity.Type.ShouldBe(ActivityType.HDInsightSpark);
            activity.Inputs.ShouldNotBeEmpty();
            activity.Outputs.ShouldNotBeEmpty();
            activity.LinkedServiceName.ShouldNotBeNullOrWhiteSpace();

            var props = activity.TypeProperties.ShouldBeAssignableTo<HDInsightSparkTypeProperties>();
            props.RootPath.ShouldNotBeNullOrWhiteSpace();
            props.EntryFilePath.ShouldNotBeNullOrWhiteSpace();
            props.ClassName.ShouldNotBeNullOrWhiteSpace();
            props.ProxyUser.ShouldNotBeNullOrWhiteSpace();
            props.SparkJobLinkedService.ShouldNotBeNullOrWhiteSpace();
            props.SparkConfig.ShouldNotBeNull();

            props.Arguments.ShouldNotBeEmpty();
            foreach (var param in props.Arguments)
                param.ShouldNotBeNullOrWhiteSpace();
        }

        [TestMethod]
        public void AdfSerializer_ShouldParse_MinSetOfProperties()
        {
            // Arrange
            // Act
            var result = AdfSerializer.Deserialize(MinFilePath);
            var activity = (result.value as Pipeline).Properties.Activities[0];

            // Assert
            activity.Name.ShouldNotBeNullOrWhiteSpace();
            activity.Type.ShouldBe(ActivityType.HDInsightSpark);
            activity.Inputs.ShouldBeNull();
            activity.Outputs.ShouldNotBeEmpty();
            activity.LinkedServiceName.ShouldNotBeNullOrWhiteSpace();

            var props = activity.TypeProperties.ShouldBeAssignableTo<HDInsightSparkTypeProperties>();
            props.RootPath.ShouldNotBeNullOrWhiteSpace();
            props.EntryFilePath.ShouldNotBeNullOrWhiteSpace();
            props.ClassName.ShouldBeNullOrWhiteSpace();
            props.ProxyUser.ShouldBeNullOrWhiteSpace();
            props.SparkJobLinkedService.ShouldBeNullOrWhiteSpace();
            props.SparkConfig.ShouldBeNull();
            props.Arguments.ShouldBeNull();
        }
    }
}
