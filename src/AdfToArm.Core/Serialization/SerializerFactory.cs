using AdfToArm.Core.Logs;
using System;
using Newtonsoft.Json.Linq;

namespace AdfToArm.Core.Serialization
{
    public class SerializerFactory
    {
        public IAdfSerializer Create(string jsonString)
        {
            var jo = JObject.Parse(jsonString);

            if (jo["properties"]["activities"] != null)
            {
                // Pipeline
                return new PipelineSerializer(jsonString);
            }

            if (jo["properties"]["availability"] != null)
            {
                // DataSet
                return new DataSetSerializer(jsonString);
            }

            if (jo["properties"]["typeProperties"] != null)
            {
                // Linked Service
                return new LinkedServiceSerializer(jsonString);
            }
            
            // ???
            Logger.Instance.Info($"Unexpected content:{Environment.NewLine}{jsonString.Substring(0, 100)}");
            throw new AdfParseException("File contains unexpected content");
        }
    }
}
