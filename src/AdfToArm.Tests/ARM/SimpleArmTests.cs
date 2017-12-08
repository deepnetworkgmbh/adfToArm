using AdfToArm.Core.Compiler;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using Shouldly;
using System.IO;
using System.Linq;

namespace AdfToArm.Tests.ARM
{
    [TestClass]
    public class SampleArmTests
    {
        private const string outputFileName = "testparams.json";
        private const string outputParamsName = "testparams.parameters.json";

        [TestCleanup]
        public void Cleanup()
        {
            File.Delete(outputFileName);
            File.Delete(outputParamsName);
        }

        [TestMethod]
        public void Compiler_ProcessProjectWithOnePipeline()
        {
            // Arrange
            // Act
            Compiler
                .New()
                .From(@"./samples/arm/one_pipeline_proj")
                .To(".")
                .Name("testparams.json")
                .Create();

            var jsonArm = File.ReadAllText(outputFileName);
            var jo = JObject.Parse(jsonArm);

            // Assert
            var result = CountResourcesByType(jo);

            result.pipelines.ShouldBe(1);
            result.datasets.ShouldBe(2);
            result.linkedservices.ShouldBe(2);
        }

        [TestMethod]
        public void Compiler_ProcessProjectWithThreePipelines()
        {
            // Arrange
            // Act
            Compiler
                .New()
                .From(@"./samples/arm/three_pipelines_proj")
                .To(".")
                .Name("testparams.json")
                .Create();

            var jsonArm = File.ReadAllText(outputFileName);
            var jo = JObject.Parse(jsonArm);

            // Assert
            var result = CountResourcesByType(jo);

            result.pipelines.ShouldBe(3);
            result.datasets.ShouldBe(6);
            result.linkedservices.ShouldBe(3);
        }

        [TestMethod]
        public void Compiler_ProcessProjectWithThreeActivitiesPipeline()
        {
            // Arrange
            // Act
            Compiler
                .New()
                .From(@"./samples/arm/three_activities_pipeline_proj")
                .To(".")
                .Name("testparams.json")
                .Create();

            var jsonArm = File.ReadAllText(outputFileName);
            var jo = JObject.Parse(jsonArm);

            // Assert
            var result = CountResourcesByType(jo);

            result.pipelines.ShouldBe(1);
            result.datasets.ShouldBe(4);
            result.linkedservices.ShouldBe(4);
        }

        private (int pipelines, int datasets, int linkedservices) CountResourcesByType(JObject jo)
        {
            int pipelines = 0, datasets = 0, linkedservices = 0;
            foreach (var res in jo["resources"].First()["resources"])
            {
                switch (res["type"].Value<string>())
                {
                    case "linkedservices":
                        linkedservices++;
                        break;
                    case "datasets":
                        datasets++;
                        break;
                    case "datapipelines":
                        pipelines++;
                        break;
                }
            }

            return (pipelines, datasets, linkedservices);
        }
    }
}
