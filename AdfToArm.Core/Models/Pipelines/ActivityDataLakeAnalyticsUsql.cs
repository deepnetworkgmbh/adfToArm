using AdfToArm.Core.Models.Pipelines.ActivityProperties;
using Newtonsoft.Json;

namespace AdfToArm.Core.Models.Pipelines
{
    [JsonObject]
    public class ActivityDataLakeAnalyticsUsql : Activity
    {
        public ActivityDataLakeAnalyticsUsql()
        {
            Type = ActivityType.DataLakeAnalyticsUSQL;
            TypeProperties = new DataLakeAnalyticsUsqlTypeProperties();
        }
    }
}
