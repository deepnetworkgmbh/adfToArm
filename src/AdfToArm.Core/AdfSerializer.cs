using AdfToArm.Core.Models;
using AdfToArm.Core.Serialization;
using Newtonsoft.Json;
using System.IO;

namespace AdfToArm.Core
{
    public class AdfSerializer
    {
        private static readonly JsonSerializerSettings settings = new JsonSerializerSettings
        {
            Formatting = Formatting.Indented
        };

        private static readonly SerializerFactory factory = new SerializerFactory();

        public static string Serialize<T>(T value)
        {
            return JsonConvert.SerializeObject(value, settings);
        }

        public static (AdfItemType type, object value) Deserialize(string file)
        {
            var jsonString = File.ReadAllText(file);

            var serializer = factory.Create(jsonString);

            return serializer.Deserialize();
        }
    }
}
