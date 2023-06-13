using MediatR;
using MusicTrackAPI.Model;
using MusicTrackAPI.Model.User;

namespace MusicTrackAPI.Commands.Playlist
{
    public class LoginUserCommand : IRequest<ApiResponse<string>>
    {
        public UserLoginModel UserLoginModel { get; set; }
    }
}
