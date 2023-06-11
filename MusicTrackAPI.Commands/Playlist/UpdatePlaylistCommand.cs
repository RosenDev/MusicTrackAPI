using MediatR;
using MusicTrackAPI.Model;
using MusicTrackAPI.Model.Playlist;

namespace MusicTrackAPI.Commands.Playlist
{
    public class UpdatePlaylistCommand : IRequest<ApiResponse<int>>
    {
        public PlaylistUpdateModel PlaylistUpdateModel { get; set; }
    }
}
