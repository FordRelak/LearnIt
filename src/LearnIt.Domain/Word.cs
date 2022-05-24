namespace LearnIt.Domain
{
    public class Word : Base
    {
        public string OriginalText { get; set; }
        public string TranslatedText { get; set; }
        public Category Category { get; set; }
    }
}