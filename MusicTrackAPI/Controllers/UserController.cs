using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicTrackAPI.Services;
using MusicTrackAPI.Services.Model;

namespace MusicTrackAPI.Controllers
{
	public class UserController: ApiController<UserModel>
	{
        private readonly IAuthenticationService authenticationService;
        private readonly ILogger<UserController> logger;

        public UserController(
			IAuthenticationService authenticationService,
			ILogger<UserController> logger
			)
		{
            this.authenticationService = authenticationService;
            this.logger = logger;
        }

		[AllowAnonymous]
		[HttpPost("login")]
		public async Task<IActionResult> LoginAsync([FromBody]UserModel user, CancellationToken ct)
        {
			try
			{
				var tokens = await authenticationService.AuthenticateAsync(user, ct);

				return Ok(tokens);

			}
            catch (Exception ex)
            {
				logger.LogWarning(ex.Message);

				return Unauthorized();
            }
        }

		[AllowAnonymous]
		[HttpPost("register")]
		public async Task<IActionResult> RegisterAsync([FromBody]UserModel user, CancellationToken ct)
        {
			try
			{
				var tokens = await authenticationService.RegisterUserAsync(user, ct);

				return Ok(tokens);

			}
			catch (Exception ex)
			{
				logger.LogWarning(ex.Message);

				return Unauthorized();
			}
		}

		[HttpGet("test")]
		public async Task<IActionResult> ReturnOkIfAuthorize()
        {
			return Ok("Hi");
        }

		//[Authorize]
		//[HttpPost("logout")]
		//public async Task<IActionResult> Logout()
		//{
		//	try
		//	{
		 
				

		//		return Ok(tokens);

		//	}
		//	catch (Exception ex)
		//	{
		//		logger.LogWarning(ex.Message);

		//		return Unauthorized();
		//	}
		//}
	}
}

