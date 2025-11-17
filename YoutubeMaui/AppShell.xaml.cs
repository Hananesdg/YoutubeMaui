using YoutubeMaui.Views;

namespace YoutubeMaui;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute("PlayerPage", typeof(PlayerPage));
    }
}
