namespace MusicTrackAPI.Data.Domain;

public class Album : MySqlEntity
{
    public string Name { get; set; }
    public int PublishingYear { get; set; }
    public List<Track> Tracks { get; set; } = new List<Track>();
    public TimeSpan Duration { get; set; }
}

