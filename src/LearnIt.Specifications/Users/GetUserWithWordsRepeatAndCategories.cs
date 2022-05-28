using Ardalis.Specification;
using LearnIt.Domain;

namespace LearnIt.Specifications.Users
{
    public class GetUserWithWordsRepeatAndCategories : Specification<User>, ISingleResultSpecification
    {
        public GetUserWithWordsRepeatAndCategories(string deviceId)
        {
            Query
                .Where(u => u.DeviceId == deviceId)
                .Include(u => u.SelectedCategories)
                    .ThenInclude(sc => sc.Category)
                .Include(u => u.Words.Where(w => w.IsRepeat))
                    .ThenInclude(lw => lw.Word);
        }
    }
}