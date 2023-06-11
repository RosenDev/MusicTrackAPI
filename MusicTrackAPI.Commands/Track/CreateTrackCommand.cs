using MediatR;
using MusicTrackAPI.Model;
using MusicTrackAPI.Model.Track;

namespace MusicTrackAPI.Commands.Playlist
{
    public class CreateTrackCommand : IRequest<ApiResponse<int>>
    {
        public TrackCreateModel TrackCreateModel { get; set; }
    }
}
