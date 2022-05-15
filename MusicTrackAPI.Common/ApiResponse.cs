namespace MusicTrackAPI.Common;

public class ApiResponse<TResult> where TResult : class, new()
{
    public TResult Result { get; set; }
}