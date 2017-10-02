using AdfToArm.Models.Pipelines.ActivityProperties;
using Newtonsoft.Json;

namespace AdfToArm.Models.Pipelines
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
