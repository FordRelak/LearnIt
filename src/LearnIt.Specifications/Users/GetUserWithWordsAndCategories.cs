using Ardalis.Specification;
using LearnIt.Domain;

namespace LearnIt.Specifications.Users
{
    public class GetUserWithWordsAndCategories : Specification<User>, ISingleResultSpecification
    {
        public GetUserWithWordsAndCategories(string deviceId)
        {
            Query
                .Where(u => u.DeviceId == deviceId)
                .Include(u => u.SelectedCategories)
                    .ThenInclude(sc => sc.Category)
                .Include(u => u.Words)
                    .ThenInclude(lw => lw.Word);
        }
    }
}