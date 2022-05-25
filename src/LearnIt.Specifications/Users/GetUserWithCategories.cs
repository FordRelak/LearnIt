using Ardalis.Specification;
using LearnIt.Domain;

namespace LearnIt.Specifications.Users
{
    public class GetUserWithCategories : Specification<User>, ISingleResultSpecification
    {
        public GetUserWithCategories(string deviceId)
        {
            Query
                .Where(u => u.DeviceId == deviceId)
                .Include(u => u.SelectedCategories);
        }
    }
}