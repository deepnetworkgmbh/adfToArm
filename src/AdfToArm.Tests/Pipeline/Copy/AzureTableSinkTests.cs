﻿using AdfToArm.Core;
using AdfToArm.Core.Models;
using AdfToArm.Core.Models.Pipelines;
using AdfToArm.Core.Models.Pipelines.ActivityProperties;
using AdfToArm.Core.Models.Pipelines.ActivityProperties.CopyActivity.Sinks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace AdfToArm.Tests.Dataset
{
    [TestClass]
    public class AzureTableSinkTests
    {
        private const string FullFilePath = @"./samples/pipelines/copy/cosmosSource_tableSink_full.json";
        private const string MinFilePath = @"./samples/pipelines/copy/cosmosSource_tableSink_min.json";

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
        public void AdfActivityType_ShouldBe_CopyTypeProperties()
        {
            // Arrange
            // Act
            var result = AdfSerializer.Deserialize(FullFilePath);
            var activity = (result.value as Pipeline).Properties.Activities[0];

            // Assert
            activity.Type.ShouldBe(ActivityType.Copy);
            activity.TypeProperties.ShouldBeAssignableTo<CopyTypeProperties>();
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
            activity.Inputs.ShouldNotBeEmpty();
            activity.Outputs.ShouldNotBeEmpty();
            activity.LinkedServiceName.ShouldBeNullOrWhiteSpace();

            var props = activity.TypeProperties.ShouldBeAssignableTo<CopyTypeProperties>();
            var sink = props.Sink.ShouldBeAssignableTo<CopySinkAzureTable>();
            sink.Type.ShouldBe(CopySinkType.AzureTableSink);
            sink.WriteBatchSize.ShouldNotBeNull();
            sink.WriteBatchTimeout.ShouldNotBeNull();
            sink.AzureTableDefaultPartitionKeyValue.ShouldNotBeNullOrWhiteSpace();
            sink.AzureTableInsertType.ShouldNotBeNullOrWhiteSpace();
            sink.AzureTablePartitionKeyName.ShouldNotBeNullOrWhiteSpace();
            sink.AzureTableRowKeyName.ShouldNotBeNullOrWhiteSpace();
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
            activity.Inputs.ShouldNotBeEmpty();
            activity.Outputs.ShouldNotBeEmpty();
            activity.LinkedServiceName.ShouldBeNullOrWhiteSpace();

            var props = activity.TypeProperties.ShouldBeAssignableTo<CopyTypeProperties>();
            var sink = props.Sink.ShouldBeAssignableTo<CopySinkAzureTable>();
            sink.Type.ShouldBe(CopySinkType.AzureTableSink);
            sink.WriteBatchSize.ShouldBeNull();
            sink.WriteBatchTimeout.ShouldBeNull();
            sink.AzureTableDefaultPartitionKeyValue.ShouldBeNullOrWhiteSpace();
            sink.AzureTableInsertType.ShouldBeNullOrWhiteSpace();
            sink.AzureTablePartitionKeyName.ShouldBeNullOrWhiteSpace();
            sink.AzureTableRowKeyName.ShouldBeNullOrWhiteSpace();
        }
    }
}
