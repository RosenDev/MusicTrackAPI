using MediatR;
using MusicTrackAPI.Model;
using MusicTrackAPI.Model.Track;

namespace MusicTrackAPI.Commands.Playlist
{
    public class UpdateTrackCommand : IRequest<ApiResponse<int>>
    {
        public TrackUpdateModel TrackUpdateModel { get; set; }
    }
}
