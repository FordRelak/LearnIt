using AutoMapper;
using LearnIt.Domain;
using LearnIt.DTO;
using LearnIt.EF;
using LearnIt.Services.Interfaces;
using LearnIt.Specifications.Users;
using LearnIt.Specifications.Words;

namespace LearnIt.Services.Implementations
{
    public class WordService : IWordService
    {
        private readonly IMapper _mapper;
        private readonly Repository<Word> _wordRepository;
        private readonly Repository<Category> _categoryRepository;
        private readonly Repository<User> _userRepository;

        public WordService(
            IMapper mapper,
            Repository<Word> wordRepository,
            Repository<Category> categoryRepository,
            Repository<User> userRepository)
        {
            _mapper = mapper;
            _wordRepository = wordRepository;
            _categoryRepository = categoryRepository;
            _userRepository = userRepository;
        }
    }
}