using System;
using MusicTrackAPI.Data.Domain;
using MusicTrackAPI.Model;

namespace MusicTrackAPI.Services.Interface
{
	public interface IUserService: IDataService<User, UserModel>
	{
		Task<UserModel> GetUserAsync(string username, CancellationToken ct);
    }
}

