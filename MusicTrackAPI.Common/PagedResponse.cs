namespace MusicTrackAPI.Common;
public class PagedResponse<TResult> where TResult: class, new()
{
    public TResult Result { get; set; }

    public int Page { get; set; }

    public int Size { get; set; }
}
