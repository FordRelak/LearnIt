using System.Text.Json.Serialization;

namespace LearnIt.YandexDictionary
{
    public class Syn
    {
        [JsonPropertyName("text")]
        public string Text { get; set; }
    }
}