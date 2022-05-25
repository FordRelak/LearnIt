using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LearnIt.EF
{
    public static class Module
    {
        public static IServiceCollection ConfigureEF(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<LIContext>(config =>
            {
                config.UseNpgsql(configuration.GetConnectionString("PosgresConnectionString"));
            });

            services.AddScoped<Seeder>();
            services.AddScoped(typeof(Repository<>));

            return services;
        }

        public static async Task<IHost> ApplyMigrationAsync(this IHost host)
        {
            using var scope = host.Services.CreateScope();
            var seeder = scope.ServiceProvider.GetRequiredService<Seeder>();
            var context = scope.ServiceProvider.GetRequiredService<LIContext>();
            var migrations = context.Database.GetPendingMigrations();

            context.InitializePostgresUuidExtension();

            if(migrations.Any())
            {
                await context.Database.MigrateAsync();
                await seeder.SeedDbAsync();
            }
            return host;
        }
    }
}