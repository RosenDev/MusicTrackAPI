using MediatR;
using MusicTrackAPI.Data.Domain.Interface;
using MusicTrackAPI.Model.Interface;
using MusicTrackAPI.Services.Interface;

namespace MusicTrackAPI.Commands.Common
{
    public class DeleteEntityCommandHandler<TEntity, TApiEntity> : IRequestHandler<DeleteEntityCommand<TApiEntity>>
        where TEntity : IEntity<int>
        where TApiEntity : IApiEntity<int>
    {
        private readonly IDataService<TEntity, TApiEntity> dataService;

        public DeleteEntityCommandHandler(IDataService<TEntity, TApiEntity> dataService)
        {
            this.dataService = dataService;
        }

        public async Task Handle(DeleteEntityCommand<TApiEntity> request, CancellationToken cancellationToken)
        {
            await dataService.DeleteAsync(request.Id, cancellationToken);
        }
    }
}
