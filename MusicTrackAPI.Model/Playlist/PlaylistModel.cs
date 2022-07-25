using System;
using MusicTrackAPI.Model.Album;
using MusicTrackAPI.Model.Track;

namespace MusicTrackAPI.Model
{
    public class PlaylistModel: ApiEntity
    {
        public int TrackPosition { get; set; }
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }
        public bool IsPublic { get; set; }
        public List<TrackInPlaylistModel> Tracks { get; set; }
        public AlbumModel Album { get; set; }
    }
}

