using Ardalis.Specification;
using LearnIt.Domain;

namespace LearnIt.Specifications.Users
{
    public class GetUser : Specification<User>, ISingleResultSpecification
    {
        public GetUser(string deviceId)
        {
            Query.Where(u => u.DeviceId == deviceId);
        }
    }
}