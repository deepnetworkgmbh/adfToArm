using AdfToArm.Core;
using AdfToArm.Core.Models;
using AdfToArm.Core.Models.Pipelines;
using AdfToArm.Core.Models.Pipelines.ActivityProperties;
using AdfToArm.Core.Models.Pipelines.ActivityProperties.CopyActivity.Sinks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace AdfToArm.Tests.Dataset
{
    [TestClass]
    public class GeneralCopyTests
    {
        private const string FilePath = @"./samples/pipelines/copy/general.json";

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
        public void AdfActivityType_ShouldBe_CopyTypeProperties()
        {
            // Arrange
            // Act
            var result = AdfSerializer.Deserialize(FilePath);
            var activity = (result.value as Pipeline).Properties.Activities[0];

            // Assert
            activity.Type.ShouldBe(ActivityType.Copy);
            activity.TypeProperties.ShouldBeAssignableTo<CopyTypeProperties>();
        }

        [TestMethod]
        public void AdfSerializer_ShouldParse_GeneralProperties()
        {
            // Arrange
            // Act
            var result = AdfSerializer.Deserialize(FilePath);
            var activity = (result.value as Pipeline).Properties.Activities[0];

            // Assert
            activity.Name.ShouldNotBeNullOrWhiteSpace();
            activity.Inputs.ShouldNotBeEmpty();
            activity.Outputs.ShouldNotBeEmpty();

            var props = activity.TypeProperties.ShouldBeAssignableTo<CopyTypeProperties>();
            props.CloudDataMovementUnits.ShouldNotBeNull();
            props.ParallelCopies.ShouldNotBeNull();
        }

        [TestMethod]
        public void AdfSerializer_ShouldParse_Translator()
        {
            // Arrange
            // Act
            var result = AdfSerializer.Deserialize(FilePath);
            var activity = (result.value as Pipeline).Properties.Activities[0];
            var props = activity.TypeProperties as CopyTypeProperties;

            // Assert
            props.Translator.Type.ShouldBe("TabularTranslator");
            props.Translator.ColumnMappings.ShouldNotBeNullOrWhiteSpace();
        }

        [TestMethod]
        public void AdfSerializer_ShouldParse_StagingSettings()
        {
            // Arrange
            // Act
            var result = AdfSerializer.Deserialize(FilePath);
            var activity = (result.value as Pipeline).Properties.Activities[0];
            var props = activity.TypeProperties as CopyTypeProperties;

            // Assert
            props.EnableStaging.ShouldBe(true);
            props.StagingSettings.LinkedServiceName.ShouldNotBeNullOrWhiteSpace();
            props.StagingSettings.Path.ShouldNotBeNullOrWhiteSpace();
            props.StagingSettings.EnableCompression.ShouldNotBeNull();
        }

        [TestMethod]
        public void AdfSerializer_ShouldParse_RedirectIncompatibleRowSettings()
        {
            // Arrange
            // Act
            var result = AdfSerializer.Deserialize(FilePath);
            var activity = (result.value as Pipeline).Properties.Activities[0];
            var props = activity.TypeProperties as CopyTypeProperties;

            // Assert
            props.EnableSkipIncompatibleRow.ShouldBe(true);
            props.RedirectIncompatibleRowSettings.LinkedServiceName.ShouldNotBeNullOrWhiteSpace();
            props.RedirectIncompatibleRowSettings.Path.ShouldNotBeNullOrWhiteSpace();
        }
    }
}
