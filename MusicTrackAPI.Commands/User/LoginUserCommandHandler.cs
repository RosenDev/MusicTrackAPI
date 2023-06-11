using MediatR;
using MusicTrackAPI.Model;
using MusicTrackAPI.Services.Interface;

namespace MusicTrackAPI.Commands.Playlist
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, ApiResponse<string>>
    {
        private readonly IAuthenticationService authenticationService;

        public LoginUserCommandHandler(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }
        public async Task<ApiResponse<string>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            return new ApiResponse<string>((await authenticationService.AuthenticateAsync(request.UserLoginModel, cancellationToken)).Token);
        }
    }
}
