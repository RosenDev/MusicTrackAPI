using System;
using MusicTrackAPI.Services.Model;

namespace MusicTrackAPI.Services
{
	public interface IAuthenticationService
	{
		Task<Tokens> AuthenticateAsync(UserModel user, CancellationToken ct = default);
		Task<Tokens> RegisterUserAsync(UserModel user, CancellationToken ct = default);
	}
}

