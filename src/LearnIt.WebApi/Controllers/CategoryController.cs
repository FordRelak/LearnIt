using LearnIt.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LearnIt.WebApi.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategoriesAsync(CancellationToken cancellationToken = default)
        {
            var categories = await _categoryService.GetCategoriesAsync(cancellationToken);
            return Ok(categories);
        }
    }
}