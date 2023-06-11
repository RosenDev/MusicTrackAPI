using MusicTrackAPI.Model;
using MusicTrackAPI.Model.Interface;

namespace MusicTrackAPI.Common;
public class PagedResponse<TResult> : ApiResponse where TResult : IApiEntity<int>
{
    public PagedResponse(List<TResult> result, int page, int size, int totalRecords)
        : base(StatusCodes.OK, null)
    {
        Result = result;
        Page = page;
        Size = size;
        TotalRecords = totalRecords;
    }

    public List<TResult> Result { get; set; }

    public int Page { get; set; }

    public int Size { get; set; }

    public int TotalRecords { get; set; }
}
