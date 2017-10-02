using AdfToArm.Models.Pipelines.ActivityProperties;
using Newtonsoft.Json;

namespace AdfToArm.Models.Pipelines
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
