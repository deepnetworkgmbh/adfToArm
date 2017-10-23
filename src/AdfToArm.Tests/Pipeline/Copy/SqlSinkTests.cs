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
    public class SqlSinkTests
    {
        private const string FullFilePath = @"./samples/pipelines/copy/datalakesource_sqlSink_full.json";
        private const string MinFilePath = @"./samples/pipelines/copy/datalakesource_sqlSink_min.json";

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
            var sink = props.Sink.ShouldBeAssignableTo<CopySinkAzureSql>();
            sink.Type.ShouldBe(CopySinkType.SqlSink);
            sink.WriteBatchSize.ShouldNotBeNull();
            sink.WriteBatchTimeout.ShouldNotBeNull();
            sink.SqlWriterCleanupScript.ShouldNotBeNull();
            sink.SqlWriterStoredProcedureName.ShouldNotBeNull();
            sink.SqlWriterTableType.ShouldNotBeNull();
            sink.StoredProcedureParameters.ShouldNotBeNull();
            sink.SliceIdentifierColumnName.ShouldNotBeNull();
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
            var sink = props.Sink.ShouldBeAssignableTo<CopySinkAzureSql>();
            sink.Type.ShouldBe(CopySinkType.SqlSink);
            sink.WriteBatchSize.ShouldBeNull();
            sink.WriteBatchTimeout.ShouldBeNull();
            sink.SqlWriterCleanupScript.ShouldBeNull();
            sink.SqlWriterStoredProcedureName.ShouldBeNull();
            sink.SqlWriterTableType.ShouldBeNull();
            sink.StoredProcedureParameters.ShouldBeNull();
            sink.SliceIdentifierColumnName.ShouldBeNull();
        }
    }
}
