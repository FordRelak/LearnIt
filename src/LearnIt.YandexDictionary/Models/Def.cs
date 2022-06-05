using System.Text.Json.Serialization;

namespace LearnIt.YandexDictionary
{
    public class Def
    {
        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("pos")]
        public string Pos { get; set; }

        [JsonPropertyName("tr")]
        public List<Tr> Tr { get; set; }
    }
}