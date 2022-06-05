using System.Text.Json.Serialization;

namespace LearnIt.YandexDictionary
{
    public class YandexResponse
    {
        [JsonPropertyName("head")]
        public Head Head { get; set; }

        [JsonPropertyName("def")]
        public List<Def> Def { get; set; }
    }
}