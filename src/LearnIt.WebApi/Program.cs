using LearnIt.DTO.Mapping;
using LearnIt.EF;
using LearnIt.Services;
using System.Text.Json.Serialization;

namespace LearnIt.WebApi
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers().AddJsonOptions(o =>
            {
                o.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.ConfigureEF(builder.Configuration);
            builder.Services.ConfigureServices();
            builder.Services.ConfigureMapper();

            var app = builder.Build();

            if(app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();

                await app.ApplyMigrationAsync();
            }

            app.MapControllers();

            app.Run();
        }
    }
}