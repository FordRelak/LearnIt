using System.Collections.Generic;

namespace LearnIt.DTO
{
    public class CategoryDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public ICollection<ShortWordDto> Words { get; set; } = new List<ShortWordDto>();
    }
}