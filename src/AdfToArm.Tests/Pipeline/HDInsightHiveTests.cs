using AdfToArm.Core;
using AdfToArm.Core.Models;
using AdfToArm.Core.Models.Pipelines;
using AdfToArm.Core.Models.Pipelines.ActivityProperties;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace AdfToArm.Tests.Dataset
{
    [TestClass]
    public class HDInsightHiveTests
    {
        private const string ScriptInlineFile = @"./samples/pipelines/activity_hdi_hive_inline.json";
        private const string ScriptPathFile = @"./samples/pipelines/activity_hdi_hive_path.json";

        [TestMethod]
        public void AdfItemType_ShouldBe_Pipeline()
        {
            // Arrange
            // Act
            var result = AdfSerializer.Deserialize(ScriptPathFile);

            // Assert
            result.type.ShouldBe(AdfItemType.Pipeline);
        }

        [TestMethod]
        public void AdfSerializer_ShouldParse_ScriptPath()
        {
            // Arrange
            // Act
            var result = AdfSerializer.Deserialize(ScriptPathFile);
            var activity = (result.value as Pipeline).Properties.Activities[0];

            // Assert
            activity.Name.ShouldNotBeNullOrWhiteSpace();
            activity.Type.ShouldBe(ActivityType.HDInsightHive);
            activity.Outputs.ShouldNotBeEmpty();
            activity.LinkedServiceName.ShouldNotBeNullOrWhiteSpace();

            var props = activity.TypeProperties.ShouldBeAssignableTo<HDInsightHiveTypeProperties>();
            props.ScriptPath.ShouldNotBeNullOrWhiteSpace();
            props.ScriptLinkedService.ShouldNotBeNullOrWhiteSpace();
            props.Script.ShouldBeNullOrWhiteSpace();

            props.Defines.ShouldNotBeEmpty();
            foreach (var param in props.Defines)
            {
                param.Key.ShouldNotBeNullOrWhiteSpace();
                param.Value.ShouldNotBeNullOrWhiteSpace();
            }
        }

        [TestMethod]
        public void AdfSerializer_ShouldParse_InlineScript()
        {
            // Arrange
            // Act
            var result = AdfSerializer.Deserialize(ScriptInlineFile);
            var activity = (result.value as Pipeline).Properties.Activities[0];

            // Assert
            activity.Name.ShouldNotBeNullOrWhiteSpace();
            activity.Type.ShouldBe(ActivityType.HDInsightHive);
            activity.Outputs.ShouldNotBeEmpty();
            activity.LinkedServiceName.ShouldNotBeNullOrWhiteSpace();

            var props = activity.TypeProperties.ShouldBeAssignableTo<HDInsightHiveTypeProperties>();
            props.Script.ShouldNotBeNullOrWhiteSpace();
            props.ScriptPath.ShouldBeNullOrWhiteSpace();
            props.ScriptLinkedService.ShouldBeNullOrWhiteSpace();

            props.Defines.ShouldNotBeEmpty();
            foreach (var param in props.Defines)
            {
                param.Key.ShouldNotBeNullOrWhiteSpace();
                param.Value.ShouldNotBeNullOrWhiteSpace();
            }
        }
    }
}
