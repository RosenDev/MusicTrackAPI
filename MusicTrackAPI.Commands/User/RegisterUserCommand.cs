using MediatR;
using MusicTrackAPI.Model;
using MusicTrackAPI.Model.User;

namespace MusicTrackAPI.Commands.Playlist
{
    public class RegisterUserCommand : IRequest<ApiResponse<string>>
    {
        public UserRegisterModel UserRegisterModel { get; set; }
    }
}
