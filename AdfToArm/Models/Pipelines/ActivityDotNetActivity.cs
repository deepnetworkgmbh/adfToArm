using AdfToArm.Models.Pipelines.ActivityProperties;
using Newtonsoft.Json;

namespace AdfToArm.Models.Pipelines
{
    [JsonObject]
    public class ActivityDotNetActivity : Activity
    {
        public ActivityDotNetActivity()
        {
            Type = ActivityType.DotNetActivity;
            TypeProperties = new DotNetActivityTypeProperties();
        }
    }
}
