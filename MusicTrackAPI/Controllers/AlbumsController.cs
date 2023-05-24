using MediatR;
using Microsoft.AspNetCore.Mvc;
using MusicTrackAPI.Commands.Album;
using MusicTrackAPI.Data.Domain;
using MusicTrackAPI.Model.Album;
using MusicTrackAPI.Services.Interface;

namespace MusicTrackAPI.Controllers
{
    public class AlbumsController : ApiController<Album, AlbumModel>
    {
        private readonly IMediator mediator;

        public AlbumsController(
            IMediator mediator,
            IDataService<Album, AlbumModel> dataService,
            ILogger<AlbumsController> logger
            )
            : base(dataService, logger)
        {
            this.mediator = mediator;
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

