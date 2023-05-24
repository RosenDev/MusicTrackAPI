using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicTrackAPI.Commands.Playlist;
using MusicTrackAPI.Data.Domain;
using MusicTrackAPI.Model;
using MusicTrackAPI.Model.User;
using MusicTrackAPI.Services.Interface;

namespace MusicTrackAPI.Controllers
{
    public class UserController : ApiController<User, UserModel>
    {
        private readonly IMediator mediator;

        public UserController(
            IMediator mediator,
            IDataService<User, UserModel> dataService,
            ILogger<UserController> logger
            ) : base(dataService, logger)
        {
            this.mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] UserLoginModel userLoginModel, CancellationToken ct)
        {
            try
            {
                var tokens = await mediator.Send(new LoginUserCommand
                {
                    UserLoginModel = userLoginModel
                });

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
        public async Task<IActionResult> RegisterAsync([FromBody] UserRegisterModel userRegisterModel, CancellationToken ct)
        {
            try
            {
                var tokens = await mediator.Send(new RegisterUserCommand
                {
                    UserRegisterModel = userRegisterModel
                });

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

            return Ok(await mediator.Send(new GetCurrentUserCommand
            {
                Username = currentUserUsername
            }));
        }
    }
}

