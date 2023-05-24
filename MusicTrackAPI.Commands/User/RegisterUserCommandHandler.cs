using MediatR;
using MusicTrackAPI.Services.Interface;

namespace MusicTrackAPI.Commands.Playlist
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, string>
    {
        private readonly IAuthenticationService authenticationService;

        public RegisterUserCommandHandler(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }
        public async Task<string> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            return (await authenticationService.RegisterUserAsync(request.UserRegisterModel, cancellationToken)).Token;
        }
    }
}
