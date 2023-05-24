using MediatR;
using MusicTrackAPI.Services.Interface;

namespace MusicTrackAPI.Commands.Playlist
{
    public class UpdateTrackCommandHandler : IRequestHandler<UpdateTrackCommand, int>
    {
        private readonly ITrackService trackService;

        public UpdateTrackCommandHandler(ITrackService trackService)
        {
            this.trackService = trackService;
        }
        public async Task<int> Handle(UpdateTrackCommand request, CancellationToken cancellationToken)
        {
            return await trackService.UpdateTrackAsync(request.TrackUpdateModel, cancellationToken);
        }
    }
}
