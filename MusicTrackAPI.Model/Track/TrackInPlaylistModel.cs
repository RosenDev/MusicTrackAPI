using System;
namespace MusicTrackAPI.Model.Track
{
    public class TrackInPlaylistModel
    {
        public TrackModel Track { get; set; }

        public int TrackPosition { get; set; }
    }
}