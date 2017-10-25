using AdfToArm.Core.Models.Pipelines.ActivityProperties;
using Newtonsoft.Json;

namespace AdfToArm.Core.Models.Pipelines
{
    [JsonObject]
    public class ActivityMlBatchExecutor : Activity
    {
        public ActivityMlBatchExecutor()
        {
            Type = ActivityType.AzureMLBatchExecution;
            TypeProperties = new MlBatchExecutorTypeProperties();
        }
    }
}
