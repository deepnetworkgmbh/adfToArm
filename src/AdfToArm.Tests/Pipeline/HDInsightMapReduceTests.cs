using AdfToArm.Core;
using AdfToArm.Core.Models;
using AdfToArm.Core.Models.Pipelines;
using AdfToArm.Core.Models.Pipelines.ActivityProperties;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace AdfToArm.Tests.Dataset
{
    [TestClass]
    public class HDInsightMapReduceTests
    {
        private const string FilePath = @"./samples/pipelines/activity_hdi_mapreduce.json";

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
            activity.Type.ShouldBe(ActivityType.HDInsightMapReduce);
            activity.Outputs.ShouldNotBeEmpty();
            activity.LinkedServiceName.ShouldNotBeNullOrWhiteSpace();

            var props = activity.TypeProperties.ShouldBeAssignableTo<HDInsightMapReduceTypeProperties>();
            props.ClassName.ShouldNotBeNullOrWhiteSpace();
            props.JarFilePath.ShouldNotBeNullOrWhiteSpace();
            props.JarLinkedService.ShouldNotBeNullOrWhiteSpace();

            props.Arguments.ShouldNotBeEmpty();
            foreach (var param in props.Arguments)
                param.ShouldNotBeNullOrWhiteSpace();
        }
    }
}
