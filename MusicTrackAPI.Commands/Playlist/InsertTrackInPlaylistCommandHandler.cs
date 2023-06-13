using MediatR;
using MusicTrackAPI.Model;
using MusicTrackAPI.Services.Interface;

namespace MusicTrackAPI.Commands.Playlist
{
    public class InsertTrackInPlaylistCommandHnalder : IRequestHandler<InsertTrackInPlaylistCommand, ApiResponse<int>>
    {
        private readonly IPlaylistService playlistService;

        public InsertTrackInPlaylistCommandHnalder(IPlaylistService playlistService)
        {
            this.playlistService = playlistService;
        }
        public async Task<ApiResponse<int>> Handle(InsertTrackInPlaylistCommand request, CancellationToken cancellationToken)
        {
            var model = request.InsertTrackInPlaylistModel;
            return new ApiResponse<int>(await playlistService.InsertTrackAsync(model.PlaylistId, model.TrackPosition, model.PlaylistId, cancellationToken));
        }
    }
}
