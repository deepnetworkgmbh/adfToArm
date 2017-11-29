using AdfToArm.Core.Models.ARM;
using AdfToArm.Core.Models.ARM.Tempaltes;
using AdfToArm.Core.Models.DataSets;
using AdfToArm.Core.Models.LinkedServices;
using AdfToArm.Core.Models.Pipelines;
using System;
using System.Collections.Generic;
using System.IO;

namespace AdfToArm.Core.Compiler
{
    public class TemplateCreator
    {
        private readonly string _projectPath;

        public TemplateCreator(string projectPath)
        {
            _projectPath = projectPath;
        }

        public ArmTemplate Create(IEnumerable<LinkedService> linkedServices, IEnumerable<DataSet> dataSets, IEnumerable<Pipeline> pipelines)
        {
            var name = GetAdfName();
            var dfArm = new DataFactoryArm(name);

            foreach (var ls in linkedServices)
                dfArm.AddResource(new LinkedServiceArm(name, ls));
            foreach (var ds in dataSets)
                dfArm.AddResource(new DataSetArm(name, ds));
            foreach (var pl in pipelines)
                dfArm.AddResource(new PipelineArm(name, pl));

            var arm = new ArmTemplate();
            arm.Resources.Add(dfArm);

            return arm;
        }

        private string GetAdfName()
        {
            if (Directory.Exists(_projectPath))
            {
                var directory = new DirectoryInfo(_projectPath);
                var name = directory.Name.Replace('.', '-');
                Logs.Logger.Instance.Info($"{_projectPath} is a directory. Use ADF name {name}");
                return name;
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
