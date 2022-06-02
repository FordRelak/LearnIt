using LearnIt.DTO;
using Refit;

namespace LearnIt.WebApi.Queries
{
    public interface IWordApi
    {
        [Get("/Word/search")]
        public Task<ShortWordDto[]> GetWordBySearch([AliasAs("searchWord")] string searchWord);
    }
}