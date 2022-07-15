using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicTrackAPI.Common;
using MusicTrackAPI.Data.Domain;
using MusicTrackAPI.Model;
using MusicTrackAPI.Services.Interface;

namespace MusicTrackAPI.Controllers
{
    public class UserController : ApiController<User, UserModel>
    {
        private readonly IAuthenticationService authenticationService;
        private readonly IUserService userService;

        public UserController(IAuthenticationService authenticationService, IUserService userService) : base(userService)
        {
            this.authenticationService = authenticationService;
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
        public async Task<IActionResult> RegisterAsync([FromBody] UserRegisterModel user, CancellationToken ct)
        {
            var tokens = await authenticationService.RegisterUserAsync(user, ct);

            return Ok(tokens);
        }

        public override Task<IActionResult> Create([FromBody] UserModel apiModel, CancellationToken ct)
        {
            return Task.FromResult((IActionResult)Forbid(ErrorMessages.UseRegisterEnpoint));
        }

        [HttpGet("getcurrentuser")]
        public async Task<IActionResult> GetCurrentUserAsync(CancellationToken ct)
        {

            var currentUserUsername = User.Identity.Name;

            return Ok(await userService.GetUserAsync(currentUserUsername, ct));
        }
    }
}

