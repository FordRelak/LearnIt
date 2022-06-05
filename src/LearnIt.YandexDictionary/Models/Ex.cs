using System.Text.Json.Serialization;

namespace LearnIt.YandexDictionary
{
    public class Ex
    {
        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("tr")]
        public List<Tr> Tr { get; set; }
    }
}