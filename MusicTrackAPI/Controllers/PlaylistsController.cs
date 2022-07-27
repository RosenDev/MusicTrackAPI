using Autofac;
using Microsoft.AspNetCore.Mvc;
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

        public PlaylistsController(IPlaylistService playlistService, ILogger<PlaylistsController> logger)
            : base(playlistService, logger)
        {
            this.playlistService = playlistService;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlaylistAsync([FromBody] PlaylistCreateModel createPlaylistModel, CancellationToken ct)
        {
            return Ok(await playlistService.CreatePlaylistAsync(createPlaylistModel, ct));
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePlaylistAsync([FromBody] PlaylistUpdateModel updatePlaylistModel, CancellationToken ct)
        {
            return Ok(await playlistService.UpdatePlaylistAsync(updatePlaylistModel, ct));
        }

        [HttpPost("insert-track")]
        public async Task<IActionResult> InsertTrackInPlaylistAsync([FromBody] InsertTrackInPlaylistModel updatePlaylistModel, CancellationToken ct)
        {
            return Ok(await playlistService.InsertTrackAsync(updatePlaylistModel.PlaylistId, updatePlaylistModel.TrackPosition, updatePlaylistModel.TrackId, ct));
        }
    }
}

