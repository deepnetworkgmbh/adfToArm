using AdfToArm.Core;
using AdfToArm.Core.Models;
using AdfToArm.Core.Models.Pipelines;
using AdfToArm.Core.Models.Pipelines.ActivityProperties;
using AdfToArm.Core.Models.Pipelines.ActivityProperties.CopyActivity.Sources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace AdfToArm.Tests.Dataset
{
    [TestClass]
    public class SqlDwSourceTests
    {
        private const string ProcFilePath = @"./samples/pipelines/copy/sqldwprocSource_searchIndexSink_min.json";
        private const string QueryFilePath = @"./samples/pipelines/copy/sqldwquerySource_searchIndexSink_full.json";

        [TestMethod]
        public void AdfItemType_ShouldBe_Pipeline()
        {
            // Arrange
            // Act
            var result = AdfSerializer.Deserialize(ProcFilePath);

            // Assert
            result.type.ShouldBe(AdfItemType.Pipeline);
        }

        [TestMethod]
        public void AdfActivityType_ShouldBe_CopyTypeProperties()
        {
            // Arrange
            // Act
            var result = AdfSerializer.Deserialize(ProcFilePath);
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
            var result = AdfSerializer.Deserialize(ProcFilePath);
            var activity = (result.value as Pipeline).Properties.Activities[0];

            // Assert
            activity.Name.ShouldNotBeNullOrWhiteSpace();
            activity.Inputs.ShouldNotBeEmpty();
            activity.Outputs.ShouldNotBeEmpty();
            activity.LinkedServiceName.ShouldBeNullOrWhiteSpace();

            var props = activity.TypeProperties.ShouldBeAssignableTo<CopyTypeProperties>();
            var source = props.Source.ShouldBeAssignableTo<CopySourceAzureSqlDw>();
            source.Type.ShouldBe(CopySourceType.SqlDWSource);
            source.SqlReaderStoredProcedureName.ShouldNotBeNullOrWhiteSpace();
            source.StoredProcedureParameters.ShouldNotBeNull();
        }

        [TestMethod]
        public void AdfSerializer_ShouldParse_MinSetOfProperties()
        {
            // Arrange
            // Act
            var result = AdfSerializer.Deserialize(QueryFilePath);
            var activity = (result.value as Pipeline).Properties.Activities[0];

            // Assert
            activity.Name.ShouldNotBeNullOrWhiteSpace();
            activity.Inputs.ShouldNotBeEmpty();
            activity.Outputs.ShouldNotBeEmpty();
            activity.LinkedServiceName.ShouldBeNullOrWhiteSpace();

            var props = activity.TypeProperties.ShouldBeAssignableTo<CopyTypeProperties>();
            var source = props.Source.ShouldBeAssignableTo<CopySourceAzureSqlDw>();
            source.Type.ShouldBe(CopySourceType.SqlDWSource);
            source.SqlReaderQuery.ShouldNotBeNullOrWhiteSpace();
        }
    }
}
