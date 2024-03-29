﻿using System;
using MusicTrackAPI.Model.Track;

namespace MusicTrackAPI.Model.Album
{
    public class AlbumModel: ApiEntity
    {
        public string Name { get; set; }
        public int PublishingYear { get; set; }
        public List<TrackModel> Tracks { get; set; }
        public TimeSpan Duration { get; set; }
    }
}

