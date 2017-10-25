using AdfToArm.Core;
using AdfToArm.Core.Models;
using AdfToArm.Core.Models.Pipelines;
using AdfToArm.Core.Models.Pipelines.ActivityProperties;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace AdfToArm.Tests.Dataset
{
    [TestClass]
    public class HDInsightStreamingTests
    {
        private const string FilePath = @"./samples/pipelines/activity_hdi_streaming.json";

        [TestMethod]
        public void AdfItemType_ShouldBe_Pipeline()
        {
            // Arrange
            // Act
            var result = AdfSerializer.Deserialize(FilePath);

            // Assert
            result.type.ShouldBe(AdfItemType.Pipeline);
        }

        [TestMethod]
        public void AdfSerializer_ShouldParse_ScriptPath()
        {
            // Arrange
            // Act
            var result = AdfSerializer.Deserialize(FilePath);
            var activity = (result.value as Pipeline).Properties.Activities[0];

            // Assert
            activity.Name.ShouldNotBeNullOrWhiteSpace();
            activity.Type.ShouldBe(ActivityType.HDInsightStreaming);
            activity.Outputs.ShouldNotBeEmpty();
            activity.LinkedServiceName.ShouldNotBeNullOrWhiteSpace();

            var props = activity.TypeProperties.ShouldBeAssignableTo<HDInsightStreamingTypeProperties>();
            props.Mapper.ShouldNotBeNullOrWhiteSpace();
            props.Reducer.ShouldNotBeNullOrWhiteSpace();
            props.Input.ShouldNotBeNullOrWhiteSpace();
            props.Output.ShouldNotBeNullOrWhiteSpace();
            props.FileLinkedService.ShouldNotBeNullOrWhiteSpace();
            props.GetDebugInfo.ShouldNotBeNull();

            props.FilePaths.ShouldNotBeEmpty();
            foreach (var param in props.FilePaths)
                param.ShouldNotBeNullOrWhiteSpace();

            props.Arguments.ShouldNotBeEmpty();
            foreach (var param in props.Arguments)
                param.ShouldNotBeNullOrWhiteSpace();
        }
    }
}
