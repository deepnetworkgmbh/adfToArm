using AdfToArm.Core;
using AdfToArm.Core.Models;
using AdfToArm.Core.Models.Pipelines;
using AdfToArm.Core.Models.Pipelines.ActivityProperties;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace AdfToArm.Tests.Dataset
{
    [TestClass]
    public class DataLakeAnalyticsUsqlTests
    {
        private const string FullScriptPathFile = @"./samples/pipelines/activity_datalakeanalytics_path_full.json";
        private const string MinScriptPathFile = @"./samples/pipelines/activity_datalakeanalytics_path_min.json";
        private const string FullInlineScriptFile = @"./samples/pipelines/activity_datalakeanalytics_script_full.json";
        private const string MinInlineScriptFile = @"./samples/pipelines/activity_datalakeanalytics_script_min.json";

        [TestMethod]
        public void AdfItemType_ShouldBe_Pipeline()
        {
            // Arrange
            // Act
            var result = AdfSerializer.Deserialize(FullScriptPathFile);

            // Assert
            result.type.ShouldBe(AdfItemType.Pipeline);
        }

        [TestMethod]
        public void AdfSerializer_ShouldParse_ScriptPathFullVersion()
        {
            // Arrange
            // Act
            var result = AdfSerializer.Deserialize(FullScriptPathFile);
            var activity = (result.value as Pipeline).Properties.Activities[0];

            // Assert
            activity.Name.ShouldNotBeNullOrWhiteSpace();
            activity.Type.ShouldBe(ActivityType.DataLakeAnalyticsUSQL);
            activity.Inputs.ShouldNotBeEmpty();
            activity.Outputs.ShouldNotBeEmpty();
            activity.LinkedServiceName.ShouldNotBeNullOrWhiteSpace();

            var props = activity.TypeProperties.ShouldBeAssignableTo<DataLakeAnalyticsUsqlTypeProperties>();
            props.Script.ShouldBeNullOrWhiteSpace();
            props.ScriptPath.ShouldNotBeNullOrWhiteSpace();
            props.ScriptLinkedService.ShouldNotBeNullOrWhiteSpace();
            props.DegreeOfParallelism.ShouldNotBeNull();
            props.Priority.ShouldNotBeNull();
            props.RuntimeVersion.ShouldNotBeNullOrWhiteSpace();
            props.CompilationMode.ShouldNotBeNullOrWhiteSpace();

            foreach (var param in props.Parameters)
            {
                param.Key.ShouldNotBeNullOrWhiteSpace();
                param.Value.ShouldNotBeNullOrWhiteSpace();
            }
        }

        [TestMethod]
        public void AdfSerializer_ShouldParse_ScriptPathMinVersion()
        {
            // Arrange
            // Act
            var result = AdfSerializer.Deserialize(MinScriptPathFile);
            var activity = (result.value as Pipeline).Properties.Activities[0];

            // Assert
            activity.Name.ShouldNotBeNullOrWhiteSpace();
            activity.Type.ShouldBe(ActivityType.DataLakeAnalyticsUSQL);
            activity.Inputs.ShouldBeNull();
            activity.Outputs.ShouldNotBeEmpty();
            activity.LinkedServiceName.ShouldNotBeNullOrWhiteSpace();

            var props = activity.TypeProperties.ShouldBeAssignableTo<DataLakeAnalyticsUsqlTypeProperties>();
            props.Script.ShouldBeNullOrWhiteSpace();
            props.ScriptPath.ShouldNotBeNullOrWhiteSpace();
            props.ScriptLinkedService.ShouldNotBeNullOrWhiteSpace();
            props.DegreeOfParallelism.ShouldBeNull();
            props.Priority.ShouldBeNull();
            props.RuntimeVersion.ShouldBeNull();
            props.CompilationMode.ShouldBeNull();
            props.Parameters.ShouldBeNull();
        }

        [TestMethod]
        public void AdfSerializer_ShouldParse_InlineScriptFullVersion()
        {
            // Arrange
            // Act
            var result = AdfSerializer.Deserialize(FullInlineScriptFile);
            var activity = (result.value as Pipeline).Properties.Activities[0];

            // Assert
            activity.Name.ShouldNotBeNullOrWhiteSpace();
            activity.Type.ShouldBe(ActivityType.DataLakeAnalyticsUSQL);
            activity.Inputs.ShouldNotBeEmpty();
            activity.Outputs.ShouldNotBeEmpty();
            activity.LinkedServiceName.ShouldNotBeNullOrWhiteSpace();

            var props = activity.TypeProperties.ShouldBeAssignableTo<DataLakeAnalyticsUsqlTypeProperties>();
            props.Script.ShouldNotBeNullOrWhiteSpace();
            props.ScriptPath.ShouldBeNullOrWhiteSpace();
            props.ScriptLinkedService.ShouldBeNullOrWhiteSpace();
            props.DegreeOfParallelism.ShouldNotBeNull();
            props.Priority.ShouldNotBeNull();
            props.RuntimeVersion.ShouldNotBeNullOrWhiteSpace();
            props.CompilationMode.ShouldNotBeNullOrWhiteSpace();

            foreach (var param in props.Parameters)
            {
                param.Key.ShouldNotBeNullOrWhiteSpace();
                param.Value.ShouldNotBeNullOrWhiteSpace();
            }
        }

        [TestMethod]
        public void AdfSerializer_ShouldParse_InlineScriptMinVersion()
        {
            // Arrange
            // Act
            var result = AdfSerializer.Deserialize(MinInlineScriptFile);
            var activity = (result.value as Pipeline).Properties.Activities[0];

            // Assert
            activity.Name.ShouldNotBeNullOrWhiteSpace();
            activity.Type.ShouldBe(ActivityType.DataLakeAnalyticsUSQL);
            activity.Inputs.ShouldBeNull();
            activity.Outputs.ShouldNotBeEmpty();
            activity.LinkedServiceName.ShouldNotBeNullOrWhiteSpace();

            var props = activity.TypeProperties.ShouldBeAssignableTo<DataLakeAnalyticsUsqlTypeProperties>();
            props.Script.ShouldNotBeNullOrWhiteSpace();
            props.ScriptPath.ShouldBeNullOrWhiteSpace();
            props.ScriptLinkedService.ShouldBeNullOrWhiteSpace();
            props.DegreeOfParallelism.ShouldBeNull();
            props.Priority.ShouldBeNull();
            props.RuntimeVersion.ShouldBeNull();
            props.CompilationMode.ShouldBeNull();
            props.Parameters.ShouldBeNull();
        }
    }
}
