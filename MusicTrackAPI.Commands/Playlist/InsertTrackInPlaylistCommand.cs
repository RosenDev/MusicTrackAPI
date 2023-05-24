using MediatR;
using MusicTrackAPI.Model.Track;

namespace MusicTrackAPI.Commands.Playlist
{
    public class InsertTrackInPlaylistCommand : IRequest<int>
    {
        public InsertTrackInPlaylistModel InsertTrackInPlaylistModel { get; set; }
    }
}
