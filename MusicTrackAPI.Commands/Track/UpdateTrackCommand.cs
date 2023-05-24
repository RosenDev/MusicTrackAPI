using MediatR;
using MusicTrackAPI.Model.Track;

namespace MusicTrackAPI.Commands.Playlist
{
    public class UpdateTrackCommand : IRequest<int>
    {
        public TrackUpdateModel TrackUpdateModel { get; set; }
    }
}
