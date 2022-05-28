using Ardalis.Specification;
using LearnIt.Domain;

namespace LearnIt.Specifications.Categories
{
    public class GetCategories : Specification<Category>
    {
        public GetCategories(long[] categoryIds)
        {
            Query.Where(c => categoryIds.Contains(c.Id));
        }
    }
}