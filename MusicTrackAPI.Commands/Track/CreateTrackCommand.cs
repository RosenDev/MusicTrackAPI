using MediatR;
using MusicTrackAPI.Model.Track;

namespace MusicTrackAPI.Commands.Playlist
{
    public class CreateTrackCommand : IRequest<int>
    {
        public TrackCreateModel TrackCreateModel { get; set; }
    }
}
