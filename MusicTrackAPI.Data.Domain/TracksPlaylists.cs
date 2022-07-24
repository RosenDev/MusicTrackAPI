using System;
namespace MusicTrackAPI.Data.Domain
{
    public class TracksPlaylists: MySqlEntity
    {
        public int TrackId { get; set; }
        public Track Track { get; set; }

        public int PlaylistId { get; set; }
        public Playlist Playlist { get; set; }

        public int TrackPosition { get; set; }
    }
}

