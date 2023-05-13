using MediatR;
using Microsoft.AspNetCore.Mvc;
using MusicTrackAPI.Commands.Album;
using MusicTrackAPI.Data.Domain;
using MusicTrackAPI.Model.Album;

namespace MusicTrackAPI.Controllers
{
    public class AlbumsController : ApiController<Album, AlbumModel>
    {
        public AlbumsController(IMediator mediator, ILogger<AlbumsController> logger)
            : base(mediator, logger)
        {
        }

        [HttpPost]
        public async Task<IActionResult> CreateAlbumAsync([FromBody] AlbumCreateModel createAlbumModel, CancellationToken ct)
        {
            return Ok(await mediator.Send(new CreateAlbumCommand
            {
                AlbumCreateModel = createAlbumModel
            }));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAlbumAsync([FromBody] AlbumUpdateModel updateAlbumModel, CancellationToken ct)
        {
            return Ok(await mediator.Send(new UpdateAlbumCommand
            {
                AlbumUpdateModel = updateAlbumModel
            }));
        }
    }
}

