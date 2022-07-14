using System;
using MusicTrackAPI.Data.Domain;
using MusicTrackAPI.Model;

namespace MusicTrackAPI.Services.Interface
{
	public interface ITrackService : IDataService<Track, TrackModel>
	{
    }
}

