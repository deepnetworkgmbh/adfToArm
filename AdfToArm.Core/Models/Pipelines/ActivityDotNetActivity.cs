using AdfToArm.Core.Models.Pipelines.ActivityProperties;
using Newtonsoft.Json;

namespace AdfToArm.Core.Models.Pipelines
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
