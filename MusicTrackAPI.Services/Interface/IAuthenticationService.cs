using System;
using MusicTrackAPI.Model;
using MusicTrackAPI.Model.User;

namespace MusicTrackAPI.Services.Interface
{
	public interface IAuthenticationService
	{
		Task<Tokens> AuthenticateAsync(UserLoginModel userLoginModel, CancellationToken ct = default);
		Task<Tokens> RegisterUserAsync(UserRegisterModel user, CancellationToken ct = default);
	}
}

