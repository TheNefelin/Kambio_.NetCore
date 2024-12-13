using ClassLibraryClient.Services;
using MauiKambio.Pages;
using Microsoft.Extensions.Logging;

namespace MauiKambio
{
    public static class MauiProgram
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            //builder.Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri("https://dragonra.bsite.net/") });
            builder.Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7062/") });
            builder.Services.AddSingleton<ApiCategoryService>();
            builder.Services.AddSingleton<ApiProductService>();

            builder.Services.AddTransient<ExplorerPage>();
            builder.Services.AddTransient<FavoritesPage>();
            builder.Services.AddTransient<PublishPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            var app = builder.Build();

            ServiceProvider = app.Services; // Asigna el proveedor de servicios
            return app;
        }
    }
}
