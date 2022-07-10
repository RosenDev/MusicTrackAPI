using Autofac;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicTrackAPI.Model;
using MusicTrackAPI.Data.Domain;
using MusicTrackAPI.Services.Interface;
using System.Security.Claims;

namespace MusicTrackAPI.Controllers
{
	public class UserController: ApiController<User, UserModel>
	{
		private readonly IAuthenticationService authenticationService;
        private readonly IUserService userService;

        public UserController(ILifetimeScope container, IUserService userService): base(userService)
		{
			this.authenticationService = container.Resolve<IAuthenticationService>();
            this.userService = userService;
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

		[HttpGet("getcurrentuser")]
		public async Task<IActionResult> GetCurrentUserAsync(CancellationToken ct)
		{

			var currentUserUsername = User.Identity.Name;

			return Ok(await userService.GetUserAsync(currentUserUsername, ct));
		}
	}
}

