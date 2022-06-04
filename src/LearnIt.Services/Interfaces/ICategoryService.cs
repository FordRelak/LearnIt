using LearnIt.Domain;
using LearnIt.DTO;

namespace LearnIt.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<long> CreateCategoryAsync(CreateCategoryDto dto, CancellationToken cancellationToken);
        Task<List<ShortCategoryDto>> GetCategoriesAsync(CancellationToken cancellationToken = default);
    }
}