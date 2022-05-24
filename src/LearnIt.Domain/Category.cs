using System.Collections.Generic;

namespace LearnIt.Domain
{
    public class Category : Base
    {
        public string Name { get; set; }
        public ICollection<Word> Words { get; set; } = new List<Word>();
    }
}