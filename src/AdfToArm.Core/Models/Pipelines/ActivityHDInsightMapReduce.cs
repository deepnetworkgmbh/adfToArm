using AdfToArm.Core.Models.Pipelines.ActivityProperties;
using Newtonsoft.Json;

namespace AdfToArm.Core.Models.Pipelines
{
    [JsonObject]
    public class ActivityHDInsightMapReduce : Activity
    {
        public ActivityHDInsightMapReduce()
        {
            Type = ActivityType.HDInsightMapReduce;
            TypeProperties = new HDInsightMapReduceTypeProperties();
        }
    }
}
