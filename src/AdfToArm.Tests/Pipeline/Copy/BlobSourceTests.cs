﻿using AdfToArm.Core;
using AdfToArm.Core.Models;
using AdfToArm.Core.Models.Pipelines;
using AdfToArm.Core.Models.Pipelines.ActivityProperties;
using AdfToArm.Core.Models.Pipelines.ActivityProperties.CopyActivity.Sources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace AdfToArm.Tests.Dataset
{
    [TestClass]
    public class BlobSourceTests
    {
        private const string FullFilePath = @"./samples/pipelines/copy/blobSource_dataLakeSink_full.json";
        private const string MinFilePath = @"./samples/pipelines/copy/blobSource_dataLakeSink_min.json";

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
            var source = props.Source.ShouldBeAssignableTo<CopySourceBlob>();
            source.Type.ShouldBe(CopySourceType.BlobSource);
            source.Recursive.ShouldNotBeNull();
            source.TreatEmptyAsNull.ShouldNotBeNull();
            source.SkipHeaderLineCount.ShouldNotBeNull();
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
            var source = props.Source.ShouldBeAssignableTo<CopySourceBlob>();
            source.Type.ShouldBe(CopySourceType.BlobSource);
            source.Recursive.ShouldBeNull();
            source.TreatEmptyAsNull.ShouldBeNull();
            source.SkipHeaderLineCount.ShouldBeNull();
        }
    }
}
