using System;
using MusicTrackAPI.Model.Track;

namespace MusicTrackAPI.Model.Album
{
    public class AlbumCreateModel
    {
        public string Name { get; set; }
        public int PublishingYear { get; set; }
        public List<int> TrackIds { get; set; }
        public TimeSpan Duration { get; set; }
    }
}

