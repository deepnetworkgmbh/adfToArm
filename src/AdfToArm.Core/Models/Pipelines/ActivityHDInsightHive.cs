using AdfToArm.Core.Models.Pipelines.ActivityProperties;
using Newtonsoft.Json;

namespace AdfToArm.Core.Models.Pipelines
{
    [JsonObject]
    public class ActivityHDInsightHive : Activity
    {
        public ActivityHDInsightHive()
        {
            Type = ActivityType.HDInsightHive;
            TypeProperties = new HDInsightHiveTypeProperties();
        }
    }
}
