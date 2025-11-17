using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using YoutubeMaui.Models;

namespace YoutubeMaui.ViewModels;

public class SongListViewModel : INotifyPropertyChanged
{
    public ObservableCollection<Song> Songs { get; } = new();

    public ICommand SelectSongCommand { get; }

    public SongListViewModel()
    {
        Songs.Add(new Song
        {
            Title = "Lofi Beats",
            Artist = "Lofi Girl",
            VideoId = "M7lc1UVf-VE"
        });

        Songs.Add(new Song
        {
            Title = "Coding Music",
            Artist = "ChillHop",
            VideoId = "M7lc1UVf-VE"
        });

        Songs.Add(new Song
        {
            Title = "Démo .NET MAUI",
            Artist = "Microsoft",
            VideoId = "3q3hE2lE0xE"
        });

        SelectSongCommand = new Command<Song>(async (song) => await OpenSongAsync(song));
    }

    private async Task OpenSongAsync(Song? song)
    {
        if (song is null)
            return;

        var parameters = new Dictionary<string, object>
    {
        { "VideoId", song.VideoId },
        { "Title", song.Title }
    };

        await Shell.Current.GoToAsync("PlayerPage", parameters);
    }


    public event PropertyChangedEventHandler? PropertyChanged;
    private void OnPropertyChanged([CallerMemberName] string? name = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
