using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LearnIt.EF
{
    public class Repository<TEntity> : RepositoryBase<TEntity> where TEntity : class
    {
        public Repository(LIContext dbContext) : base(dbContext)
        {
        }
    }
}