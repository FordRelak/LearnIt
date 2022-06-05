using Ardalis.Specification;
using LearnIt.Domain;
using Microsoft.EntityFrameworkCore;

namespace LearnIt.Specifications.Words
{
    public class GetWords : Specification<Word>
    {
        public GetWords(long[] wordIds)
        {
            Query.Where(w => wordIds.Contains(w.Id));
        }

        public GetWords(string searchWord)
        {
            Query.Where(w => EF.Functions.Like(w.OriginalText.ToLower(), $"%{searchWord.ToLower()}%"))
                 .Include(w => w.Category)
                 .OrderBy(w => w.OriginalText.Length);
        }
    }
}