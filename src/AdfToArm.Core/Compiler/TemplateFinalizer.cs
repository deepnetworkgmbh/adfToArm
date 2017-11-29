using AdfToArm.Core.Models;
using AdfToArm.Core.Models.ARM;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

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

            var parametersObject = armObject["parameters"] as JObject;
            foreach (var param in _parameters)
            {
                var name = param.Name;
                // TODO: do it properly...
                if (name == "Location")
                    param.Properties.DefaultValue = "northeurope";
                var content = JObject.FromObject(param.Properties);
                parametersObject.Add(name, content);
            }

            File.WriteAllText(_path, armObject.ToString(Formatting.Indented));

            var armTemplateParameters = new ArmTemplateParameters();
            armTemplateParameters.Parameters = _parameters.Select(i => new ArmTemplateParameterItem(i)).ToList();

            var paramsFilePath = _path.Substring(0, _path.Length - 4) + "parameters.json";
            var paramsFileJson = AdfSerializer.Serialize(armTemplateParameters);

            File.WriteAllText(paramsFilePath, paramsFileJson);
        }

        private void GenerateAndReplaceParameters(JObject jo)
        {
            var resource = _arm.Resources[0];
            var name = GetNodeName(resource);

            ProcessNodeElement(jo["resources"].First(), resource, $"resources_{name}");
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
                var armParamAttribute = attributes.FirstOrDefault(i => i is ArmParameterAttribute) as ArmParameterAttribute;
                if (armParamAttribute != null)
                {
                    var jsonName = GetJsonPropertyName(prop);
                    var parameterName = string.IsNullOrEmpty(armParamAttribute.Name)
                        ? $"{fullName}_{jsonName}"
                        : armParamAttribute.Name;
                    var type = armParamAttribute.Type;

                    ReplacePropertyWithParameter(
                        jt,
                        GetDefaultValue(prop.GetValue(nodeObject), type, armParamAttribute.RemoveBrackets),
                        type,
                        parameterName,
                        jsonName);
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

        private string GetJsonPropertyName(PropertyInfo property)
        {
            var jsonAttr = property.GetCustomAttributes(false).FirstOrDefault(i => i is JsonPropertyAttribute);

            var jsonName = jsonAttr != null
                ? (jsonAttr as JsonPropertyAttribute).PropertyName
                : property.GetType().Name;

            return jsonName;
        }

        private void ReplacePropertyWithParameter(JToken jt, object prop, string type, string parameterName, string jsonName)
        {
            var armParam = new ArmParameter()
            {
                Name = parameterName,
                Properties = new ArmParameterProperties
                {
                    DefaultValue = prop,
                    Type = type
                }
            };

            if (_parameters.Any(i => i.Name == armParam.Name))
                return;

            _parameters.Add(armParam);

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
                    (jt as JObject).Add(new JProperty(jsonName, $"[parameters('{parameterName}')]"));
                    break;
            }
        }

        private object GetDefaultValue(object prop, string type, bool removeBrackets)
        {
            switch (type)
            {
                case "string":
                    if (prop == null)
                        return string.Empty;

                    if (removeBrackets && prop is string stringProp)
                    {
                        stringProp = stringProp.Replace("[", "");
                        stringProp = stringProp.Replace("]", "");
                        return stringProp;
                    }
                    else if (prop is Enum)
                        return prop.ToEnumString();
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
