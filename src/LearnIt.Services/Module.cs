using LearnIt.Services.Implementations;
using LearnIt.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace LearnIt.Services
{
    public static class Module
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IWordService, WordService>();
            services.AddScoped<IDeviceService, DeviceService>();

            return services;
        }
    }
}