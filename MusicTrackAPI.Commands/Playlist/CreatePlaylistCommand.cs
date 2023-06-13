using MediatR;
using MusicTrackAPI.Model;
using MusicTrackAPI.Model.Playlist;

namespace MusicTrackAPI.Commands.Playlist
{
    public class CreatePlaylistCommand : IRequest<ApiResponse<int>>
    {
        public PlaylistCreateModel PlaylistCreateModel { get; set; }
    }
}
