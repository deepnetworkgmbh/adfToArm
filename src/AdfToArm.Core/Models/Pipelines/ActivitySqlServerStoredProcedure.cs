using AdfToArm.Core.Models.Pipelines.ActivityProperties;
using Newtonsoft.Json;

namespace AdfToArm.Core.Models.Pipelines
{
    [JsonObject]
    public class ActivitySqlServerStoredProcedure : Activity
    {
        public ActivitySqlServerStoredProcedure()
        {
            Type = ActivityType.SqlServerStoredProcedure;
            TypeProperties = new SqlServerStoredProcedureTypeProperties();
        }
    }
}
