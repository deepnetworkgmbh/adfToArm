using AdfToArm.Core.Models;
using AdfToArm.Core.Models.ARM;
using AdfToArm.Core.Models.ARM.Tempaltes;
using AdfToArm.Core.Models.DataSets;
using AdfToArm.Core.Models.LinkedServices;
using AdfToArm.Core.Models.Pipelines;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AdfToArm.Core
{
    public class AdfCompiler
    {
        private readonly string _projectPath;

        private readonly List<DataSet> _dataSets = new List<DataSet>();
        private readonly List<LinkedService> _linkedService = new List<LinkedService>();
        private readonly List<Pipeline> _pipelines = new List<Pipeline>();

        private readonly List<ArmParameter> _parameters = new List<ArmParameter>();
        private ArmTemplate _arm;
        private bool _isCorrupted;

        private AdfCompiler(string path)
        {
            _projectPath = path;
        }

        public static AdfCompiler New(string pathToProject) => new AdfCompiler(pathToProject);

        public AdfCompiler ParseAdfTemplates()
        {
            var adjustedPath = AdjustProjectPath();
            string[] allFiles = Directory.GetFiles(adjustedPath, "*.json", SearchOption.AllDirectories);

            foreach (var file in allFiles.Where(i=> !i.Contains(@"\bin\") && !i.Contains(@"\obj\")))
            {
                try
                {
                    var tuple = AdfSerializer.Deserialize(file);
                    switch (tuple.value)
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
                    }
                }
                catch (AdfParseException)
                {
                    _isCorrupted = true;
                    return this;
                }
            }

            return this;
        }

        public AdfCompiler CreateArmTemplate()
        {
            if (_isCorrupted)
                return this;

            var name = GetAdfName();
            var dfArm = new DataFactoryArm(name);

            foreach (var ls in _linkedService)
                dfArm.AddResource(new LinkedServiceArm(name, ls));
            foreach (var ds in _dataSets)
                dfArm.AddResource(new DataSetArm(name, ds));
            foreach (var pl in _pipelines)
                dfArm.AddResource(new PipelineArm(name, pl));

            _arm = new ArmTemplate();
            _arm.Resources.Add(dfArm);

            return this;
        }

        public void SaveArmTo(string path)
        {
            if (_isCorrupted)
                return;

            var jo = JObject.FromObject(_arm);

            GenerateAndReplaceParameters(jo);

            var ja = jo["parameters"] as JObject;
            foreach (var param in _parameters)
            {
                var name = param.Name;
                var content = JObject.FromObject(param.Properties);
                ja.Add(name, content);
            }

            var json = jo.ToString(Formatting.Indented);

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

        private void GenerateAndReplaceParameters(JObject jo)
        {
            var resource = _arm.Resources[0];
            var name = GetNodeName(resource);

            ProcessNodeElement(jo["resources"].First(), resource, $"resources_{name}");
        }

        private void ProcessNodeElement(JToken jt, object nodeObject, string fullName)
        {
            if (nodeObject == null)
                return;

            var nodeType = nodeObject.GetType();
            if (nodeType.IsSimple() || (nodeType.IsArray && nodeType.GetElementType().IsSimple()))
                return;

            if (nodeObject is IEnumerable enumerator)
            {
                var counter = 0;
                foreach(var element in enumerator)
                    ProcessNodeObject(jt[counter++], element, $"{fullName}{counter}");
            }
            else
            {
                ProcessNodeObject(jt, nodeObject, fullName);
            }
        }

        private void ProcessNodeObject(JToken jt, object nodeObject, string fullName)
        {
            foreach (var prop in nodeObject.GetType().GetProperties())
            {
                var attributes = prop.GetCustomAttributes(false);
                var armParamAttribute = attributes.FirstOrDefault(i => i is ArmParameterAttribute) as ArmParameterAttribute;
                if (armParamAttribute != null)
                {
                    var jsonName = GetJsonPropertyName(prop);
                    var type = armParamAttribute.Type;

                    ReplacePropertyWithParameter(jt, prop.GetValue(nodeObject), type, fullName, jsonName);
                }
                else if (attributes.Any(i => i is JsonPropertyAttribute))
                {
                    var nextNode = prop.GetValue(nodeObject);

                    //var name = GetNodeName(nextNode);
                    var jsonName = GetJsonPropertyName(prop);

                    ProcessNodeElement(jt[jsonName], nextNode, $"{fullName}_{jsonName}");
                }
            }
        }

        private string GetNodeName(object nodeObject)
        {
            var nameProperty = nodeObject.GetType().GetProperty("Name");

            if (nameProperty != null)
            {
                return nameProperty.GetValue(nodeObject).ToString();
            }
            else
            {
                var jsonAttr = nodeObject.GetType().GetCustomAttributes(false).FirstOrDefault(i => i is JsonPropertyAttribute);

                var jsonName = jsonAttr != null
                    ? (jsonAttr as JsonPropertyAttribute).PropertyName
                    : nodeObject.GetType().Name;

                return jsonName;
            }
        }

        private string GetJsonPropertyName(PropertyInfo property)
        {
            var jsonAttr = property.GetCustomAttributes(false).FirstOrDefault(i => i is JsonPropertyAttribute);

            var jsonName = jsonAttr != null
                ? (jsonAttr as JsonPropertyAttribute).PropertyName
                : property.GetType().Name;

            return jsonName;
        }

        private void ReplacePropertyWithParameter(JToken jt, object prop, string type, string fullName, string jsonName)
        {
            // Create parameter and replace in jo
            var parameterName = $"{fullName}_{jsonName}";

            var armParam = new ArmParameter()
            {
                Name = parameterName,
                Properties = new ArmParameterProperties
                {
                    DefaultValue = GetDefaultValue(prop, type),
                    Type = type
                }
            };

            _parameters.Add(armParam);

            switch(jt[jsonName])
            {
                case JValue jvalue:
                    jvalue.Value = $"[parameters('{parameterName}')]";
                    break;
                case JProperty jprop:
                    jprop.Value = $"[parameters('{parameterName}')]";
                    break;
                case JArray jarray:
                    var arrayParent = jarray.Parent;
                    arrayParent.Replace(new JProperty(jsonName, $"[parameters('{parameterName}')]"));
                    break;
                case JObject jo:
                    var objectParent = jo.Parent;
                    objectParent.Replace(new JProperty(jsonName, $"[parameters('{parameterName}')]"));
                    break;
                case null:
                    (jt as JObject).Add(new JProperty(jsonName, $"[parameters('{parameterName}')]"));
                    break;
            }
        }

        private object GetDefaultValue(object prop, string type)
        {
            switch (type)
            {
                case "string":
                    if (prop == null)
                        return string.Empty;

                    if (prop is String stringProp)
                    {
                        stringProp = stringProp.Replace("[", "");
                        stringProp = stringProp.Replace("]", "");
                        return stringProp;
                    }
                    else
                        return prop;
                case "object":
                    return prop == null ? new object() : prop;
                case "array":
                    return prop == null ? new object[0] : prop;
                default:
                    return prop;
            }
        }
    }
}
