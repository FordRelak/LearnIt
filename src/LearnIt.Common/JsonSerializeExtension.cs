using System.Text.Json;

namespace LearnIt.Common
{
    public static class JsonSerializeExtension
    {
        public static T TryDeserialize<T>(string json, JsonSerializerOptions options = null)
        {
            if(string.IsNullOrEmpty(json))
                return default;

            try
            {
                var result = JsonSerializer.Deserialize<T>(json, options);
                return result;
            }
            catch(Exception)
            {
                return default;
            }
        }

        public static T[] TryDeserializeArray<T>(string json, JsonSerializerOptions options = null)
        {
            if(string.IsNullOrEmpty(json))
                return Array.Empty<T>();

            try
            {
                var result = JsonSerializer.Deserialize<T[]>(json, options);
                return result;
            }
            catch(Exception)
            {
                return Array.Empty<T>();
            }
        }
    }
}