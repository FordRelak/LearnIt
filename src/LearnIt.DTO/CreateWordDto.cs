namespace LearnIt.DTO
{
    public class CreateWordDto
    {
        public long CategoryId { get; set; }
        public string OriginalText { get; set; }
        public string TranslatedText { get; set; }
    }
}