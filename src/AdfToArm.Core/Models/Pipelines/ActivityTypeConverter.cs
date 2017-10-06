using AdfToArm.Core.Logs;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace AdfToArm.Core.Models.Pipelines
{
    public class ActivityTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var result = new List<Activity>();
            JToken activityArray = JToken.Load(reader);

            foreach (var token in activityArray)
            {
                var typeValue = token["type"]?.ToString();

                ActivityType activityType = typeValue.ToEnum<ActivityType>();
                try
                {
                    switch (activityType)
                    {
                        case ActivityType.Copy:
                            result.Add(token.ToObject<ActivityCopy>());
                            break;
                        case ActivityType.DataLakeAnalyticsUSQL:
                            result.Add(token.ToObject<ActivityDataLakeAnalyticsUsql>());
                            break;
                        case ActivityType.DotNetActivity:
                            result.Add(token.ToObject<ActivityDotNetActivity>());
                            break;
                        case ActivityType.HDInsightSpark:
                            result.Add(token.ToObject<ActivityHDInsightSpark>());
                            break;
                        case ActivityType.SqlServerStoredProcedure:
                            result.Add(token.ToObject<ActivitySqlServerStoredProcedure>());
                            break;
                    }
                }
                catch (JsonSerializationException ex)
                {
                    Logger.Instance.Error($"Activity {typeValue}. \"{ex.Message}\" was handled processing {token["name"]}");
                    throw new AdfParseException($"Activity {typeValue}", ex);
                }
            }

            return result.ToArray();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var jt = JToken.FromObject(value);
            jt.WriteTo(writer);
        }
    }
}
