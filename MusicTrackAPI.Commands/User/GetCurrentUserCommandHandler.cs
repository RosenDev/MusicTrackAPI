using MediatR;
using MusicTrackAPI.Model;
using MusicTrackAPI.Services.Interface;

namespace MusicTrackAPI.Commands.Playlist
{
    public class GetCurrentUserCommandHandler : IRequestHandler<GetCurrentUserCommand, UserModel>
    {
        private readonly IUserService userService;

        public GetCurrentUserCommandHandler(IUserService userService)
        {
            this.userService = userService;
        }
        public async Task<UserModel> Handle(GetCurrentUserCommand request, CancellationToken cancellationToken)
        {
            return (await userService.GetUserAsync(request.Username, cancellationToken));
        }
    }
}
