namespace MusicTrackAPI.Data.Domain;

public class Track: MySqlEntity
{
    public string Name { get; set; }
    public string WrittenBy { get; set; }
    public string PerformedBy { get; set; }
    public string ArrangedBy { get; set; }
    public TimeOnly Duration { get; set; }
    public TrackType Type { get; set; }
}