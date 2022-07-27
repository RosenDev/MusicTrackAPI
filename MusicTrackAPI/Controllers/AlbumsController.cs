using Autofac;
using Microsoft.AspNetCore.Mvc;
using MusicTrackAPI.Data.Domain;
using MusicTrackAPI.Model;
using MusicTrackAPI.Model.Album;
using MusicTrackAPI.Model.Playlist;
using MusicTrackAPI.Services;
using MusicTrackAPI.Services.Interface;

namespace MusicTrackAPI.Controllers
{
    public class AlbumsController : ApiController<Album, AlbumModel>
    {
        private readonly IAlbumService albumService;

        public AlbumsController(IAlbumService albumService, ILogger<AlbumsController> logger) : base(albumService, logger)
        {
            this.albumService = albumService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAlbumAsync([FromBody] AlbumCreateModel createAlbumModel, CancellationToken ct)
        {
            return Ok(await albumService.CreateAlbumAsync(createAlbumModel, ct));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAlbumAsync([FromBody] AlbumUpdateModel updateAlbumModel, CancellationToken ct)
        {
            return Ok(await albumService.UpdateAlbumAsync(updateAlbumModel, ct));
        }
    }
}

