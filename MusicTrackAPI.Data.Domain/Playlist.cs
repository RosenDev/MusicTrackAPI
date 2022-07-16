namespace MusicTrackAPI.Data.Domain;

public class Playlist : MySqlEntity
{   
    public int TrackPosition { get; set; }
    public string Name { get; set; }
    public string TrackName { get; set; }
    public string AlbumName { get; set; }
    public TimeSpan Duration { get; set; }
    public bool IsPublic { get; set; }
}

