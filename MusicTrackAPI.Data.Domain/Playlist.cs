namespace MusicTrackAPI.Data.Domain;

public class Playlist : MySqlEntity
{   
    public string Name { get; set; }

    public TimeSpan Duration { get; set; }

    public bool IsPublic { get; set; }

    public int? AlbumId { get; set; }
    public Album Album { get; set; }

    public ICollection<TrackPlaylist> TracksPlaylists { get; set; }

    public void AddTracks(List<int> trackIds)
    {
        trackIds.ForEach(x =>
        {
            TracksPlaylists.Add(new TrackPlaylist
            {
                TrackId = x
            });
        });
    }
}