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

        public async Task<ShortWordDto> GetWordByOriginalWord(string word, CancellationToken cancellationToken)
        {
            var wordModel = await _wordRepository.GetBySpecAsync(new GetWord(word), cancellationToken);

            if(wordModel == null) return null;

            return _mapper.Map<ShortWordDto>(wordModel);
        }

        public async Task<long> CreateWord(CreateWordDto dto, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(dto.CategoryId, cancellationToken);
            var newWord = new Word
            {
                Category = category,
                OriginalText = dto.OriginalText,
                TranslatedText = dto.TranslatedText
            };

            await _wordRepository.AddAsync(newWord, cancellationToken);

            return newWord.Id;
        }

        public async Task DeleteWord(long wordId, CancellationToken cancellationToken = default)
        {
            var word = await _wordRepository.GetByIdAsync(wordId, cancellationToken);
            if(word is not null)
            {
                await _wordRepository.DeleteAsync(word, cancellationToken);
            }
        }
    }
}