using MediatR;
using MusicTrackAPI.Model;
using MusicTrackAPI.Services.Interface;

namespace MusicTrackAPI.Commands.Playlist
{
    public class UpdateTrackCommandHandler : IRequestHandler<UpdateTrackCommand, ApiResponse<int>>
    {
        private readonly ITrackService trackService;

        public UpdateTrackCommandHandler(ITrackService trackService)
        {
            this.trackService = trackService;
        }
        public async Task<ApiResponse<int>> Handle(UpdateTrackCommand request, CancellationToken cancellationToken)
        {
            return new ApiResponse<int>(await trackService.UpdateTrackAsync(request.TrackUpdateModel, cancellationToken));
        }
    }
}
