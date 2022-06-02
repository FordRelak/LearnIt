using AutoMapper;
using LearnIt.Domain;
using LearnIt.DTO;
using LearnIt.EF;
using LearnIt.Services.Interfaces;
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

        public async Task<ShortWordDto[]> GetWordBySearch(string searchWord, CancellationToken cancellationToken)
        {
            var words = await _wordRepository.ListAsync(new GetWords(searchWord), cancellationToken);
            return _mapper.Map<ShortWordDto[]>(words);
        }
    }
}