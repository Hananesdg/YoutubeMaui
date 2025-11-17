using YoutubeMaui.ViewModels;
using YoutubeMaui.Models;

namespace YoutubeMaui.Views;

public partial class SongListPage : ContentPage
{
    private SongListViewModel ViewModel => (SongListViewModel)BindingContext;

    public SongListPage(SongListViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Song song)
        {
            ViewModel.SelectSongCommand.Execute(song);
            ((CollectionView)sender).SelectedItem = null;
        }
    }
}
