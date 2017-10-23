using AdfToArm.Core;
using AdfToArm.Core.Models;
using AdfToArm.Core.Models.Pipelines;
using AdfToArm.Core.Models.Pipelines.ActivityProperties;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace AdfToArm.Tests.Dataset
{
    [TestClass]
    public class SqlServerStoredProcedureTests
    {
        private const string FullFilePath = @"./samples/pipelines/activity_sqlsp_full.json";
        private const string MinFilePath = @"./samples/pipelines/activity_sqlsp_min.json";

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
        public void AdfSerializer_ShouldParse_AllProperties()
        {
            // Arrange
            // Act
            var result = AdfSerializer.Deserialize(FullFilePath);
            var activity = (result.value as Pipeline).Properties.Activities[0];

            // Assert
            activity.Name.ShouldNotBeNullOrWhiteSpace();
            activity.Type.ShouldBe(ActivityType.SqlServerStoredProcedure);
            activity.Inputs.ShouldNotBeEmpty();
            activity.Outputs.ShouldNotBeEmpty();
            activity.LinkedServiceName.ShouldBeNullOrWhiteSpace();

            var props = activity.TypeProperties.ShouldBeAssignableTo<SqlServerStoredProcedureTypeProperties>();
            props.StoredProcedureName.ShouldNotBeNullOrWhiteSpace();
            props.StoredProcedureParameters.ShouldNotBeEmpty();

            foreach (var param in props.StoredProcedureParameters)
            {
                param.Key.ShouldNotBeNullOrWhiteSpace();
                param.Value.ShouldNotBeNullOrWhiteSpace();
            }
        }

        [TestMethod]
        public void AdfSerializer_ShouldParse_MinSetOfPropertiesn()
        {
            // Arrange
            // Act
            var result = AdfSerializer.Deserialize(MinFilePath);
            var activity = (result.value as Pipeline).Properties.Activities[0];

            // Assert
            activity.Name.ShouldNotBeNullOrWhiteSpace();
            activity.Type.ShouldBe(ActivityType.SqlServerStoredProcedure);
            activity.Inputs.ShouldBeNull();
            activity.Outputs.ShouldNotBeEmpty();
            activity.LinkedServiceName.ShouldBeNullOrWhiteSpace();

            var props = activity.TypeProperties.ShouldBeAssignableTo<SqlServerStoredProcedureTypeProperties>();
            props.StoredProcedureName.ShouldNotBeNullOrWhiteSpace();
            props.StoredProcedureParameters.ShouldBeNull();
        }
    }
}
