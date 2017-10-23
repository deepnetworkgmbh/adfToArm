using AdfToArm.Core;
using AdfToArm.Core.Models;
using AdfToArm.Core.Models.Common;
using AdfToArm.Core.Models.Pipelines;
using AdfToArm.Core.Models.Pipelines.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace AdfToArm.Tests.Dataset
{
    [TestClass]
    public class PipelineTests
    {
        private const string FullFilePath = @"./samples/pipelines/pipeline_full.json";
        private const string MinimumFilePath = @"./samples/pipelines/pipeline_min.json";

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
        public void AdfSerializer_ShouldParse_AllTopLevelProperties()
        {
            // Arrange
            // Act
            var result = AdfSerializer.Deserialize(FullFilePath);
            var pipeline = result.value as Pipeline;

            // Assert
            pipeline.Schema.ShouldNotBeNullOrWhiteSpace();
            pipeline.Name.ShouldNotBeNullOrWhiteSpace();
            pipeline.Properties.Description.ShouldNotBeNullOrWhiteSpace();
            pipeline.Properties.Start.ShouldNotBeNull();
            pipeline.Properties.End.ShouldNotBeNull();
            pipeline.Properties.IsPaused.ShouldNotBeNull();
            pipeline.Properties.PipelineMode.ShouldNotBeNull();
            pipeline.Properties.ExpirationTime.ShouldNotBeNull();
        }

        [TestMethod]
        public void AdfSerializer_ShouldParse_ActivityTopLevelProperties()
        {
            // Arrange
            // Act
            var result = AdfSerializer.Deserialize(FullFilePath);
            var pipeline = result.value as Pipeline;

            // Assert
            var activities = pipeline.Properties.Activities.ShouldBeAssignableTo<Activity[]>();
            var activity = activities[0];

            activity.Name.ShouldNotBeNullOrWhiteSpace();
            activity.Description.ShouldNotBeNullOrWhiteSpace();
            activity.Type.ShouldNotBe(ActivityType.Copy, "Sample should not contain a default Copy value");
            activity.LinkedServiceName.ShouldNotBeNullOrWhiteSpace();

            activity.Inputs.ShouldNotBeEmpty();
            foreach (var item in activity.Inputs)
                item.Name.ShouldNotBeNullOrWhiteSpace();

            activity.Outputs.ShouldNotBeEmpty();
            foreach (var item in activity.Outputs)
                item.Name.ShouldNotBeNullOrWhiteSpace();
        }

        [TestMethod]
        public void AdfSerializer_ShouldParse_ActivityScheduler()
        {
            // Arrange
            // Act
            var result = AdfSerializer.Deserialize(FullFilePath);
            var activities = (result.value as Pipeline).Properties.Activities as Activity[];
            var activity = activities[0];

            // Assert
            var scheduler = activity.Scheduler.ShouldBeAssignableTo<Scheduler>();
            scheduler.Frequency.ShouldNotBe(Frequency.Minute, "Samples in general contain Hour frequency, but not default value");
            scheduler.Interval.ShouldBeGreaterThanOrEqualTo(1, "Samples in general contain interval >= 1");
            scheduler.Style.ShouldNotBeNull();
            scheduler.AnchorDateTime.ShouldNotBeNull();
            scheduler.Offset.ShouldNotBeNull();
        }

        [TestMethod]
        public void AdfSerializer_ShouldParse_ActivityPolicy()
        {
            // Arrange
            // Act
            var result = AdfSerializer.Deserialize(FullFilePath);
            var activities = (result.value as Pipeline).Properties.Activities as Activity[];
            var activity = activities[0];

            // Assert
            var policy = activity.Policy.ShouldBeAssignableTo<Policy>();
            policy.Concurrency.ShouldNotBeNull();
            policy.ExecutionPriorityOrder.ShouldNotBeNull();
            policy.Retry.ShouldNotBeNull();
            policy.Timeout.ShouldNotBeNull();
            policy.Delay.ShouldNotBeNull();
            policy.LongRetry.ShouldNotBeNull();
            policy.LongRetryInterval.ShouldNotBeNull();
        }

        [TestMethod]
        public void AdfSerializer_ShouldParse_MinimumSetOfProperties()
        {
            // Arrange
            // Act
            var result = AdfSerializer.Deserialize(MinimumFilePath);
            var pipeline = result.value as Pipeline;

            // Assert
            pipeline.Name.ShouldNotBeNullOrWhiteSpace();
            pipeline.Properties.Description.ShouldBeNullOrWhiteSpace();
            pipeline.Properties.Start.ShouldBeNull();
            pipeline.Properties.End.ShouldBeNull();
            pipeline.Properties.IsPaused.ShouldBeNull();
            pipeline.Properties.PipelineMode.ShouldBeNull();
            pipeline.Properties.ExpirationTime.ShouldBeNull();

            var activities = pipeline.Properties.Activities.ShouldBeAssignableTo<Activity[]>();
            var activity = activities[0];
            activity.Name.ShouldNotBeNullOrWhiteSpace();
            activity.Description.ShouldBeNullOrWhiteSpace();
            activity.Type.ShouldNotBe(ActivityType.Copy, "Sample should not contain a default Copy value");
            activity.Inputs.ShouldBeNull();
            activity.Outputs.ShouldNotBeEmpty();
            activity.LinkedServiceName.ShouldBeNullOrWhiteSpace();
            activity.Policy.ShouldBeNull();
            activity.Scheduler.ShouldBeNull();
        }
    }
}
