using LearnIt.DTO;

namespace LearnIt.Services.Interfaces
{
    public interface IWordService
    {
        Task<ShortWordDto[]> GetWordBySearch(string searchWord, CancellationToken cancellationToken);
    }
}