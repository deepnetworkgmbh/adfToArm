using AdfToArm.Core.Models.Pipelines.ActivityProperties;
using Newtonsoft.Json;

namespace AdfToArm.Core.Models.Pipelines
{
    [JsonObject]
    public class ActivityHDInsightSpark : Activity
    {
        public ActivityHDInsightSpark()
        {
            Type = ActivityType.HDInsightSpark;
            TypeProperties = new HDInsightSparkTypeProperties();
        }
    }
}
