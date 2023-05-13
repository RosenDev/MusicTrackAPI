using MediatR;
using MusicTrackAPI.Common;
using MusicTrackAPI.Model.Interface;

namespace MusicTrackAPI.Commands.Common
{
    public class SearchEntityQuery<TApiEntity> : IRequest<PagedResponse<TApiEntity>>
        where TApiEntity : IApiEntity<int>
    {
        public List<FieldFilter> Filters { get; set; }

        public Paging Paging { get; set; }
    }
}
