using MediatR;
using MusicTrackAPI.Model;
using MusicTrackAPI.Model.Track;

namespace MusicTrackAPI.Commands.Playlist
{
    public class InsertTrackInPlaylistCommand : IRequest<ApiResponse<int>>
    {
        public InsertTrackInPlaylistModel InsertTrackInPlaylistModel { get; set; }
    }
}
