using LearnIt.DTO;

namespace LearnIt.Services.Interfaces
{
    public interface IWordService
    {
        Task<long> CreateWord(CreateWordDto dto, CancellationToken cancellationToken);
        Task DeleteWord(long wordId, CancellationToken cancellationToken = default);
        Task<ShortWordDto> GetWordByOriginalWord(string word, CancellationToken cancellationToken);
        Task<ShortWordDto[]> GetWordBySearch(string searchWord, CancellationToken cancellationToken);
    }
}