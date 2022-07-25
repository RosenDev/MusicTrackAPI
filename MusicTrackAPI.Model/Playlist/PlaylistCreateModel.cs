using System;
using MusicTrackAPI.Model.Album;
using MusicTrackAPI.Model.Track;

namespace MusicTrackAPI.Model.Playlist
{
    public class PlaylistCreateModel
    {
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }
        public bool IsPublic { get; set; }
        public List<int> TracksIds { get; set; }
        public int? AlbumId { get; set; }
    }
}
