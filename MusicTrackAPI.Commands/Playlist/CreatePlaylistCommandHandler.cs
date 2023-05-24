using MediatR;
using MusicTrackAPI.Services.Interface;

namespace MusicTrackAPI.Commands.Playlist
{
    public class CreatePlaylistCommandHandler : IRequestHandler<CreatePlaylistCommand, int>
    {
        private readonly IPlaylistService playlistService;

        public CreatePlaylistCommandHandler(IPlaylistService playlistService)
        {
            this.playlistService = playlistService;
        }
        public async Task<int> Handle(CreatePlaylistCommand request, CancellationToken cancellationToken)
        {
            return await playlistService.CreatePlaylistAsync(request.PlaylistCreateModel, cancellationToken);
        }
    }
}
