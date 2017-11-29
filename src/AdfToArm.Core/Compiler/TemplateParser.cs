using AdfToArm.Core.Models.DataSets;
using AdfToArm.Core.Models.LinkedServices;
using AdfToArm.Core.Models.Pipelines;
using System;
using System.Collections.Generic;
using System.IO;

namespace AdfToArm.Core.Compiler
{
    public class TemplateParser
    {
        private readonly string _projectPath;

        public TemplateParser(string projectPath)
        {
            _projectPath = projectPath;
        }

        public (bool isCorrupted, IEnumerable<LinkedService> linkedServices, IEnumerable<DataSet> dataSets, IEnumerable<Pipeline> pipelines) Parse()
        {
            var adjustedPath = AdjustProjectPath();
            string[] allFiles = Directory.GetFiles(adjustedPath, "*.json", SearchOption.AllDirectories);

            var isCorrupted = false;
            var dataSets = new List<DataSet>();
            var linkedServices = new List<LinkedService>();
            var pipelines = new List<Pipeline>();

            foreach (var file in allFiles)
            {
                try
                {
                    var tuple = AdfSerializer.Deserialize(file);
                    switch (tuple.value)
                    {
                        case DataSet dataset:
                            dataSets.Add(dataset);
                            break;
                        case LinkedService linkedService:
                            linkedServices.Add(linkedService);
                            break;
                        case Pipeline pipeline:
                            pipelines.Add(pipeline);
                            break;
                    }
                }
                catch (AdfParseException)
                {
                    isCorrupted = true;
                }
            }

            return (isCorrupted, linkedServices, dataSets, pipelines);
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
    }
}
