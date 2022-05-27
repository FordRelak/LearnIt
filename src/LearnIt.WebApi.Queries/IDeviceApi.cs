using LearnIt.DTO;
using Refit;

namespace LearnIt.WebApi.Queries
{
    public interface IDeviceApi
    {
        [Get("/Device/{deviceId}/learn/new")]
        public Task<ICollection<ShortWordDto>> GetNewWordToLearn([AliasAs("deviceId")] string deviceId);

        [Post("/Device")]
        public Task Create([Body(BodySerializationMethod.Serialized)] ShortUserDto userDto);
    }
}