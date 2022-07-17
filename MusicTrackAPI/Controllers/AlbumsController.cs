using Autofac;
using MusicTrackAPI.Data.Domain;
using MusicTrackAPI.Model;
using MusicTrackAPI.Services.Interface;

namespace MusicTrackAPI.Controllers
{
    public class AlbumsController : ApiController<Album, AlbumModel>
    {
        public AlbumsController(IAlbumService albumService, ILogger<AlbumsController> logger) : base(albumService, logger)
        {

        }
    }
}

