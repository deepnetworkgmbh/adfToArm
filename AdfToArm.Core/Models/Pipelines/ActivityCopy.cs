using AdfToArm.Core.Models.Pipelines.ActivityProperties;
using Newtonsoft.Json;

namespace AdfToArm.Core.Models.Pipelines
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
