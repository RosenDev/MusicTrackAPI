using MusicTrackAPI.Data.Domain;

namespace MusicTrackAPI.Services
{
    public class TrackPlaylistComparer : IComparer<TrackPlaylist>
    {
        public int Compare(TrackPlaylist? x, TrackPlaylist? y)
        {
            return x.TrackPosition == y.TrackPosition ? 0 : x.TrackPosition > y.TrackPosition ? 1 : -1;
        }
    }
}

