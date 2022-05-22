using System;
using MusicTrackAPI.Data.Domain;

namespace MusicTrackAPI.Data.Repositories
{
	public interface IUserRepository: IRepositoryBase<User>
	{
		Task<User> GetUserAsync(string username, CancellationToken ct = default);
	}
}

