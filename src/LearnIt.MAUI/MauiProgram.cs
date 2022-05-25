using LearnIt.MAUI.Constants;
using LearnIt.MAUI.Services;
using LearnIt.WebApi.Queries;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace LearnIt.MAUI
{
    public static class MauiProgram
    {
        public static string BaseAddress =
            DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5114/api" : "http://localhost:5114/api";

        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("Montserrat-Italic-VariableFont_wght.ttf", "Montserrat");
                    fonts.AddFont("Montserrat-VariableFont_wght.ttf", "Montserrat");
                });

            ConfigureServices(builder);
            ConfigureConfigurationVariables(builder);

            return builder.Build();
        }

        private static void ConfigureConfigurationVariables(MauiAppBuilder builder)
        {
#if DEBUG
            builder.Configuration[EnviromentConstants.ENVIROMENT_KEY] = EnviromentConstants.DEVELOPMENT_KEY;
#else
            builder.Configuration[EnviromentConstants.ENVIROMENT_KEY] = EnviromentConstants.PRODUCTION_KEY;
#endif
        }

        private static void ConfigureServices(MauiAppBuilder builder)
        {
            builder.Services.AddMauiBlazorWebView();
#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
#endif

            builder.Services.TryAddSingleton<LocalStorageService>();
            builder.Services.TryAddSingleton<LocalCategoryService>();
            builder.Services.TryAddSingleton<ConfigurationService>();

            builder.Services.ConfigureRefit(BaseAddress);
        }
    }
}