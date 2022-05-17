namespace LearnIt.MAUI
{
    public static class MauiProgram
    {
        public static string BaseAddress =
            DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5114" : "http://localhost:5114";

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

            return builder.Build();
        }

        private static void ConfigureServices(MauiAppBuilder builder)
        {
            builder.Services.AddMauiBlazorWebView();
#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
#endif
        }
    }
}