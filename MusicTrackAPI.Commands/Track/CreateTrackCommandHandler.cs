using MediatR;
using MusicTrackAPI.Model;
using MusicTrackAPI.Services.Interface;

namespace MusicTrackAPI.Commands.Playlist
{
    public class CreateTrackCommandHandler : IRequestHandler<CreateTrackCommand, ApiResponse<int>>
    {
        private readonly ITrackService trackService;

        public CreateTrackCommandHandler(ITrackService trackService)
        {
            this.trackService = trackService;
        }
        public async Task<ApiResponse<int>> Handle(CreateTrackCommand request, CancellationToken cancellationToken)
        {
            return new ApiResponse<int>(await trackService.CreateTrackAsync(request.TrackCreateModel, cancellationToken));
        }
    }
}
