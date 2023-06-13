using MediatR;
using MusicTrackAPI.Model;
using MusicTrackAPI.Model.Album;

namespace MusicTrackAPI.Commands.Album
{
    public class UpdateAlbumCommand : IRequest<ApiResponse<int>>
    {
        public AlbumUpdateModel AlbumUpdateModel { get; set; }
    }
}
