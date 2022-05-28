using Ardalis.Specification;
using LearnIt.Domain;

namespace LearnIt.Specifications.Words
{
    public class GetWords : Specification<Word>
    {
        public GetWords(long[] wordIds)
        {
            Query.Where(w => wordIds.Contains(w.Id));
        }
    }
}