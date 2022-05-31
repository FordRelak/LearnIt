using LearnIt.DTO;
using LearnIt.WebApi.Queries;

namespace LearnIt.MAUI.Services
{
    public class CategoryService
    {
        private readonly ICategoryApi _categoryApi;

        public CategoryService(ICategoryApi categoryApi)
        {
            _categoryApi = categoryApi;
        }

        public async Task<ShortCategoryDto[]> GetCategories()
        {
            return (await _categoryApi.GetCategories()).ToArray();
        }
    }
}