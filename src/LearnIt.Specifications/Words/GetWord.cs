using Ardalis.Specification;
using LearnIt.Domain;

namespace LearnIt.Specifications.Words
{
    public class GetWord : Specification<Word>, ISingleResultSpecification
    {
        public GetWord(string word)
        {
            Query.Where(w => w.OriginalText.ToLower() == word.ToLower())
                 .Include(w => w.Category);
        }
    }
}