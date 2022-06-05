using AutoMapper;
using LearnIt.Domain;
using LearnIt.DTO;
using LearnIt.EF;
using LearnIt.Services.Interfaces;
using LearnIt.Specifications.Categories;

namespace LearnIt.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly Repository<Category> _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(
            Repository<Category> categoryRepository,
            IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<List<ShortCategoryDto>> GetCategoriesAsync(CancellationToken cancellationToken = default)
        {
            var categories = await _categoryRepository.ListAsync(new GetCategories(), cancellationToken);
            return _mapper.Map<List<ShortCategoryDto>>(categories);
        }

        public async Task<long> CreateCategoryAsync(CreateCategoryDto dto, CancellationToken cancellationToken)
        {
            var newCategory = new Category
            {
                Name = dto.Name
            };

            await _categoryRepository.AddAsync(newCategory, cancellationToken);

            return newCategory.Id;
        }

        public async Task<CategoryDto> GetCategoryAsync(long categoryId, CancellationToken cancellationToken = default)
        {
            var category = await _categoryRepository.GetBySpecAsync(new GetCategoryWithWords(categoryId), cancellationToken);
            return _mapper.Map<CategoryDto>(category);
        }
    }
}