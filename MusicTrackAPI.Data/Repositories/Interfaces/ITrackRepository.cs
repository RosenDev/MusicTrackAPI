using System;
using MusicTrackAPI.Data.Domain;

namespace MusicTrackAPI.Data.Repositories.Interfaces
{
	public interface ITrackRepository: IRepositoryBase<Track>
	{
		Task<TimeSpan> GetTotalTracksDurationAsync(List<int> ids, CancellationToken ct);
	}
}

