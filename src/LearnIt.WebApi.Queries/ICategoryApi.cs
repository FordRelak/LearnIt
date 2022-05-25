using LearnIt.DTO;
using Refit;

namespace LearnIt.WebApi.Queries
{
    public interface ICategoryApi
    {
        [Get("/Category")]
        Task<ICollection<ShortCategoryDto>> GetCategories();

        [Get("/Category/{id}")]
        Task<ICollection<ShortCategoryDto>> GetCategory([AliasAs("id")] long categoryId);
    }
}