using Autofac;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicTrackAPI.Model;
using MusicTrackAPI.Data.Domain;
using MusicTrackAPI.Services.Interface;

namespace MusicTrackAPI.Controllers
{
	public class UserController: ApiController<User, UserModel>
	{
		private readonly IAuthenticationService authenticationService;

		public UserController(ILifetimeScope container, IUserService userService): base(userService)
		{
			this.authenticationService = container.Resolve<IAuthenticationService>();
		}

		[AllowAnonymous]
		[HttpPost("login")]
		public async Task<IActionResult> LoginAsync([FromBody] UserLoginModel userLoginModel, CancellationToken ct)
		{
			var tokens = await authenticationService.AuthenticateAsync(userLoginModel, ct);

			return Ok(tokens);
		}

		[AllowAnonymous]
		[HttpPost("register")]
		public async Task<IActionResult> RegisterAsync([FromBody]UserModel user, CancellationToken ct)
		{

			var tokens = await authenticationService.RegisterUserAsync(user, ct);

			return Ok(tokens);
		}
	}
}

