using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LearnIt.YandexDictionary
{
    public static class Module
    {
        public static IServiceCollection ConfigureYandexDictionary(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<YandexDictionaryOption>(configuration.GetSection("YandexDictionary"));

            services.AddScoped<IYandexDictionary, YandexDictionary>();

            return services;
        }
    }
}