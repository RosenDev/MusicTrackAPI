using MusicTrackAPI.Common;

namespace MusicTrackAPI.Data.Domain;

public class Playlist : MySqlEntity
{
    public string Name { get; set; }

    public TimeSpan Duration { get; set; }

    public bool IsPublic { get; set; }

    public int? AlbumId { get; set; }
    public Album? Album { get; set; }

    public ICollection<TrackPlaylist> TracksPlaylists { get; set; } = new List<TrackPlaylist>();

    public void AddTracks(List<int> trackIds)
    {
        trackIds.ForEach(x =>
        {
            TracksPlaylists.Add(new TrackPlaylist
            {
                TrackId = x,
                PlaylistId = Id
            });
        });
    }


    public void RemoveTrack(int trackId)
    {
        var trackToRemove = TracksPlaylists.FirstOrDefault(x => x.TrackId == trackId);

        if(trackToRemove == null)
        {
            throw new ArgumentNullException(ErrorMessages.TrackNotFound);
        }

        TracksPlaylists.Remove(trackToRemove);
    }
}