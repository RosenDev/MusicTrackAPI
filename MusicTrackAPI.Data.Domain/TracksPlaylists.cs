using System;
namespace MusicTrackAPI.Data.Domain
{
    public class TrackPlaylist : MySqlEntity, IComparable<TrackPlaylist>
    {
        public int TrackId { get; set; }
        public Track Track { get; set; }

        public int PlaylistId { get; set; }
        public Playlist Playlist { get; set; }

        public int TrackPosition { get; set; }

        public int CompareTo(TrackPlaylist other)
        {
            return TrackPosition == other.TrackPosition ? 0 :
                TrackPosition > other.TrackPosition ? 1 : -1;
        }
    }
}

