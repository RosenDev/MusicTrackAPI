namespace MusicTrackAPI.Common;
public class PagedResponse<TResult> where TResult: class, new()
{
    public TResult Result { get; set; }

    public uint Page { get; set; }

    public uint Size { get; set; }
}
