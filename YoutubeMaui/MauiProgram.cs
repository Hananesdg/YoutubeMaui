using YoutubeMaui.ViewModels;
using YoutubeMaui.Views;

namespace YoutubeMaui;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>();

        // ViewModels
        builder.Services.AddSingleton<SongListViewModel>();

        // Pages
        builder.Services.AddSingleton<SongListPage>();
        builder.Services.AddTransient<PlayerPage>();

        return builder.Build();
    }
}
