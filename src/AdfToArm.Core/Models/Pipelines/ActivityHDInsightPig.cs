using AdfToArm.Core.Models.Pipelines.ActivityProperties;
using Newtonsoft.Json;

namespace AdfToArm.Core.Models.Pipelines
{
    [JsonObject]
    public class ActivityHDInsightPig : Activity
    {
        public ActivityHDInsightPig()
        {
            Type = ActivityType.HDInsightPig;
            TypeProperties = new HDInsightPigTypeProperties();
        }
    }
}
