using AdfToArm.Core;
using AdfToArm.Core.Models;
using AdfToArm.Core.Models.Pipelines;
using AdfToArm.Core.Models.Pipelines.ActivityProperties;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace AdfToArm.Tests.Dataset
{
    [TestClass]
    public class AzureMLBatchExecutionTests
    {
        private const string OneInputFilePath = @"./samples/pipelines/activity_ml_1input.json";
        private const string TwoInputsFilePath = @"./samples/pipelines/activity_ml_2inputs.json";
        private const string EmptyFilePath = @"./samples/pipelines/activity_ml_empty.json";
        private const string NoInputFilePath = @"./samples/pipelines/activity_ml_noinput.json";

        [TestMethod]
        public void AdfItemType_ShouldBe_Pipeline()
        {
            // Arrange
            // Act
            var result = AdfSerializer.Deserialize(TwoInputsFilePath);

            // Assert
            result.type.ShouldBe(AdfItemType.Pipeline);
        }

        [TestMethod]
        public void AdfSerializer_ShouldParse_SeveralInputsAndGlobalProperties()
        {
            // Arrange
            // Act
            var result = AdfSerializer.Deserialize(TwoInputsFilePath);
            var activity = (result.value as Pipeline).Properties.Activities[0];

            // Assert
            activity.Name.ShouldNotBeNullOrWhiteSpace();
            activity.Type.ShouldBe(ActivityType.AzureMLBatchExecution);
            activity.Inputs.ShouldNotBeEmpty();
            activity.Outputs.ShouldNotBeEmpty();
            activity.LinkedServiceName.ShouldNotBeNullOrWhiteSpace();

            var props = activity.TypeProperties.ShouldBeAssignableTo<MlBatchExecutorTypeProperties>();
            props.WebServiceInput.ShouldBeNullOrWhiteSpace();
            props.WebServiceInputs.Length.ShouldBe(activity.Inputs.Length);
            foreach (var param in props.WebServiceInputs)
            {
                param.Key.ShouldNotBeNullOrWhiteSpace();
                param.Value.ShouldNotBeNullOrWhiteSpace();
            }

            props.WebServiceOutputs.Length.ShouldBe(activity.Outputs.Length);
            foreach (var param in props.WebServiceOutputs)
            {
                param.Key.ShouldNotBeNullOrWhiteSpace();
                param.Value.ShouldNotBeNullOrWhiteSpace();
            }

            props.GlobalParameters.ShouldNotBeEmpty();
            foreach (var param in props.GlobalParameters)
            {
                param.Key.ShouldNotBeNullOrWhiteSpace();
                param.Value.ShouldNotBeNullOrWhiteSpace();
            }
        }

        [TestMethod]
        public void AdfSerializer_ShouldParse_OneInputFile()
        {
            // Arrange
            // Act
            var result = AdfSerializer.Deserialize(OneInputFilePath);
            var activity = (result.value as Pipeline).Properties.Activities[0];

            // Assert
            activity.Name.ShouldNotBeNullOrWhiteSpace();
            activity.Type.ShouldBe(ActivityType.AzureMLBatchExecution);
            activity.Inputs.Length.ShouldBe(1);
            activity.Outputs.ShouldNotBeEmpty();
            activity.LinkedServiceName.ShouldNotBeNullOrWhiteSpace();

            var props = activity.TypeProperties.ShouldBeAssignableTo<MlBatchExecutorTypeProperties>();
            props.WebServiceInput.ShouldNotBeNullOrWhiteSpace();
            props.WebServiceInputs.ShouldBeNull();

            props.WebServiceOutputs.Length.ShouldBe(activity.Outputs.Length);
            foreach (var param in props.WebServiceOutputs)
            {
                param.Key.ShouldNotBeNullOrWhiteSpace();
                param.Value.ShouldNotBeNullOrWhiteSpace();
            }

            props.GlobalParameters.ShouldBeNull();
        }

        [TestMethod]
        public void AdfSerializer_ShouldParse_ActivityWithoutInputs()
        {
            // Arrange
            // Act
            var result = AdfSerializer.Deserialize(NoInputFilePath);
            var activity = (result.value as Pipeline).Properties.Activities[0];

            // Assert
            activity.Name.ShouldNotBeNullOrWhiteSpace();
            activity.Type.ShouldBe(ActivityType.AzureMLBatchExecution);
            activity.Inputs.ShouldBeNull();
            activity.Outputs.ShouldNotBeEmpty();
            activity.LinkedServiceName.ShouldNotBeNullOrWhiteSpace();

            var props = activity.TypeProperties.ShouldBeAssignableTo<MlBatchExecutorTypeProperties>();
            props.WebServiceInput.ShouldBeNullOrWhiteSpace();
            props.WebServiceInputs.ShouldBeNull();

            props.WebServiceOutputs.Length.ShouldBe(activity.Outputs.Length);
            foreach (var param in props.WebServiceOutputs)
            {
                param.Key.ShouldNotBeNullOrWhiteSpace();
                param.Value.ShouldNotBeNullOrWhiteSpace();
            }

            props.GlobalParameters.ShouldBeNull();
        }

        [TestMethod]
        public void AdfSerializer_ShouldParse_EmptyProperties()
        {
            // Arrange
            // Act
            var result = AdfSerializer.Deserialize(EmptyFilePath);
            var activity = (result.value as Pipeline).Properties.Activities[0];

            // Assert
            activity.Name.ShouldNotBeNullOrWhiteSpace();
            activity.Type.ShouldBe(ActivityType.AzureMLBatchExecution);
            activity.Inputs.ShouldBeNull();
            activity.Outputs.ShouldNotBeEmpty();
            activity.LinkedServiceName.ShouldNotBeNullOrWhiteSpace();

            var props = activity.TypeProperties.ShouldBeAssignableTo<MlBatchExecutorTypeProperties>();
            props.WebServiceInput.ShouldBeNullOrWhiteSpace();
            props.WebServiceInputs.ShouldBeNull();
            props.WebServiceOutputs.ShouldBeNull();
            props.GlobalParameters.ShouldBeNull();
        }
    }
}
