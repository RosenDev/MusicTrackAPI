using System;
namespace MusicTrackAPI.Model
{
    public class PlaylistModel: ApiEntity
    {
        public int TrackPosition { get; set; }
        public string Name { get; set; }
        public string TrackName { get; set; }
        public string AlbumName { get; set; }
        public TimeSpan Duration { get; set; }
        public bool IsPublic { get; set; }
    }
}

