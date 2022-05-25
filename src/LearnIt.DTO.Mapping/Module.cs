using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace LearnIt.DTO.Mapping
{
    public static class Module
    {
        public static IServiceCollection ConfigureMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}