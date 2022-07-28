namespace MusicTrackAPI.Model.Track
{
    public class InsertTrackInPlaylistModel
    {
        public int TrackId { get; set; }

        public int PlaylistId { get; set; }

        public int TrackPosition { get; set; }
    }
}