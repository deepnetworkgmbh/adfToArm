using System;
using AdfToArm.Core.Models;
using AdfToArm.Core.Models.ARM;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdfToArm.Core.Compiler
{
    public class TemplateFinalizer
    {
        private readonly string _path;
        private readonly ArmTemplate _arm;
        private readonly List<ArmParameter> _parameters = new List<ArmParameter>();

        public TemplateFinalizer(string path, ArmTemplate arm)
        {
            _path = path;
            _arm = arm;
        }

        public void CreateParamsAndSaveToFiles()
        {
            var armObject = JObject.FromObject(_arm);

            GenerateAndReplaceParameters(armObject);

            var parametersObject = (JObject)armObject["parameters"];
            foreach (var parameter in _parameters)
            {
                var param = parameter;
                if (param.Name.Equals(Constants.LocationParameterName, StringComparison.InvariantCultureIgnoreCase))
                    param.Properties.DefaultValue = Constants.LocationParameterDefaultValue;

                var content = JObject.FromObject(param.Properties);
                parametersObject.Add(param.Name, content);
            }

            File.WriteAllText(_path, armObject.ToString(Formatting.Indented));

            var armTemplateParameters = new ArmTemplateParameters
            {
                Parameters = _parameters.Select(i => new ArmTemplateParameterItem(i)).ToList()
            };

            var paramsFilePath = _path.Substring(0, _path.Length - 4) + "parameters.json";
            var paramsFileJson = AdfSerializer.Serialize(armTemplateParameters);

            File.WriteAllText(paramsFilePath, paramsFileJson);
        }

        private void GenerateAndReplaceParameters(JObject jo)
        {
            var resource = _arm.Resources[0];
            var name = resource.GetNodeName();

            ProcessNodeElement(jo["resources"].First(), resource, $"resources_{name}");
        }

        private void ProcessNodeElement(JToken jt, object nodeObject, string fullName)
        {
            if (nodeObject == null)
                return;

            var nodeType = nodeObject.GetType();
            if (nodeType.IsSimple() || nodeType.IsArray && nodeType.GetElementType().IsSimple())
                return;

            if (nodeObject is IEnumerable enumerator)
            {
                var counter = 0;
                foreach (var element in enumerator)
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
                if (attributes.FirstOrDefault(i => i is ArmParameterAttribute) is ArmParameterAttribute armParamAttribute)
                {
                    var jsonName = prop.GetJsonPropertyName();
                    var parameterName = string.IsNullOrEmpty(armParamAttribute.Name)
                        ? $"{fullName}_{jsonName}"
                        : armParamAttribute.Name;
                    var type = armParamAttribute.Type;

                    var armParam = new ArmParameter
                    {
                        Name = parameterName,
                        Properties = new ArmParameterProperties
                        {
                            DefaultValue = prop.GetValue(nodeObject).GetDefaultPropertyValue(type, armParamAttribute.RemoveBrackets),
                            Type = type
                        }
                    };

                    ReplacePropertyWithParameter(jt, armParam, parameterName, jsonName);
                }
                else if (attributes.Any(i => i is JsonPropertyAttribute))
                {
                    var nextNode = prop.GetValue(nodeObject);

                    var jsonName = prop.GetJsonPropertyName();

                    ProcessNodeElement(jt[jsonName], nextNode, $"{fullName}_{jsonName}");
                }
            }
        }

        private void ReplacePropertyWithParameter(JToken jt, ArmParameter armParam, string parameterName, string jsonName)
        {

            switch (jt[jsonName])
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
                    ((JObject) jt).Add(new JProperty(jsonName, $"[parameters('{parameterName}')]"));
                    break;
            }

            if (_parameters.All(i => i.Name != armParam.Name))
                _parameters.Add(armParam);
        }
    }
}