using MusicTrackAPI.Model.Interface;

namespace MusicTrackAPI.Common;
public class PagedResponse<TResult> where TResult: IApiEntity<int>
{
    public List<TResult> Result { get; set; }

    public int Page { get; set; }

    public int Size { get; set; }

    public int TotalRecords { get; set; }
}
