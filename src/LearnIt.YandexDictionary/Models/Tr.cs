using System.Text.Json.Serialization;

namespace LearnIt.YandexDictionary
{
    public class Tr
    {
        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("pos")]
        public string Pos { get; set; }

        [JsonPropertyName("syn")]
        public List<Syn> Syn { get; set; }

        [JsonPropertyName("mean")]
        public List<Mean> Mean { get; set; }

        [JsonPropertyName("ex")]
        public List<Ex> Ex { get; set; }
    }
}