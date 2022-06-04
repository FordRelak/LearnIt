using Ardalis.Specification;
using LearnIt.Domain;

namespace LearnIt.Specifications.Categories
{
    public class GetCategories : Specification<Category>
    {
        public GetCategories()
        {
            Query.OrderBy(c => c.Name);
        }

        public GetCategories(long[] categoryIds)
        {
            Query.Where(c => categoryIds.Contains(c.Id)).OrderBy(c => c.Name);
        }
    }
}