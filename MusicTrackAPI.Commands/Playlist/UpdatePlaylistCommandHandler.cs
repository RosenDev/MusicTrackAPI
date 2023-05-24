using MediatR;
using MusicTrackAPI.Services.Interface;

namespace MusicTrackAPI.Commands.Playlist
{
    public class UpdatePlaylistCommandHandler : IRequestHandler<UpdatePlaylistCommand, int>
    {
        private readonly IPlaylistService playlistService;

        public UpdatePlaylistCommandHandler(IPlaylistService playlistService)
        {
            this.playlistService = playlistService;
        }
        public async Task<int> Handle(UpdatePlaylistCommand request, CancellationToken cancellationToken)
        {
            return await playlistService.UpdatePlaylistAsync(request.PlaylistUpdateModel, cancellationToken);
        }
    }
}
