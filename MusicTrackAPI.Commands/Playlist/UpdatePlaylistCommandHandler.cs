using MediatR;
using MusicTrackAPI.Model;
using MusicTrackAPI.Services.Interface;

namespace MusicTrackAPI.Commands.Playlist
{
    public class UpdatePlaylistCommandHandler : IRequestHandler<UpdatePlaylistCommand, ApiResponse<int>>
    {
        private readonly IPlaylistService playlistService;

        public UpdatePlaylistCommandHandler(IPlaylistService playlistService)
        {
            this.playlistService = playlistService;
        }
        public async Task<ApiResponse<int>> Handle(UpdatePlaylistCommand request, CancellationToken cancellationToken)
        {
            return new ApiResponse<int>(await playlistService.UpdatePlaylistAsync(request.PlaylistUpdateModel, cancellationToken));
        }
    }
}
