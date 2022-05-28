using System.Collections.Generic;

namespace LearnIt.Domain
{
    public class User: Base
    {
        public string DeviceId { get; set; }
        public int NumberOfWords { get; set; }
        public ICollection<UserWord> Words { get; set; } = new List<UserWord>();
        public ICollection<UserCategory> SelectedCategories { get; set; } = new List<UserCategory>();
    }
}