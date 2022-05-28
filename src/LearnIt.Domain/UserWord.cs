namespace LearnIt.Domain
{
    public class UserWord : Base
    {
        public User User { get; set; }
        public Word Word { get; set; }
        public bool IsRepeat { get; set; }
    }
}