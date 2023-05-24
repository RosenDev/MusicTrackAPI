using MediatR;
using MusicTrackAPI.Model.User;

namespace MusicTrackAPI.Commands.Playlist
{
    public class LoginUserCommand : IRequest<string>
    {
        public UserLoginModel UserLoginModel { get; set; }
    }
}
