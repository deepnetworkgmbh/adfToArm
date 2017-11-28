using AdfToArm.Core.Logs;
using AdfToArm.Core.Models;
using AdfToArm.Core.Models.Pipelines;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AdfToArm.Core.Serialization
{
    public class PipelineSerializer : IAdfSerializer
    {
        private readonly string _json;

        public PipelineSerializer(string jsonString)
        {
            _json = jsonString;
        }

        public (AdfItemType type, object value) Deserialize()
        {
            try
            {
                var jo = JObject.Parse(_json);
                var pipeline = jo.ToObject<Pipeline>();
                return (AdfItemType.Pipeline, pipeline);
            }
            catch (JsonReaderException ex)
            {
                Logger.Instance.Error($"JSON parse failed. \"{ex.Message}\" was handled");
                throw new AdfParseException("JSON parse failed", ex);
            }
            catch (JsonSerializationException ex)
            {
                Logger.Instance.Error($"Pipeline parsing failed. \"{ex.Message}\" was handled");
                throw new AdfParseException("Pipeline parsing failed", ex);
            }
        }
    }
}
