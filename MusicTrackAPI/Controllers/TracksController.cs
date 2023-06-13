using MediatR;
using Microsoft.AspNetCore.Mvc;
using MusicTrackAPI.Commands.Playlist;
using MusicTrackAPI.Data.Domain;
using MusicTrackAPI.Model.Track;
using MusicTrackAPI.Services.Interface;

namespace MusicTrackAPI.Controllers
{
    public class TracksController : ApiController<Track, TrackModel>
    {
        private readonly IMediator mediator;

        public TracksController(
            IMediator mediator,
            ITrackService trackService,
            ILogger<TracksController> logger
            )
            : base(trackService, logger)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTrackAsync([FromBody] TrackCreateModel createTrackModel, CancellationToken ct)
        {
            return Ok(await mediator.Send(new CreateTrackCommand
            {
                TrackCreateModel = createTrackModel
            }));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTrackAsync([FromBody] TrackUpdateModel updateTrackModel, CancellationToken ct)
        {
            return Ok(await mediator.Send(new UpdateTrackCommand
            {
                TrackUpdateModel = updateTrackModel
            }));
        }
    }
}

