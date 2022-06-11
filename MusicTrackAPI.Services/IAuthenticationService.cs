using System;
using MusicTrackAPI.Model;

namespace MusicTrackAPI.Services
{
	public interface IAuthenticationService
	{
		Task<Tokens> AuthenticateAsync(UserLoginModel userLoginModel, CancellationToken ct = default);
		Task<Tokens> RegisterUserAsync(UserModel user, CancellationToken ct = default);
	}
}

