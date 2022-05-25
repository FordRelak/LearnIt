﻿using LearnIt.Domain;
using LearnIt.DTO;

namespace LearnIt.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<List<ShortCategoryDto>> GetCategoriesAsync(CancellationToken cancellationToken = default);
        Task<CategoryDto> GetCategoryAsync(long categoryId, CancellationToken cancellationToken = default);
    }
}