using LearnIt.Domain;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace LearnIt.EF
{
    public class LIContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Word> Words { get; set; }

        public LIContext(DbContextOptions<LIContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}