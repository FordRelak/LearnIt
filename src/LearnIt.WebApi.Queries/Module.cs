using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace LearnIt.WebApi.Queries
{
    public static class Module
    {
        public static IServiceCollection ConfigureRefit(this IServiceCollection services, string baseAddress)
        {
            var refitSettings = new RefitSettings
            {
                CollectionFormat = CollectionFormat.Multi
            };

            services
                .AddRefitClient<ICategoryApi>(refitSettings)
                .ConfigureHttpClient(x => x.BaseAddress = new Uri(baseAddress));

            services
                .AddRefitClient<IDeviceApi>(refitSettings)
                .ConfigureHttpClient(x => x.BaseAddress = new Uri(baseAddress));

            return services;
        }
    }
}