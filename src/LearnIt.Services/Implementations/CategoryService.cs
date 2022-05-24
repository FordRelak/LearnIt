using LearnIt.Domain;
using LearnIt.EF;
using LearnIt.Services.Interfaces;
using LearnIt.Specifications.Categories;

namespace LearnIt.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly Repository<Category> _categoryRepository;

        public CategoryService(Repository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Category?> GetCategoryAsync(long categoryId, CancellationToken cancellationToken = default)
        {
            return await _categoryRepository.GetBySpecAsync(new GetCategoryWithWords(categoryId), cancellationToken);
        }

        public async Task<List<Category>> GetCategoriesAsync(CancellationToken cancellationToken = default)
        {
            return await _categoryRepository.ListAsync(cancellationToken);
        }
    }
}