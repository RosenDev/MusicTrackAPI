using MediatR;
using Microsoft.AspNetCore.Mvc;
using MusicTrackAPI.Commands.Playlist;
using MusicTrackAPI.Data.Domain;
using MusicTrackAPI.Model;
using MusicTrackAPI.Model.Playlist;
using MusicTrackAPI.Model.Track;
using MusicTrackAPI.Services.Interface;

namespace MusicTrackAPI.Controllers
{
    public class PlaylistsController : ApiController<Playlist, PlaylistModel>
    {
        private readonly IPlaylistService playlistService;
        private readonly IMediator mediator;

        public PlaylistsController(
            IMediator mediator,
            IDataService<Playlist, PlaylistModel> dataService,
            ILogger<PlaylistsController> logger
            )
            : base(dataService, logger)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlaylistAsync([FromBody] PlaylistCreateModel createPlaylistModel, CancellationToken ct)
        {
            return Ok(await mediator.Send(new CreatePlaylistCommand
            {
                PlaylistCreateModel = createPlaylistModel
            }));
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePlaylistAsync([FromBody] PlaylistUpdateModel updatePlaylistModel, CancellationToken ct)
        {
            return Ok(await mediator.Send(new UpdatePlaylistCommand
            {
                PlaylistUpdateModel = updatePlaylistModel
            }));
        }

        [HttpPost("insert-track")]
        public async Task<IActionResult> InsertTrackInPlaylistAsync([FromBody] InsertTrackInPlaylistModel insertTrackInPlaylistModel, CancellationToken ct)
        {
            return Ok(await mediator.Send(new InsertTrackInPlaylistCommand
            {
                InsertTrackInPlaylistModel = insertTrackInPlaylistModel
            }));
        }
    }
}

