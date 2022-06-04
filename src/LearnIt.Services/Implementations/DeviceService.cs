using AutoMapper;
using LearnIt.Domain;
using LearnIt.DTO;
using LearnIt.EF;
using LearnIt.Services.Interfaces;
using LearnIt.Specifications.Categories;
using LearnIt.Specifications.Users;
using LearnIt.Specifications.Words;

namespace LearnIt.Services.Implementations
{
    public class DeviceService : IDeviceService
    {
        private readonly Repository<User> _userRepository;
        private readonly Repository<Word> _wordRepository;
        private readonly Repository<Category> _categoryRepository;
        private readonly Repository<UserCategory> _userCategoryRepository;
        private readonly Repository<UserWord> _userWordRepository;

        private readonly IMapper _mapper;

        public DeviceService(
            IMapper mapper,
            Repository<User> userRepository,
            Repository<Word> wordRepository,
            Repository<Category> categoryRepository,
            Repository<UserCategory> userCategoryRepository,
            Repository<UserWord> userWordRepository)
        {
            _userRepository = userRepository;
            _wordRepository = wordRepository;
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _userCategoryRepository = userCategoryRepository;
            _userWordRepository = userWordRepository;
        }

        public async Task<ICollection<ShortWordDto>> GetNewWordsForLearn(
            string deviceId,
            CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetBySpecAsync(
                new GetUserWithWordsNoRepeatAndCategories(deviceId),
                cancellationToken);

            var words = await _wordRepository.ListAsync(new GetRandomWords(
                user.SelectedCategories.Select(sc => sc.Category.Id).ToArray(),
                user.Words.Select(le => le.Word.Id).ToArray(),
                user.NumberOfWords),
                cancellationToken);

            return _mapper.Map<List<ShortWordDto>>(words);
        }

        public async Task<ICollection<ShortWordDto>> GetRepeatWordsForLearn(
            string deviceId,
            CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetBySpecAsync(new GetUserWithWordsRepeatAndCategories(deviceId), cancellationToken);

            var words = user.Words.OrderBy(uw => Guid.NewGuid())
                                  .Take(user.NumberOfWords)
                                  .Select(w => w.Word);

            return _mapper.Map<List<ShortWordDto>>(words);
        }

        public async Task CreateOrUpdateUser(
            ShortUserDto dto,
            CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetBySpecAsync(new GetUserWithCategories(dto.DeviceId), cancellationToken);
            var categories = await _categoryRepository.ListAsync(new GetCategories(dto.SelectedCategoryIds), cancellationToken);

            if(user == null)
            {
                await _userRepository.AddAsync(new User
                {
                    DeviceId = dto.DeviceId,
                    NumberOfWords = dto.NumberOfWords,
                    SelectedCategories = categories.Select(c => new UserCategory()
                    {
                        Category = c,
                        User = user
                    }).ToList()
                }, cancellationToken);
            }
            else
            {
                await _userCategoryRepository.DeleteRangeAsync(user.SelectedCategories, cancellationToken);

                user.NumberOfWords = dto.NumberOfWords;
                user.SelectedCategories = categories.Select(c => new UserCategory()
                {
                    Category = c,
                    User = user
                }).ToList();
                await _userRepository.UpdateAsync(user, cancellationToken);
            }
        }

        public async Task SaveUserWords(
            SaveUserWordsDto dto,
            CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetBySpecAsync(new GetUserWithWordsAndCategories(dto.DeviceId), cancellationToken);
            var words = await _wordRepository.ListAsync(new GetWords(dto.WordIds), cancellationToken);

            var newUserWords = words.Select(w => new UserWord()
            {
                IsRepeat = true,
                User = user,
                Word = w
            }).ToList();

            user.Words = newUserWords.UnionBy(user.Words, w => w.Word.Id).ToList();

            await _userRepository.UpdateAsync(user, cancellationToken);
        }

        public async Task SaveLearnedWords(
            SaveUserWordsDto dto,
            CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetBySpecAsync(new GetUserWithWordsAndCategories(dto.DeviceId), cancellationToken);
            var words = await _wordRepository.ListAsync(new GetWords(dto.WordIds), cancellationToken);

            var userRepeatWords = user.Words.Where(x => x.IsRepeat && words.Select(a => a.Id)
                                                                           .Contains(x.Word.Id)).ToList();

            userRepeatWords.ForEach(x => x.IsRepeat = false);

            await _userWordRepository.SaveChangesAsync(cancellationToken);
        }

        public async Task<UserInfoDto> GetUserInfo(
            string deviceId,
            CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetBySpecAsync(new GetUserWithWords(deviceId), cancellationToken);

            var info = new UserInfoDto
            {
                LearnedWords = user.Words.Count(x => !x.IsRepeat),
                NumberOfWords = user.NumberOfWords
            };

            return info;
        }
    }
}