using MediatR;
using MusicTrackAPI.Model.Album;

namespace MusicTrackAPI.Commands.Album
{
    public class UpdateAlbumCommand : IRequest<int>
    {
        public AlbumUpdateModel AlbumUpdateModel { get; set; }
    }
}
