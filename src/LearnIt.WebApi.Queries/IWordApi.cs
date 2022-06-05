using LearnIt.DTO;
using Refit;

namespace LearnIt.WebApi.Queries
{
    public interface IWordApi
    {
        [Get("/Word/search")]
        public Task<ShortWordDto[]> GetWordBySearch([AliasAs("searchWord")] string searchWord);

        [Get("/Word")]
        public Task<ApiResponse<ShortWordDto>> GetWordByOriginalWord([AliasAs("word")] string word);

        [Post("/Word")]
        public Task<long> CreateWord([Body(BodySerializationMethod.Serialized)] CreateWordDto createWordDto);

        [Get("/Yandex")]
        public Task<string> GetTranslate([AliasAs("originalWord")] string originalWord);
    }
}