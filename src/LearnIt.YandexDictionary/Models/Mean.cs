using System.Text.Json.Serialization;

namespace LearnIt.YandexDictionary
{
    public class Mean
    {
        [JsonPropertyName("text")]
        public string Text { get; set; }
    }
}