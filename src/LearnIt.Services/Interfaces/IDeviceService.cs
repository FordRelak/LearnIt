using LearnIt.DTO;

namespace LearnIt.Services.Interfaces
{
    public interface IDeviceService
    {
        Task CreateOrUpdateUser(ShortUserDto dto, CancellationToken cancellationToken);

        Task<ICollection<ShortWordDto>> GetNewWordsForLearn(string deviceId, CancellationToken cancellationToken);
        Task<ICollection<ShortWordDto>> GetRepeatWordsForLearn(string deviceId, CancellationToken cancellationToken);
        Task<UserInfoDto> GetUserInfo(string deviceId, CancellationToken cancellationToken);
        Task SaveLearnedWords(SaveUserWordsDto dto, CancellationToken cancellationToken);
        Task SaveUserWords(SaveUserWordsDto dto, CancellationToken cancellationToken);
    }
}