using MediatR;
using MusicTrackAPI.Services.Interface;

namespace MusicTrackAPI.Commands.Playlist
{
    public class InsertTrackInPlaylistCommandHnalder : IRequestHandler<InsertTrackInPlaylistCommand, int>
    {
        private readonly IPlaylistService playlistService;

        public InsertTrackInPlaylistCommandHnalder(IPlaylistService playlistService)
        {
            this.playlistService = playlistService;
        }
        public async Task<int> Handle(InsertTrackInPlaylistCommand request, CancellationToken cancellationToken)
        {
            var model = request.InsertTrackInPlaylistModel;
            return await playlistService.InsertTrackAsync(model.PlaylistId, model.TrackPosition, model.PlaylistId, cancellationToken);
        }
    }
}
