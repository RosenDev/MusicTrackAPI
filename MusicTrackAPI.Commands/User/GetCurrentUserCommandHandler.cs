using MediatR;
using MusicTrackAPI.Model;
using MusicTrackAPI.Services.Interface;

namespace MusicTrackAPI.Commands.Playlist
{
    public class GetCurrentUserCommandHandler : IRequestHandler<GetCurrentUserCommand, ApiResponse<UserModel>>
    {
        private readonly IUserService userService;

        public GetCurrentUserCommandHandler(IUserService userService)
        {
            this.userService = userService;
        }
        public async Task<ApiResponse<UserModel>> Handle(GetCurrentUserCommand request, CancellationToken cancellationToken)
        {
            return new ApiResponse<UserModel>(await userService.GetUserAsync(request.Username, cancellationToken));
        }
    }
}
