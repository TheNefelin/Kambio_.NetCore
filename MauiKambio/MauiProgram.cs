using ClassLibraryClient.Services;
using MauiKambio.Pages;
using Microsoft.Extensions.Logging;

namespace MauiKambio
{
    public static class MauiProgram
    {
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

            builder.Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri("https://dragonra.bsite.net/") });
            builder.Services.AddSingleton<ApiProductService>();

            builder.Services.AddSingleton<ExplorerPage>();
            builder.Services.AddSingleton<FavoritesPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
