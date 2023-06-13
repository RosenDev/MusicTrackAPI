using MediatR;
using MusicTrackAPI.Model;

namespace MusicTrackAPI.Commands.Playlist
{
    public class GetCurrentUserCommand : IRequest<ApiResponse<UserModel>>
    {
        public string Username { get; set; }
    }
}
