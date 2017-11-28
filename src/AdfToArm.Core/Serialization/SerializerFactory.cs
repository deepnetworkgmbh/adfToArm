using AdfToArm.Core.Logs;
using System;

namespace AdfToArm.Core.Serialization
{
    public class SerializerFactory
    {
        public IAdfSerializer Create(string jsonString)
        {
            if (jsonString.Contains("activities"))
            {
                // Pipeline
                return new PipelineSerializer(jsonString);
            }
            else if (jsonString.Contains("availability"))
            {
                // DataSet
                return new DataSetSerializer(jsonString);
            }
            else if (jsonString.Contains("typeProperties"))
            {
                // Linked Service
                return new LinkedServiceSerializer(jsonString);
            }
            else
            {
                // ???
                Logger.Instance.Info($"Unexpected content:{Environment.NewLine}{jsonString.Substring(0, 100)}");
                throw new AdfParseException("File contains unexpected content");
            }
        }
    }
}
