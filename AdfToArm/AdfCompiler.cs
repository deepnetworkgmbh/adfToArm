using AdfToArm.Models.ARM.Tempaltes;
using AdfToArm.Models.DataSets;
using AdfToArm.Models.LinkedServices;
using AdfToArm.Models.Pipelines;
using System;
using System.Collections.Generic;
using System.IO;

namespace AdfToArm
{
    public class AdfCompiler
    {
        private readonly string _projectPath;

        private readonly List<DataSet> _dataSets = new List<DataSet>();
        private readonly List<LinkedService> _linkedService = new List<LinkedService>();
        private readonly List<Pipeline> _pipelines = new List<Pipeline>();

        private DataFactoryArm _arm;

        private AdfCompiler(string path)
        {
            _projectPath = path;
        }

        public static AdfCompiler New(string pathToProject) => new AdfCompiler(pathToProject);

        public AdfCompiler ParseAdfTemplates()
        {
            var adjustedPath = AdjustProjectPath();
            string[] allFiles = Directory.GetFiles(adjustedPath, "*.json", SearchOption.AllDirectories);

            foreach (var file in allFiles)
            {
                var tuple = AdfSerializer.Deserialize(file);
                switch(tuple.value)
                {
                    case DataSet dataset:
                        _dataSets.Add(dataset);
                        break;
                    case LinkedService linkedService:
                        _linkedService.Add(linkedService);
                        break;
                    case Pipeline pipeline:
                        _pipelines.Add(pipeline);
                        break;
                    default:
                        Logs.Logger.Instance.Warn($"Skipping file at {file}");
                        break;
                }
            }

            return this;
        }

        public AdfCompiler CreateArmTemplate()
        {
            var name = GetAdfName();
            _arm = new DataFactoryArm(name);

            foreach (var ls in _linkedService)
                _arm.AddResource(new LinkedServiceArm(name, ls));
            foreach (var ds in _dataSets)
                _arm.AddResource(new DataSetArm(name, ds));
            foreach (var pl in _pipelines)
                _arm.AddResource(new PipelineArm(name, pl));

            return this;
        }

        public void SaveArmTo(string path)
        {
            var json = AdfSerializer.Serialize(_arm);

            File.WriteAllText(path, json);
        }

        private string AdjustProjectPath()
        {
            if (Directory.Exists(_projectPath))
            {
                Logs.Logger.Instance.Info($"{_projectPath} is a directory. Look for *.json files inside");
                return _projectPath;
            }

            if (_projectPath.EndsWith(".dfproj"))
            {
                var file = new FileInfo(_projectPath);
                Logs.Logger.Instance.Info($"{_projectPath} is a Azure Data Factory project. Look for *.json files in {file.DirectoryName}");
                return file.DirectoryName;
            }

            throw new NotSupportedException($"{_projectPath} is not a directory and not an ADF project");
        }

        private string GetAdfName()
        {
            if (Directory.Exists(_projectPath))
            {
                var directory = new DirectoryInfo(_projectPath);
                var name = directory.Name.Replace('.', '-');
                Logs.Logger.Instance.Info($"{_projectPath} is a directory. Use ADF name {name}");
                return _projectPath;
            }

            if (_projectPath.EndsWith(".dfproj"))
            {
                var file = new FileInfo(_projectPath);
                var name = file.Name
                    .Substring(0, file.Name.Length - 7)
                    .Replace('.', '-');
                Logs.Logger.Instance.Info($"{_projectPath} is a Azure Data Factory project. Use ADF name {name}");
                return name;
            }

            throw new NotSupportedException($"{_projectPath} is not a directory and not an ADF project");
        }
    }
}
