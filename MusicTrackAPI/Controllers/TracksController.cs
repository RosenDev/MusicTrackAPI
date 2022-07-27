using Autofac;
using Microsoft.AspNetCore.Mvc;
using MusicTrackAPI.Data.Domain;
using MusicTrackAPI.Model;
using MusicTrackAPI.Model.Album;
using MusicTrackAPI.Model.Track;
using MusicTrackAPI.Services;
using MusicTrackAPI.Services.Interface;

namespace MusicTrackAPI.Controllers
{
    public class TracksController : ApiController<Track, TrackModel>
    {
        private readonly ITrackService trackService;

        public TracksController(ITrackService trackService, ILogger<TracksController> logger) : base(trackService, logger)
        {
            this.trackService = trackService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTrackAsync([FromBody] TrackCreateModel createTrackModel, CancellationToken ct)
        {
            return Ok(await trackService.CreateTrackAsync(createTrackModel, ct));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTrackAsync([FromBody] TrackUpdateModel updateTrackModel, CancellationToken ct)
        {
            return Ok(await trackService.UpdateTrackAsync(updateTrackModel, ct));
        }
    }
}

