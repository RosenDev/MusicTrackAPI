using MediatR;
using MusicTrackAPI.Model;
using MusicTrackAPI.Services.Interface;

namespace MusicTrackAPI.Commands.Album
{
    public class UpdateAlbumCommandHandler : IRequestHandler<UpdateAlbumCommand, ApiResponse<int>>
    {
        private readonly IAlbumService albumService;

        public UpdateAlbumCommandHandler(IAlbumService albumService)
        {
            this.albumService = albumService;
        }

        public async Task<ApiResponse<int>> Handle(UpdateAlbumCommand request, CancellationToken cancellationToken)
        {
            return new ApiResponse<int>(await albumService.UpdateAlbumAsync(request.AlbumUpdateModel, cancellationToken));
        }
    }
}
