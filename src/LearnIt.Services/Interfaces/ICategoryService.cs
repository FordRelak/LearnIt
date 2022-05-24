using LearnIt.Domain;

namespace LearnIt.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<List<Category>> GetCategoriesAsync(CancellationToken cancellationToken = default);
        Task<Category?> GetCategoryAsync(long categoryId, CancellationToken cancellationToken = default);
    }
}