namespace MusicTrackAPI.Data.Domain;

public class Album : MySqlEntity
{
    public string Name { get; set; }
    public int PublishingYear { get; set; }
    public TimeSpan Duration { get; set; }

    public ICollection<Track> Tracks { get; set; }
    public ICollection<Playlist> Playlists { get; set; }
}