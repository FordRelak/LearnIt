using LearnIt.DTO;

namespace LearnIt.Services.Interfaces
{
    public interface IWordService
    {
        Task<ICollection<ShortWordDto>> GetNewWordsForLearn(long[] categoryIds, int numberOfWords, CancellationToken cancellationToken = default);
    }
}