using MediatR;
using MusicTrackAPI.Common;
using MusicTrackAPI.Data.Domain.Interface;
using MusicTrackAPI.Model.Interface;
using MusicTrackAPI.Services.Interface;

namespace MusicTrackAPI.Commands.Common
{
    public class SearchEntityQueryHandler<TEntity, TApiEntity> : IRequestHandler<SearchEntityQuery<TApiEntity>, PagedResponse<TApiEntity>>
        where TApiEntity : IApiEntity<int>
        where TEntity : IEntity<int>
    {
        private readonly IDataService<TEntity, TApiEntity> dataService;

        public SearchEntityQueryHandler(IDataService<TEntity, TApiEntity> dataService)
        {
            this.dataService = dataService;
        }

        public async Task<PagedResponse<TApiEntity>> Handle(SearchEntityQuery<TApiEntity> request, CancellationToken cancellationToken)
        {
            return await dataService.QueryAsync(request.Filters, request.Paging, cancellationToken);
        }
    }
}
