namespace YoutubeMaui.Views;

[QueryProperty(nameof(VideoId), "VideoId")]
[QueryProperty(nameof(Title), "Title")]
public partial class PlayerPage : ContentPage
{
    private string _videoId = string.Empty;

    public string VideoId
    {
        get => _videoId;
        set
        {
            _videoId = value;
            LoadVideo();
        }
    }

    public new string Title
    {
        get => base.Title;
        set => base.Title = value;
    }

    public PlayerPage()
    {
        InitializeComponent();
    }

    private void LoadVideo()
    {
        if (string.IsNullOrWhiteSpace(VideoId))
        {
            DisplayAlert("Erreur", "VideoId vide ou null", "OK");
            return;
        }

        // ✅ HTML minimal avec uniquement le lecteur YouTube
        string html = $@"
<html>
  <head>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
  </head>
  <body style='margin:0; padding:0; background-color:black;'>
    <iframe width='100%' height='100%'
            src='https://www.youtube.com/embed/{VideoId}?playsinline=1'
            frameborder='0'
            allow='accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share'
            allowfullscreen>
    </iframe>
  </body>
</html>";

        VideoWebView.Source = new HtmlWebViewSource
        {
            Html = html
        };
    }
}
