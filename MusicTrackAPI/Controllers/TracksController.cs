using Autofac;
using MusicTrackAPI.Data.Domain;
using MusicTrackAPI.Model;
using MusicTrackAPI.Services.Interface;

namespace MusicTrackAPI.Controllers
{
    public class TracksController : ApiController<Track, TrackModel>
    {
        public TracksController(ITrackService trackService) : base(trackService)
        {

        }
    }
}

