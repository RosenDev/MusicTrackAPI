using MediatR;
using MusicTrackAPI.Model.Album;

namespace MusicTrackAPI.Commands.Album
{
    public class CreateAlbumCommand : IRequest<int>
    {
        public AlbumCreateModel AlbumCreateModel { get; set; }
    }
}
