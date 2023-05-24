using MediatR;
using MusicTrackAPI.Model.Playlist;

namespace MusicTrackAPI.Commands.Playlist
{
    public class CreatePlaylistCommand : IRequest<int>
    {
        public PlaylistCreateModel PlaylistCreateModel { get; set; }
    }
}
