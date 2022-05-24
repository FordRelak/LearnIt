using LearnIt.Domain;
using System.Text.RegularExpressions;

namespace LearnIt.EF
{
    public class Seeder
    {
        private readonly LIContext _context;

        public Seeder(LIContext context)
        {
            _context = context;
        }

        public async Task SeedDbAsync()
        {
            if(_context.Categories.Any())
            {
                return;
            }

            var directory = Directory.GetCurrentDirectory();
            var slovarPath = Path.Combine(directory, "slovar");
            var files = Directory.GetFiles(slovarPath);

            foreach(var file in files)
            {
                var fileName = Path.GetFileNameWithoutExtension(file);
                var category = await GetOrCreateCategoryAsync(fileName);
                ProccessFile(file, category);
            }

            await _context.SaveChangesAsync();
        }

        public void ProccessFile(string file, Category category)
        {
            var lines = File.ReadAllLines(file);
            var regex = new Regex("(.*)//(.*)");

            foreach(var line in lines)
            {
                var match = regex.Match(line);
                
                if(match.Success)
                {
                    var originalText = match.Groups[1].Value;
                    var translatedText = match.Groups[2].Value;
                    var newWord = new Word
                    {
                        Category = category,
                        OriginalText = originalText,
                        TranslatedText = translatedText
                    };
                    category.Words.Add(newWord);
                }
            }
        }

        public async Task<Category> GetOrCreateCategoryAsync(string name)
        {
            var category = _context.Categories.Local.FirstOrDefault(c => c.Name == name);

            if(category is not null)
                return category;

            var newCategory = new Category
            {
                Name = name
            };

            await _context.AddAsync(newCategory);
            return newCategory;
        }
    }
}