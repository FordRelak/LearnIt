using Ardalis.Specification;
using LearnIt.Domain;

namespace LearnIt.Specifications.Categories
{
    public class GetCategoryWithWords : Specification<Category>, ISingleResultSpecification
    {
        public GetCategoryWithWords(long categoryId)
        {
            Query.Where(c => c.Id == categoryId)
                .Include(c => c.Words);
        }
    }
}