using LearnIt.DTO;
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

        /// <summary>
        /// Получение списка существующих категорий
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetCategoriesAsync(CancellationToken cancellationToken = default)
        {
            var categories = await _categoryService.GetCategoriesAsync(cancellationToken);
            return Ok(categories);
        }

        /// <summary>
        /// Создание новой категории
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDto dto, CancellationToken cancellationToken)
        {
            return Ok(await _categoryService.CreateCategoryAsync(dto, cancellationToken));
        }

        /// <summary>
        /// Получение категории по идентификатору
        /// </summary>
        [HttpGet("{categoryId}")]
        public async Task<IActionResult> GetCategory([FromRoute] long categoryId, CancellationToken cancellationToken)
        {
            return Ok(await _categoryService.GetCategoryAsync(categoryId, cancellationToken));
        }
    }
}