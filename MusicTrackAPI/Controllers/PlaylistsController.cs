using Autofac;
using MusicTrackAPI.Data.Domain;
using MusicTrackAPI.Model;
using MusicTrackAPI.Services.Interface;

namespace MusicTrackAPI.Controllers
{
    public class PlaylistsController : ApiController<Playlist, PlaylistModel>
    {
        public PlaylistsController(IPlaylistService playlistService) : base(playlistService)
        {

        }
    }
}

