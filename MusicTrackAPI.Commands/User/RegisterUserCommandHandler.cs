using MediatR;
using MusicTrackAPI.Model;
using MusicTrackAPI.Services.Interface;

namespace MusicTrackAPI.Commands.Playlist
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, ApiResponse<string>>
    {
        private readonly IAuthenticationService authenticationService;

        public RegisterUserCommandHandler(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }
        public async Task<ApiResponse<string>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            return new ApiResponse<string>((await authenticationService.RegisterUserAsync(request.UserRegisterModel, cancellationToken)).Token);
        }
    }
}
