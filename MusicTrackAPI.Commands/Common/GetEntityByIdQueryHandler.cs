using MediatR;
using MusicTrackAPI.Data.Domain.Interface;
using MusicTrackAPI.Model.Interface;
using MusicTrackAPI.Services.Interface;

namespace MusicTrackAPI.Commands.Common
{
    public class GetEntityByIdQueryHandler<TEntity, TApiEntity> : IRequestHandler<GetEntityByIdQuery<TApiEntity>, TApiEntity>
        where TEntity : IEntity<int>
        where TApiEntity : IApiEntity<int>
    {
        private readonly IDataService<TEntity, TApiEntity> dataService;

        public GetEntityByIdQueryHandler(IDataService<TEntity, TApiEntity> dataService)
        {
            this.dataService = dataService;
        }
        public async Task<TApiEntity> Handle(GetEntityByIdQuery<TApiEntity> request, CancellationToken cancellationToken)
        {
            return await dataService.GetByIdAsync(request.Id, cancellationToken);
        }
    }
}
