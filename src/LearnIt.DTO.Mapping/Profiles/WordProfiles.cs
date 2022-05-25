using AutoMapper;
using LearnIt.Domain;

namespace LearnIt.DTO.Mapping.Profiles
{
    public class WordProfiles : Profile
    {
        public WordProfiles()
        {
            CreateMap<Word, ShortWordDto>()
                .ForMember(dst => dst.CategoryName, opt => opt.MapFrom(src => src.Category.Name));
        }
    }
}