using MediatR;
using MusicTrackAPI.Services.Interface;

namespace MusicTrackAPI.Commands.Playlist
{
    public class CreateTrackCommandHandler : IRequestHandler<CreateTrackCommand, int>
    {
        private readonly ITrackService trackService;

        public CreateTrackCommandHandler(ITrackService trackService)
        {
            this.trackService = trackService;
        }
        public async Task<int> Handle(CreateTrackCommand request, CancellationToken cancellationToken)
        {
            return await trackService.CreateTrackAsync(request.TrackCreateModel, cancellationToken);
        }
    }
}
