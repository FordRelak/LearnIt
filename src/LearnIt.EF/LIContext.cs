using LearnIt.Domain;
using Microsoft.EntityFrameworkCore;
using Npgsql;
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

        public void InitializePostgresUuidExtension()
        {
            using var npgsqlConnection = new NpgsqlConnection(Database.GetConnectionString());
            npgsqlConnection.Open();

            using var npgsqlCommand = npgsqlConnection.CreateCommand();
            npgsqlCommand.CommandText = "CREATE EXTENSION IF NOT EXISTS \"uuid-ossp\";";
            npgsqlCommand.ExecuteNonQuery();
        }
    }
}