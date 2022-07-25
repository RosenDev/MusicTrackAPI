namespace MusicTrackAPI.Model.Track
{
    public class TrackCreateModel
    {
        public string Name { get; set; }
        public string WrittenBy { get; set; }
        public string PerformedBy { get; set; }
        public string ArrangedBy { get; set; }
        public TimeSpan Duration { get; set; }
        public TrackType Type { get; set; }
    }
}
