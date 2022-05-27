using AutoMapper;
using LearnIt.Domain;
using LearnIt.DTO;
using LearnIt.EF;
using LearnIt.Services.Interfaces;
using LearnIt.Specifications.Users;
using LearnIt.Specifications.Words;

namespace LearnIt.Services.Implementations
{
    public class DeviceService : IDeviceService
    {
        private readonly Repository<User> _userRepository;
        private readonly Repository<Word> _wordRepository;

        private readonly IMapper _mapper;

        public DeviceService(
            Repository<User> userRepository,
            Repository<Word> wordRepository,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _wordRepository = wordRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<ShortWordDto>> GetNewWordsForLearn(
            string deviceId,
            CancellationToken cancellationToken = default)
        {
            var user = await _userRepository.GetBySpecAsync(
                new GetUserWithWordsAndCategories(deviceId),
                cancellationToken);

            var words = await _wordRepository.ListAsync(new GetRandomWords(
                user.SelectedCategories.Select(sc => sc.Category.Id).ToArray(),
                user.LearnedWords.Select(le => le.Word.Id).ToArray(),
                user.NumberOfWords),
                cancellationToken);

            return _mapper.Map<List<ShortWordDto>>(words);
        }

        public async Task CreateOrUpdateUser(ShortUserDto dto, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetBySpecAsync(new GetUser(dto.DeviceId), cancellationToken);

            if(user == null)
            {
                await _userRepository.AddAsync(new User
                {
                    DeviceId = dto.DeviceId,
                    NumberOfWords = dto.NumberOfWords
                }, cancellationToken);
            }
            else
            {
                user.NumberOfWords = dto.NumberOfWords;
                await _userRepository.UpdateAsync(user, cancellationToken);
            }
        }
    }
}