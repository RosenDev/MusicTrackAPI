using System;
using MusicTrackAPI.Data.Domain;
using MusicTrackAPI.Model;
using MusicTrackAPI.Model.Track;

namespace MusicTrackAPI.Services.Interface
{
	public interface ITrackService : IDataService<Track, TrackModel>
	{
		Task<int> CreateTrackAsync(TrackCreateModel createTrackModel, CancellationToken ct);
		Task<int> UpdateTrackAsync(TrackUpdateModel updateTrackModel, CancellationToken ct);
    }
}

