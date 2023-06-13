using MediatR;
using MusicTrackAPI.Model;
using MusicTrackAPI.Services.Interface;

namespace MusicTrackAPI.Commands.Album
{
    public class CreateAlbumCommandHandler : IRequestHandler<CreateAlbumCommand, ApiResponse<int>>
    {
        private readonly IAlbumService albumService;

        public CreateAlbumCommandHandler(IAlbumService albumService)
        {
            this.albumService = albumService;
        }

        public async Task<ApiResponse<int>> Handle(CreateAlbumCommand request, CancellationToken cancellationToken)
        {
            return new ApiResponse<int>(await albumService.CreateAlbumAsync(request.AlbumCreateModel, cancellationToken));
        }
    }
}
