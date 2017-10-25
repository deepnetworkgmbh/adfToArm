using AdfToArm.Core.Models.Pipelines.ActivityProperties;
using Newtonsoft.Json;

namespace AdfToArm.Core.Models.Pipelines
{
    [JsonObject]
    public class ActivityHDInsightStreaming : Activity
    {
        public ActivityHDInsightStreaming()
        {
            Type = ActivityType.HDInsightStreaming;
            TypeProperties = new HDInsightStreamingTypeProperties();
        }
    }
}
