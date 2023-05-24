using MediatR;
using MusicTrackAPI.Services.Interface;

namespace MusicTrackAPI.Commands.Album
{
    public class CreateAlbumCommandHandler : IRequestHandler<CreateAlbumCommand, int>
    {
        private readonly IAlbumService albumService;

        public CreateAlbumCommandHandler(IAlbumService albumService)
        {
            this.albumService = albumService;
        }

        public async Task<int> Handle(CreateAlbumCommand request, CancellationToken cancellationToken)
        {
            return await albumService.CreateAlbumAsync(request.AlbumCreateModel, cancellationToken);
        }
    }
}
