namespace LearnIt.Domain
{
    public class UserCategory : Base
    {
        public User User { get; set; }
        public Category Category { get; set; }
    }
}