using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicTrackAPI.Data.Domain;
using MusicTrackAPI.Model;
using MusicTrackAPI.Model.User;
using MusicTrackAPI.Services.Interface;

namespace MusicTrackAPI.Controllers
{
    public class UserController : ApiController<User, UserModel>
    {
        private readonly IAuthenticationService authenticationService;
        private readonly IUserService userService;

        public UserController(
            IAuthenticationService authenticationService,
            IUserService userService,
            IMediator mediator,
            ILogger<UserController> logger
            ) : base(mediator, logger)
        {
            this.authenticationService = authenticationService;
            this.userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] UserLoginModel userLoginModel, CancellationToken ct)
        {
            try
            {
                var tokens = await authenticationService.AuthenticateAsync(userLoginModel, ct);

                return Ok(tokens);

            }
            catch(Exception ex)
            {
                if(ex is ArgumentException argEx)
                {
                    return BadRequest(argEx.Message);
                }

                throw;
            }

        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] UserRegisterModel user, CancellationToken ct)
        {
            try
            {

                var tokens = await authenticationService.RegisterUserAsync(user, ct);

                return Ok(tokens);

            }
            catch(Exception ex)
            {
                if(ex is ArgumentException argEx)
                {
                    return BadRequest(argEx.Message);
                }

                throw;
            }
        }

        [HttpGet("getcurrentuser")]
        public async Task<IActionResult> GetCurrentUserAsync(CancellationToken ct)
        {

            var currentUserUsername = User.Identity.Name;

            return Ok(await userService.GetUserAsync(currentUserUsername, ct));
        }
    }
}

