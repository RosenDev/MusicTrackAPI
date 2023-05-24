using MediatR;
using MusicTrackAPI.Model.Playlist;

namespace MusicTrackAPI.Commands.Playlist
{
    public class UpdatePlaylistCommand : IRequest<int>
    {
        public PlaylistUpdateModel PlaylistUpdateModel { get; set; }
    }
}
