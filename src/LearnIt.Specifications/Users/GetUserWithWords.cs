using Ardalis.Specification;
using LearnIt.Domain;

namespace LearnIt.Specifications.Users
{
    public class GetUserWithWords : Specification<User>, ISingleResultSpecification
    {
        public GetUserWithWords(string deviceId)
        {
            Query
                .Where(u => u.DeviceId == deviceId)
                .Include(u => u.Words);
        }
    }
}