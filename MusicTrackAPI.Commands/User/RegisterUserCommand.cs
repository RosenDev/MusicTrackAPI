using MediatR;
using MusicTrackAPI.Model.User;

namespace MusicTrackAPI.Commands.Playlist
{
    public class RegisterUserCommand : IRequest<string>
    {
        public UserRegisterModel UserRegisterModel { get; set; }
    }
}
