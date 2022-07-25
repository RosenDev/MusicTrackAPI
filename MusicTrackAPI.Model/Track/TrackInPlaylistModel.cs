using System;
namespace MusicTrackAPI.Model.Track
{
    public class TrackInPlaylistModel
    {
        public int TrackId { get; set; }

        public int PlaylistId { get; set; }

        public int TrackPosition { get; set; }
    }
}