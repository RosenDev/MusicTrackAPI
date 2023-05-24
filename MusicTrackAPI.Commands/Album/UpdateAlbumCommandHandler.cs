using MediatR;
using MusicTrackAPI.Services.Interface;

namespace MusicTrackAPI.Commands.Album
{
    public class UpdateAlbumCommandHandler : IRequestHandler<UpdateAlbumCommand, int>
    {
        private readonly IAlbumService albumService;

        public UpdateAlbumCommandHandler(IAlbumService albumService)
        {
            this.albumService = albumService;
        }

        public async Task<int> Handle(UpdateAlbumCommand request, CancellationToken cancellationToken)
        {
            return await albumService.UpdateAlbumAsync(request.AlbumUpdateModel, cancellationToken);
        }
    }
}
