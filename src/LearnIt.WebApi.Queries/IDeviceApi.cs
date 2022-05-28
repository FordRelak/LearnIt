using LearnIt.DTO;
using Refit;

namespace LearnIt.WebApi.Queries
{
    public interface IDeviceApi
    {
        [Post("/Device")]
        public Task Create([Body(BodySerializationMethod.Serialized)] ShortUserDto userDto);

        [Get("/Device/{deviceId}/learn/new")]
        public Task<ICollection<ShortWordDto>> GetNewWordToLearn([AliasAs("deviceId")] string deviceId);

        [Get("/Device/{deviceId}/learn/repeat")]
        public Task<ICollection<ShortWordDto>> GetRepeatWordsForLearn([AliasAs("deviceId")] string deviceId);

        [Post("/Device/learn/new")]
        public Task SaveWordsToRepeat([Body(BodySerializationMethod.Serialized)] SaveUserWordsDto saveUserWordsDto);

        [Post("/Device/learn/repeat")]
        public Task SaveLearnedWords([Body(BodySerializationMethod.Serialized)] SaveUserWordsDto saveUserWordsDto);

        [Get("/Device/{deviceId}/info")]
        public Task<UserInfoDto> GetUserInfo([AliasAs("deviceId")] string deviceId);
    }
}