using AdfToArm.Core;
using AdfToArm.Core.Compiler;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using Shouldly;
using System.IO;
using System.Linq;

namespace AdfToArm.Tests.ARM
{
    [TestClass]
    public class ArmParametersTests
    {
        private const string outputFileName = "testparams.json";
        private const string outputParamsName = "testparams.parameters.json";
        private const string FolderPath = @"./samples/arm/params";

        [TestCleanup]
        public void Cleanup()
        {
            File.Delete(outputFileName);
            File.Delete(outputParamsName);
        }

        [TestMethod]
        public void Compiler_ShouldParseClusterSize_AsInteger()
        {
            // Arrange
            // Act
            Compiler
                .New()
                .From(FolderPath)
                .To(".")
                .Name("testparams.json")
                .Create();

            var jsonArm = File.ReadAllText(outputFileName);
            var jo = JObject.Parse(jsonArm);

            // Assert
            var clusterSizeProp = jo["parameters"].Cast<JProperty>().FirstOrDefault(i => i.Name.EndsWith("clusterSize"));

            clusterSizeProp.ShouldNotBeNull();
            clusterSizeProp.Value["type"].Value<string>().ShouldBe("int");
            clusterSizeProp.Value["defaultValue"].Value<int>().ShouldBeGreaterThan(0);
        }

        [TestMethod]
        public void Compiler_ShouldParseTimeToLive_AsString()
        {
            // Arrange
            // Act
            Compiler
                .New()
                .From(FolderPath)
                .To(".")
                .Name("testparams.json")
                .Create();

            var jsonArm = File.ReadAllText(outputFileName);
            var jo = JObject.Parse(jsonArm);

            // Assert
            var timeToLiveProp = jo["parameters"].Cast<JProperty>().FirstOrDefault(i => i.Name.EndsWith("timetolive"));

            timeToLiveProp.ShouldNotBeNull();
            timeToLiveProp.Value["type"].Value<string>().ShouldBe("string");
            timeToLiveProp.Value["defaultValue"].Value<string>().ShouldNotBeNull();
        }

        [TestMethod]
        public void Compiler_ShouldParseAdditionalServices_AsArray()
        {
            // Arrange
            // Act
            Compiler
                .New()
                .From(FolderPath)
                .To(".")
                .Name("testparams.json")
                .Create();

            var jsonArm = File.ReadAllText(outputFileName);
            var jo = JObject.Parse(jsonArm);

            // Assert
            var additionalServicesProp = jo["parameters"].Cast<JProperty>().FirstOrDefault(i => i.Name.EndsWith("additionalLinkedServiceNames"));

            additionalServicesProp.ShouldNotBeNull();
            additionalServicesProp.Value["type"].Value<string>().ShouldBe("array");
            var arrayValue = additionalServicesProp.Value["defaultValue"];
            arrayValue.ShouldBeAssignableTo<JArray>();
            arrayValue.Count().ShouldBe(2);
        }

        [TestMethod]
        public void Compiler_ShouldParseCoreConfiguration_AsObject()
        {
            // Arrange
            // Act
            Compiler
                .New()
                .From(FolderPath)
                .To(".")
                .Name("testparams.json")
                .Create();

            var jsonArm = File.ReadAllText(outputFileName);
            var jo = JObject.Parse(jsonArm);

            // Assert
            var additionalServicesProp = jo["parameters"].Cast<JProperty>().FirstOrDefault(i => i.Name.EndsWith("coreConfiguration"));

            additionalServicesProp.ShouldNotBeNull();
            additionalServicesProp.Value["type"].Value<string>().ShouldBe("object");
            var objectValue = additionalServicesProp.Value["defaultValue"];
            objectValue.ShouldBeAssignableTo<JObject>();
            objectValue["templeton.mapper.memory.mb"].ShouldBe("5000");
        }

        [TestMethod]
        public void Compiler_ShouldCreateParametersFileWithTheSameAmountOfParameters()
        {
            // Arrange
            // Act
            Compiler
                .New()
                .From(FolderPath)
                .To(".")
                .Name("testparams.json")
                .Create();

            var jsonArm = File.ReadAllText(outputFileName);
            var joArm = JObject.Parse(jsonArm)["parameters"];

            var jsonParams = File.ReadAllText(outputParamsName);
            var joParams = JObject.Parse(jsonParams)["parameters"].Cast<JProperty>();

            // Assert
            foreach (JProperty param in joArm)
            {
                var actualParam = joParams.FirstOrDefault(i => i.Name == param.Name);
                actualParam.ShouldNotBeNull();
            }
        }
    }
}
