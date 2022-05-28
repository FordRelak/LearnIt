using Ardalis.Specification;
using LearnIt.Domain;

namespace LearnIt.Specifications.Users
{
    public class GetUserWithWordsNoRepeatAndCategories : Specification<User>, ISingleResultSpecification
    {
        public GetUserWithWordsNoRepeatAndCategories(string deviceId)
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