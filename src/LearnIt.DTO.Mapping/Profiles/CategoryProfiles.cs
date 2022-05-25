using AutoMapper;
using LearnIt.Domain;

namespace LearnIt.DTO.Mapping.Profiles
{
    public class CategoryProfiles : Profile
    {
        public CategoryProfiles()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<Category, ShortCategoryDto>();
        }
    }
}