using MediatR;
using MusicTrackAPI.Model;
using MusicTrackAPI.Services.Interface;

namespace MusicTrackAPI.Commands.Playlist
{
    public class CreatePlaylistCommandHandler : IRequestHandler<CreatePlaylistCommand, ApiResponse<int>>
    {
        private readonly IPlaylistService playlistService;

        public CreatePlaylistCommandHandler(IPlaylistService playlistService)
        {
            this.playlistService = playlistService;
        }
        public async Task<ApiResponse<int>> Handle(CreatePlaylistCommand request, CancellationToken cancellationToken)
        {
            return new ApiResponse<int>(await playlistService.CreatePlaylistAsync(request.PlaylistCreateModel, cancellationToken));
        }
    }
}
