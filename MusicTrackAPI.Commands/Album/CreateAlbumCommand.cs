using MediatR;
using MusicTrackAPI.Model;
using MusicTrackAPI.Model.Album;

namespace MusicTrackAPI.Commands.Album
{
    public class CreateAlbumCommand : IRequest<ApiResponse<int>>
    {
        public AlbumCreateModel AlbumCreateModel { get; set; }
    }
}
