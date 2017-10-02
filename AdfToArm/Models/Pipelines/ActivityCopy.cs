using AdfToArm.Models.Pipelines.ActivityProperties;
using Newtonsoft.Json;

namespace AdfToArm.Models.Pipelines
{
    [JsonObject]
    public class ActivityCopy : Activity
    {
        public ActivityCopy()
        {
            Type = ActivityType.Copy;
            TypeProperties = new CopyTypeProperties();
        }
    }
}
