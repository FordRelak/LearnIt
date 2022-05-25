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

        public async Task<ICollection<ShortWordDto>> GetNewWordsForLearn(
            long[] categoryIds,
            int numberOfWords,
            CancellationToken cancellationToken = default)
        {
            var words = await _wordRepository.ListAsync(new GetRandomWords(
                categoryIds,
                numberOfWords), cancellationToken);

            var mappedWords = _mapper.Map<List<ShortWordDto>>(words);

            return mappedWords;
        }

        public async Task<ICollection<ShortWordDto>> GetNewWordsForLearn(
            string deviceId,
            long[] categoryIds,
            int numberOfWords,
            CancellationToken cancellationToken = default)
        {
            var user = await _userRepository.GetBySpecAsync(new GetUserWithCategories(deviceId), cancellationToken);

            if(user == null)
                return Array.Empty<ShortWordDto>();

            var uniqCategoryIds = user.SelectedCategories.Select(sc => sc.Category.Id)
                                                         .Intersect(categoryIds)
                                                         .ToArray();

            var uniqWords = await _wordRepository.ListAsync(new GetRandomWords(
                uniqCategoryIds,
                user.LearnedWords.Select(w => w.Id).ToArray(),
                numberOfWords), cancellationToken);

            return _mapper.Map<List<ShortWordDto>>(uniqWords);
        }
    }
}