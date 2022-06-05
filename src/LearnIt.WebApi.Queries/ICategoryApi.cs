using LearnIt.DTO;
using Refit;

namespace LearnIt.WebApi.Queries
{
    public interface ICategoryApi
    {
        [Get("/Category")]
        Task<ICollection<ShortCategoryDto>> GetCategories();

        [Get("/Category/{categoryId}")]
        Task<CategoryDto> GetCategory([AliasAs("categoryId")] long categoryId);

        [Post("/Category")]
        Task<long> CreateCategory([Body] CreateCategoryDto dto);
    }
}