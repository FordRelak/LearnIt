using Ardalis.Specification;
using LearnIt.Domain;

namespace LearnIt.Specifications.Words
{
    public class GetRandomWords : Specification<Word>
    {
        public GetRandomWords(
            long[] categoryIds,
            long[] exceptWordIds,
            int numberOfWords)
        {
            var random = new Random();
            Query.Include(w => w.Category)
                .Where(w => categoryIds.Contains(w.Category.Id))
                .Where(w => !exceptWordIds.Contains(w.Category.Id))
                .OrderBy(w => Guid.NewGuid())
                .Take(numberOfWords);
        }
    }
}